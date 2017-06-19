using System;

namespace RandomGeneratorTesting.RandomGenerators
{
    public class MersenneTwister : RandomGenerator
    {
        private Implementations.MersenneTwister myImpl = new Implementations.MersenneTwister((ulong)DateTime.Now.Ticks);

        private static MersenneTwister singleton;

        public static MersenneTwister Singleton
        {
            get { return singleton ?? (singleton = new MersenneTwister()); }
        }

        protected MersenneTwister() { }

        public override void Seed(ulong seed)
        {
            myImpl = new Implementations.MersenneTwister(seed);
        }

        public override ulong GenerateUlong()
        {
            return myImpl.genrand_uint32() << 32 | myImpl.genrand_uint32();
        }

        public override float GenerateFloat()
        {
            return (float)myImpl.genrand_real2();
        }

        public override string Name { get; } = "Mersenne Twister";
    }
}
