using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEntity;
using CivilizationEntity;
using CivilizationEntity.HumanDecoraters;
using MessageProcess;
using Point = System.Drawing.Point;
using Messages;

namespace Evolution
{
    public class AcientTimesEvents
    {
        static GameMainArg _gameMainArg;
        static GameElements _gameElements;

        public static void EventRaising_Player(MessageSet set, Human player)
        {
            if ( _gameElements == null)
            {
                throw new ArgumentException();
            }

            FarmOrHuntEvent(set, player);
            if (IsHunter(player))
            {
                FacedWithLargePrey(set);
                Reproduction(set, player);
                
            }
            RandomMoveOfPlayer(player);
        }

        public static void EventRaising_Human(MessageSet set,List<Human> allHuman)
        {
            allHuman.ForEach(h => RandomMoveOfHuman(h));
        }

        public static void Set(GameMainArg gameMainArg)
        {
            _gameMainArg = gameMainArg;
        }

        public static void Set(GameElements gameElements)
        {
            _gameElements = gameElements;
        }

        public static TextDisplay DefaultMessage()
        {
            TextDisplay textDisplay = new TextDisplay();
            textDisplay.SetData("正在寻找食物");
            return textDisplay;
        }

        static private void RandomMoveOfPlayer(Human player)
        {
            List<Point> neighbour = GetNeighbourGrassWithNoAlive(player.GetLocationIndex());
            Point nextLoc = CommonFunctions.RandonPickFromPnts(neighbour);
            player.SetLocationIndex(nextLoc.X, nextLoc.Y);
        }

        static private void RandomMoveOfHuman(Human h)
        {
            List<Point> neighbour = GetNeighbourGrassWithNoAlive(h.GetLocationIndex());
            Point nextLoc = CommonFunctions.RandonPickFromPnts(neighbour);

            _gameElements.MoveAlive(h, nextLoc);
        }

        static private void Reproduction(MessageSet set, Human player)
        {
            double p = 0.1;
            if (!RandomGenerator.Bool(p))
            {
                return;
            }

            List<Point> validNeighbour = GetNeighbourGrassWithNoAlive(player.GetLocationIndex());
            if (validNeighbour.Count == 0)
            {
                return;
            }

            Point randLoc = CommonFunctions.RandonPickFromPnts(validNeighbour);
            Hunter newHunter = new Hunter(new Human(randLoc), _gameMainArg.Round);
            newHunter.Population = player.Population / 2;
            _gameElements.Add(newHunter);
        }

        static private List<Point> GetNeighbourGrassWithNoAlive(Point myPoint)
        {
            List<Point> res = new List<Point>();

            List<Point> neighbour = CommonFunctions.GetNeighbourIndex(myPoint);
            neighbour.ForEach(p =>
            {
                Environ environ = null;
                if (_gameElements.GetEnviron(p.X, p.Y, out environ))
                {
                    if (environ.GetElementType() == Element.Grass && !_gameElements.IsAlivePossessed(p))
                    {
                        res.Add(p);
                    }
                }
            });

            return res;
        }

        static private void FarmOrHuntEvent(MessageSet set, Human player)
        {
            if (_gameMainArg.Round == 5)
            {
                set.Add(OptionSelectFactory.Create(SelectEvent.FarmOrHunt));
                return;
            }

            long deltaRound = GetMyStartRound(player) - _gameMainArg.Round;
            long eventIntervalRound = 30;
            if (deltaRound >= eventIntervalRound)
            {
                set.Add(OptionSelectFactory.Create(SelectEvent.FarmOrHunt));
                return;
            }

        }

        static private void FacedWithLargePrey(MessageSet set)
        {
            double p = 0.1;
            if (RandomGenerator.Bool(p))
            {
                set.Add(OptionSelectFactory.Create(SelectEvent.FacingLargePrey));
            }
        }

        static private bool IsHunter(Human human)
        {
            Hunter h = human as Hunter;
            if (h != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static private long GetMyStartRound(Human player)
        {
            if (IsHunter(player))
            {
                Hunter hunter = player as Hunter;
                return hunter.StartRound;
            }
            else
            {
                return 0;
            }
        }
    }
}
