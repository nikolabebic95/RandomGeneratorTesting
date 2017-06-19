using System;
using RandomGeneratorTesting.Helpers;

namespace RandomGeneratorTesting.RandomGenerators
{
    public class BlumBlumShub : RandomGenerator
    {
        private const ulong M = 113888353;
        private ulong element = (ulong)DateTime.Now.Ticks;

        private static BlumBlumShub singleton;

        public static BlumBlumShub Singleton
        {
            get { return singleton ?? (singleton = new BlumBlumShub()); }
        }

        protected BlumBlumShub() { }


        public override void Seed(ulong seed)
        {
            element = seed % M;
            if (element <= 1) element = 2;
        }

        public override ulong GenerateUlong()
        {
            var ret = 0UL;
            var mask = 1UL;

            while (mask > 0)
            {
                if (GetNextBit())
                {
                    ret |= mask;
                }

                mask <<= 1;
            }

            return ret;
        }

        public override float GenerateFloat()
        {
            return GenerateUlong() / ((float)ulong.MaxValue + 1);
        }

        public override string Name { get; } = "Blum Blum Shub";

        private bool GetNextBit()
        {
            element *= element;
            element %= M;
            return MathHelper.CalculateParityBit(element);
        }
    }
}
