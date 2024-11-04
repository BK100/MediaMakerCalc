using MediaMakerCalculator.Models;
using MediaMakerCalculator.Models.Enums;
using MediaMakerCalculator.Models.Interfaces;

namespace MediaMakerCalculator.Helpers
{
    public class CalculationHelper : ICalculationHelper
    {

        public float Add(IEnumerable<float> valuesToCalculate)
        {
            var valueList = valuesToCalculate.ToList();
            var result = valueList.First();
            valueList.Remove(result);

            foreach (float value in valueList)
            {
                result = AddCalc(result, value);
            }

            return result;
        }

        public float Subtract(IEnumerable<float> valuesToCalculate)
        {
            var valueList = valuesToCalculate.ToList();
            var result = valueList.First();
            valueList.Remove(result);

            foreach (float value in valueList)
            {
                result = SubtractCalc(result, value);
            }

            return result;
        }

        public float Multiply(IEnumerable<float> valuesToCalculate)
        {
            var valueList = valuesToCalculate.ToList();
            var result = valueList.First();
            valueList.Remove(result);

            foreach (float value in valueList)
            {
                result = MultiplyCalc(result, value);
            }

            return result;
        }

        public float Divide(IEnumerable<float> valuesToCalculate)
        {
            var valueList = valuesToCalculate.ToList();
            var result = valueList.First();
            valueList.Remove(result);

            foreach (float value in valueList)
            {
                result = DivideCalc(result, value);
            }

            return result;
        }

        public float MixedCalculation(IEnumerable<MixedCalculationContainer> containers)
        {
            var result = containers.First().Value;

            for (int x = 0; x < containers.Count() - 1; x++)
            {
                switch (containers.ElementAt(x).Operator)
                {
                    case Operator.Add:
                        result = AddCalc(result, containers.ElementAt(x + 1).Value);
                        break;
                    case Operator.Subtract:
                        result = SubtractCalc(result, containers.ElementAt(x + 1).Value);
                        break;
                    case Operator.Multiply:
                        result = MultiplyCalc(result, containers.ElementAt(x + 1).Value);
                        break;
                    case Operator.Divide:
                        result = DivideCalc(result, containers.ElementAt(x + 1).Value);
                        break;
                    default:
                        throw new Exception($"MMC007: Mixed calculation error - null or erroneous operator value detected at index {x}");
                }
            }

            return result;
        }

        private Func<float, float, float> AddCalc = (x, y) => x + y;

        private Func<float, float, float> SubtractCalc = (x, y) => x - y;

        private Func<float, float, float> MultiplyCalc = (x, y) => x * y;

        private Func<float, float, float> DivideCalc = (x, y) => x / y;
    }
}
