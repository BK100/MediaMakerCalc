using MediaMakerCalculator.Models.Enums;

namespace MediaMakerCalculator.Models.Interfaces
{
    public interface ICalculationHelper
    {
        public CalculatorResponse Add(IEnumerable<float> valuesToCalculate);
        public CalculatorResponse Subtract(IEnumerable<float> valuesToCalculate);
        public CalculatorResponse Multiply(IEnumerable<float> valuesToCalculate);
        public CalculatorResponse Divide(IEnumerable<float> valuesToCalculate);
        public CalculatorResponse MixedCalculation(IEnumerable<MixedCalculationContainer> containers);
    }
}
