using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEntity
{
    public class RandomGenerator
    {
        /// <summary>
        /// Get true or false according to pTrue
        /// </summary>
        /// <param name="pTrue">Chance to Get True</param>
        /// <returns></returns>
        public static bool Bool(double pTrue)
        {
            if (pTrue > 1 || pTrue < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Random ran = new Random();
            if (ran.NextDouble() <= pTrue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
