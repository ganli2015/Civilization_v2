using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEntity;
using CivilizationEntity;
using CivilizationEntity.HumanDecoraters;
using Messages;

namespace Evolution
{
    class OptionSelectResponse
    {
        public static MessageSet Evolve(GameElements gameElements, OptionSelectData data, GameMainArg e)
        {
            if (data == null)
            {
                return new MessageSet();
            }

            QueryEntity.GameEntity = gameElements;

            MessageSet res = new MessageSet();
            switch (data.MyEvent)
            {
                case SelectEvent.FarmOrHunt:
                    {
                        res.Add(FarmOrHuntEvent(gameElements, data.Selected, e));
                        break;
                    }
                case SelectEvent.FacingLargePrey:
                    {
                        res.Add(FacingLargePreyEvent(gameElements, data.Selected, e));
                        break;
                    }
            }

            return res;
        }

        private static MessageSet FarmOrHuntEvent(GameElements gameElements, string selected, GameMainArg e)
        {
            Human player = QueryEntity.GetHumanPlayerClone();

            if (selected == "打猎")
            {
                Hunter hunter = new Hunter(player,e.Round);
                gameElements.SetPlayer(hunter);
            }
            else if (selected == "种田")
            {

            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            return new MessageSet();
        }

        private static MessageSet FacingLargePreyEvent(GameElements gameElements, string selected, GameMainArg e)
        {
            Human player = QueryEntity.GetHumanPlayerClone();
            Hunter hunter = player as Hunter;
            if (hunter == null)
            {
                return new MessageSet();
            }

            MessageSet res = FacingLargePreyEvent_CheckSelection(selected, hunter);

            gameElements.SetPlayer(hunter);

            return res;
        }


        private static MessageSet FacingLargePreyEvent_CheckSelection(string selected,Hunter hunter)
        {
            MessageSet res = new MessageSet();
            if (selected == "战斗")
            {
                FacingLargePreyEvent_Battle(res, hunter);
            }
            else if (selected == "逃跑")
            {
                FacingLargePreyEvent_Runaway(res, hunter);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            return res;
        }

        private static void FacingLargePreyEvent_Runaway(MessageSet res, Hunter hunter)
        {
            double pLose = 0.1;
            if (RandomGenerator.Bool(pLose))
            {
                LoseHuntBattle(res, hunter);
            }
        }

        private static void FacingLargePreyEvent_Battle(MessageSet res, Hunter hunter)
        {
            double pWin = 0.5;
            if (RandomGenerator.Bool(pWin))
            {
                WinHuntBattle(res, hunter);
            }
            else
            {
                LoseHuntBattle(res, hunter);
            }      
        }

        private static void WinHuntBattle(MessageSet res,Hunter hunter)
        {
            hunter.IncreaseHuntAbility();
            res.Add(TextDisplay.Create("击败了猎物，提升了获取食物的能力"));
        }

        private static void LoseHuntBattle(MessageSet res, Hunter hunter)
        {
            hunter.Population /= 2;
            res.Add(TextDisplay.Create("人们被猎物冲散了"));
        }
    }
}
