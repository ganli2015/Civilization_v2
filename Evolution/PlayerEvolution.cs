using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GameEntity;
using CivilizationEntity;
using Messages;
using MessageProcess;

namespace Evolution
{
    public class PlayerEvolution
    {
        static GameMainArg _gameMainArg;
        static GameElements _gameElements;

        static public MessageSet Evolve(GameElements gameElements,GameMainArg gameMainArg)
        {
            InitParam(gameElements, gameMainArg);
            MessageSet resMes = new MessageSet();

            Human player = QueryEntity.GetHumanPlayerClone();
            if (Dead(player))
            {
                return new MessageSet();
            }

            EventRaising(resMes, player);
            PlayerStateEvents(resMes, player);

            gameElements.SetPlayer(player);

            return resMes;
        }

        static private bool Dead(Human player)
        {
            if (player.Population <= 0)
            {
                _gameElements.RemoveAlive(player.GetLocationIndex());
                return true;
            }
            else
            {
                return false;
            }
        }

        static private void InitParam(GameElements gameElements, GameMainArg gameMainArg)
        {
            _gameMainArg = gameMainArg;
            _gameElements = gameElements;
            QueryEntity.GameEntity = gameElements;
        }

        

        static private void EventRaising(MessageSet set,Human player)
        {
            AcientTimesEvents.Set(_gameElements);
            AcientTimesEvents.Set(_gameMainArg);
            AcientTimesEvents.EventRaising_Player(set, player);

        }

        static private void PlayerStateEvents(MessageSet set, Human player)
        {
            MessageSet playerMessages = player.Update();

            if (playerMessages.Empty())
            {
                AddDefaultMessage(set);
            }
            else
            {
                set.Add(playerMessages);
            }
        }

        static private void AddDefaultMessage(MessageSet set)
        {
            set.Add(AcientTimesEvents.DefaultMessage());
        }
    }
}
