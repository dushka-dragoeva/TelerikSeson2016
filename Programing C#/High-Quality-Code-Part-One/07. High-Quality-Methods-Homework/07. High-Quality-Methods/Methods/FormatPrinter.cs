namespace Methods
{
    internal class FormatPrinter
    {
        internal string PrintWithPrecisionTowDigit(double number)
        {
            return $"{number:f2}";
        }

        internal string PrintAsPercentage(double number)
        {
            return $"{number:p0}";
        }

        internal string PrintAlignedRight(double number)
        {
            return $"{number,8}";
        }
    }
}
