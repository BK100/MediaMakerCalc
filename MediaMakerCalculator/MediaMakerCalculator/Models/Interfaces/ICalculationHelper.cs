using MediaMakerCalculator.Models.Enums;

namespace MediaMakerCalculator.Models.Interfaces
{
    public interface ICalculationHelper
    {
        public float Add(IEnumerable<float> valuesToCalculate);
        public float Subtract(IEnumerable<float> valuesToCalculate);
        public float Multiply(IEnumerable<float> valuesToCalculate);
        public float Divide(IEnumerable<float> valuesToCalculate);
        public float MixedCalculation(IEnumerable<MixedCalculationContainer> containers);
    }
}
