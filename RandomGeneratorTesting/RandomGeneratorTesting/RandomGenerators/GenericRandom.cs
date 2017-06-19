using System;

namespace RandomGeneratorTesting.RandomGenerators
{
    public class GenericRandom : RandomGenerator
    {
        private Random myImpl = new Random();

        private static GenericRandom singleton;

        public static GenericRandom Singleton
        {
            get { return singleton ?? (singleton = new GenericRandom()); }
        }

        protected GenericRandom() { }

        public override float GenerateFloat()
        {
            return (float)myImpl.NextDouble();
        }

        public override ulong GenerateUlong()
        {
            var bytes = new byte[sizeof(ulong)];
            myImpl.NextBytes(bytes);
            return
                (ulong)bytes[0] << 56 |
                (ulong)bytes[1] << 48 |
                (ulong)bytes[2] << 40 |
                (ulong)bytes[3] << 32 |
                (ulong)bytes[4] << 24 | 
                (ulong)bytes[5] << 16 | 
                (ulong)bytes[6] << 8 | 
                bytes[7];
        }

        public override void Seed(ulong seed)
        {
            myImpl = new Random((int)seed);
        }

        public override string Name { get; } = "C# generic generator";
    }
}
