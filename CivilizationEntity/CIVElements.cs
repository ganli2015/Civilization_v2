using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEntity;
using System.Windows.Forms;
using System.Drawing;

namespace CivilizationEntity
{
    public class CIVElements : GameElements
    {
//         EnvironmentEntity _environmentEntity;
//         AliveEntity _aliveEntity;

        TileEntity _tileEntity;
        GameDisplay _gameDisplay;
        Alive _player;

        Dictionary<Point,Alive> _alives;

        public CIVElements(ref GameDisplay gameDisplay)
        {
            _gameDisplay = gameDisplay;
            _tileEntity = new CIVTileEntity();
            _tileEntity.SetPictureBox(ref gameDisplay);
            _alives = new Dictionary<Point, Alive>();
        }

        public void Add(Alive alive)
        {
            _tileEntity.Add(alive);

            if (!_alives.ContainsKey(alive.GetLocationIndex()))
            {
                _alives[alive.GetLocationIndex()]=alive;
            }

        }

        public void Add(GameEntity.Environ environment)
        {
            _tileEntity.Add(environment);
        }

        public void Set(Alive alive)
        {
            _tileEntity.Set(alive);

            _alives[alive.GetLocationIndex()] = alive;
        }
        public void Set(Environ environment)
        {
            _tileEntity.Set(environment);
        }

        public void SetPlayer(Alive alive)
        {
            if (_player == null)
            {
                _tileEntity.Set(alive);
            }
            else
            {
                _tileEntity.RemoveAlive(_player.GetLocationIndex());
                _tileEntity.Set(alive);
            }
            _player = alive;
        }

        public Alive GetPlayer()
        {
            return _player;
        }

        public void RemoveAlive(Point p)
        {
            if (!IsAlivePossessed(p)) return;

            _tileEntity.RemoveAlive(p);
            _alives.Remove(p);
        }

        public void RemoveEnviron(Point p)
        {
            if (!IsEnvironPossessed(p)) return;

            _tileEntity.RemoveEnviron(p);
        }


        public void MoveAlive(Alive alive, Point to)
        {
            Alive copy = alive.Clone();
            copy.SetLocationIndex(to.X, to.Y);
            RemoveAlive(alive.GetLocationIndex());
            Add(copy);
        }

        public bool GetAlive(int x, int y, out Alive alive)
        {
            return _tileEntity.GetAlive(x, y, out alive);
        }

        public bool GetEnviron(int x, int y, out Environ environ)
        {
            return _tileEntity.GetEnviron(x, y, out environ);
        }

        public bool IsPossessed(Point p)
        {
            if (IsAlivePossessed(p) || IsEnvironPossessed(p))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsAlivePossessed(Point p)
        {
            return _tileEntity.IsAlivePossessed(p);
        }
        public bool IsEnvironPossessed(Point p)
        {
            return _tileEntity.IsEnvironPossessed(p);
        }

        public GameElements Clone()
        {
            CIVElements elements = new CIVElements(ref _gameDisplay);
            elements._tileEntity = _tileEntity.Clone();

            return elements;
        }

        public void Draw()
        {
            _tileEntity.Draw();
        }

        public void Paint()
        {
            _tileEntity.Paint();
        }

        public void Clear()
        {
            _tileEntity.Clear();
        }

        public void Save(string filename)
        {
            _tileEntity.Save(filename);
        }

        public List<Alive> GetAllAlive()
        {
            List<Alive> res = new List<Alive>();
            foreach (KeyValuePair<Point, Alive> pair in _alives)
            {
                res.Add(pair.Value);
            }

            return res;
        }

//         public List<Point> GetAliveIndexes()
//         {
//             return _tileEntity.GetAliveIndexes();
//         }
    }
}
