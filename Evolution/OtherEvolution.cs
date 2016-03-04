using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEntity;
using CivilizationEntity;
using Messages;
using MessageProcess;
using CivilizationEntity.HumanDecoraters;

namespace Evolution
{
    public class OtherEvolution
    {
        static GameMainArg _gameMainArg;
        static GameElements _gameElements;

        public static MessageSet Evolve(GameElements gameElements, GameMainArg gameMainArg)
        {
            InitParam(gameElements, gameMainArg);
            MessageSet resMes = new MessageSet();

            List<Human> allHuman = ConvertAliveToHuman(QueryEntity.GetAllAliveButPlayer());
            EventRaising(resMes,allHuman);

            return resMes;
        }

        static private void InitParam(GameElements gameElements, GameMainArg gameMainArg)
        {
            _gameMainArg = gameMainArg;
            _gameElements = gameElements;
            QueryEntity.GameEntity = gameElements;
        }

        static private void EventRaising(MessageSet set, List<Human> allHuman)
        {
            AcientTimesEvents.Set(_gameElements);
            AcientTimesEvents.Set(_gameMainArg);
            AcientTimesEvents.EventRaising_Human(set,allHuman );
        }

        static private void PlayerStateEvents(MessageSet set,List<Human> allHuman)
        {
            allHuman.ForEach(h => h.Update());
        }

        static private List<Human> ConvertAliveToHuman(List<Alive> alives)
        {
            List<Human> res = new List<Human>();
            alives.ForEach(a =>
            {
                Human h = a as Human;
                if (h != null)
                {
                    res.Add(h);
                }
            });

            return res;
        }
    }
}
