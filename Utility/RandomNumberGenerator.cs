using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayLightMachineController.Utility
{
    internal class RandomNumberGenerator
    {
        int oldReturnValForRandom;

        public RandomNumberGenerator()
        {
            oldReturnValForRandom = -1;
        }

        public int RandomNumber(int min, int max)
        {
            long ticks = DateTime.Now.Ticks;
            if (ticks > Int32.MaxValue)
            {
                ticks = ticks % Int32.MaxValue;
            }
            Random random = new Random((int)ticks);
            int returnVal = random.Next(min, max);
            while (returnVal == oldReturnValForRandom)
            {
                returnVal = random.Next(min, max);
            }
            oldReturnValForRandom = returnVal;
            return returnVal;
        }
    }
}
