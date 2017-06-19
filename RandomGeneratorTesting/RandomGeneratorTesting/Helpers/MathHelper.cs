namespace RandomGeneratorTesting.Helpers
{
    public static class MathHelper
    {
        public static decimal Sqrt(decimal x, decimal? guess = null)
        {
            while (true)
            {
                var ourGuess = guess.GetValueOrDefault(x / 2m);
                var result = x / ourGuess;
                var average = (ourGuess + result) / 2m;

                if (average == ourGuess) return average;
                guess = average;
            }
        }

        public static decimal Pow(decimal number, ulong power)
        {
            switch (power)
            {
                case 0:
                    return 1;
                case 1:
                    return number;
                default:
                    return Pow(number, power / 2) * Pow(number, power / 2) * ((power | 1UL) > 0 ? number : 1);
            }
        }

        public static decimal Factorial(ulong number)
        {
            if (number == 0) return 1m;
            var ret = 1UL;
            for (var i = 1UL; i <= number; i++) ret *= i;
            return ret;
        }

        public static bool CalculateParityBit(ulong number)
        {
            var mask = 1UL;
            var ret = false;
            while (mask != 0)
            {
                if ((mask & number) > 0)
                {
                    ret = !ret;
                }

                mask <<= 1;
            }

            return ret;
        }
    }
}
