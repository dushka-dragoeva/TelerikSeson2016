using System.Linq;

namespace VariablesDataExpressionsConstants.Statistics
{
    public class ArrayStatisticsPrinter
    {
        public void PrintStatistics(double[] arr, IPrinter printer)
        {
            var maxArrayValue = arr.Max();
            var minArrayValue = arr.Min();
            var avarageArrayValue = arr.Average();

            printer.Print($"Max value is {maxArrayValue}");
            printer.Print($"Mix value is {minArrayValue}");
            printer.Print($"Avarage value is {maxArrayValue}");
        }
    }
}
