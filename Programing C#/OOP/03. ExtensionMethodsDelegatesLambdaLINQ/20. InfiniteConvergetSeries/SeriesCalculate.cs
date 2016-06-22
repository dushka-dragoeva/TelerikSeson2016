namespace InfiniteConvergetSeries
{
    using System;

    public static class SeriesCalculate
    {
        public delegate decimal DenominatorFormula(ulong n); // will hold the formula for the n-th member of the series

        public delegate decimal CalculateError(decimal partialSum); // will hold the formula for the error of the n-th partial sum of the series

        /// METHODS
        /// take a formula for the next member of the series, a formula for the error and a value for the precision
        public static decimal Calculate(DenominatorFormula formula, CalculateError error, decimal prescision = (decimal)0.001)
        {
            ulong n = 0; /// start from the zero member
            decimal sum = 0;

            /// while the error is greater than we want it to be
            while (error(sum) > prescision) 
            {
                sum += formula(n++); /// add the next member according to the formula we passes to it

                Console.WriteLine(sum);
            }

            return sum;
        }
    }
}
