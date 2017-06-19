using System;
using System.Collections.Generic;
using System.Numerics;

namespace RandomGeneratorTesting.RandomGenerators
{
    /// <summary>
    ///   Class representing the random number generator
    /// </summary>
    public abstract class RandomGenerator
    {
        public static IDictionary<string, RandomGenerator> Dictionary { get; } = new Dictionary<string, RandomGenerator>();

        public static void InitializeDictionary()
        {
            Add(GenericRandom.Singleton);
            Add(LinearCongruentialGenerator.Singleton);
            Add(BlumBlumShub.Singleton);
            Add(MersenneTwister.Singleton);
            Add(MiddleSquareWeyl.Singleton);
            Add(SortedIntsGenerator.Singleton);
        }

        private static void Add(RandomGenerator generator)
        {
            Dictionary.Add(generator.Name, generator);
        }
        
        /// <summary>
        ///   Seed the generator
        /// </summary>
        /// <param name="seed">
        ///   Seed for the generator
        /// </param>
        public abstract void Seed(ulong seed);

        /// <summary>
        ///   Generates an unsigned long integer [0,ulong.MaxValue]
        /// </summary>
        /// <returns>
        ///   Generated uint
        /// </returns>
        public abstract ulong GenerateUlong();

        /// <summary>
        ///   Generates a float [0,1)
        /// </summary>
        /// <returns>
        ///   Generated float
        /// </returns>
        public abstract float GenerateFloat();

        /// <summary>
        ///   Generates a 2D point with coordinates [0-1)
        /// </summary>
        /// <returns>
        ///   Generated 2D point
        /// </returns>
        public Vector2 GenerateVector2()
        {
            return new Vector2(GenerateFloat(), GenerateFloat());
        }

        /// <summary>
        ///   Generates a 3D point with coordinates [0-1)
        /// </summary>
        /// <returns>
        ///   Generated 3D point
        /// </returns>
        public Vector3 GenerateVector3()
        {
            return new Vector3(GenerateVector2(), GenerateFloat());
        }

        public abstract string Name { get; }
    }
}
