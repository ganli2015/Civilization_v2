using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEntity;
using System.Drawing;
using Messages;

namespace CivilizationEntity.HumanDecoraters
{
    public class Hunter:HumanDecorater
    {
        /// <summary>
        /// Chance for successful hunting
        /// </summary>
        private double pHunt { get; set; }
        private int foodPerHunt { get; set; }

        public Hunter(Human human, long startRound)
            : base(human, startRound)
        {
            pHunt = 0.3;
            foodPerHunt = 1;
        }

        override public MessageSet Update()
        {
            MessageSet res = new MessageSet();

            if (RandomGenerator.Bool(pHunt))
            {
                Population+=foodPerHunt;

                TextDisplay textDisplay = new TextDisplay();
                textDisplay.SetData("捕捉到猎物");
                res.Add(textDisplay);
            }

            res.Add(base.Update());

            return res;
        }

        override public Alive Clone()
        {
            Hunter copy = new Hunter(_human.Clone() as Human,StartRound);
            copy.pHunt = pHunt;
            copy.foodPerHunt=foodPerHunt;

            return copy;
        }

        public void IncreaseHuntAbility()
        {
            foodPerHunt++;
        }
    }
}
