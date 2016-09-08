using System.Text;
using Abstraction.Contracts;

namespace Abstraction
{
    public abstract class Figure : IFigure
    {
        public abstract double CalcPerimeter();

        public abstract double CalcSurface();

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append($"I am a {this.GetType().Name.ToLower()}.")
                .Append($" My perimeter is {this.CalcPerimeter():f2}.")
                .Append($" My surface is {this.CalcSurface():f2}.");
            return output.ToString();
        }
    }
}
