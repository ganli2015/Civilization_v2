using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GameEntity;

namespace CivilizationEntity
{
    public class Tile
    {
        Alive _alive;
        Environ _environ;

        List<Tile> _neighbours;

        public Tile()
        {

        }

        public Alive GetAlive()
        {
            return _alive;
        }

        public void SetAlive(Alive alive)
        {
            _alive = alive;
            if(_environ==null)
            {
                _alive.SetEnviron(Element.None);
            }
            else
            {
                _alive.SetEnviron(_environ.GetElementType());
            }
        }

        public bool IsAlivePossessed()
        {
            if (_alive == null)
            {
                return false;
            }
            else
                return true;
        }

        public Environ GetEnviron()
        {
            return _environ;
        }

        public void SetEnviron(Environ environ)
        {
            _environ = environ;
        }

        public bool IsEnvironPossessed()
        {
            if (_environ == null)
            {
                return false;
            }
            else
                return true;
        }

        public void RemoveAlive()
        {
            _alive = null;
        }

        public void RemoveEnviron()
        {
            _environ = null;
        }

        public void SetNeighbours(List<Tile> tiles)
        {
            _neighbours = tiles;
        }

        public void Draw()
        {
            if (_environ != null)
                _environ.Draw();

            if (_alive != null)
                _alive.Draw();

        }

        public void Paint()
        {
            if (_environ != null)
                _environ.Paint();

            if (_alive != null)
                _alive.Paint();

        }

        public Tile Clone()
        {
            Tile tile = new Tile();
            if(_alive!=null)
                tile._alive = _alive.Clone();
            if(_environ!=null)
                tile._environ = _environ.Clone();

            return tile;
        }

        public void Save(string filename)
        {

            if(_alive!=null)
                _alive.Save(filename);

            if(_environ!=null)
                _environ.Save(filename);
        }
        
    }
}
