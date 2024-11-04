namespace MediaMakerCalculator.Models
{
    public class CalculatorRequest
    {
        public IEnumerable<float>? Values { get; set; }

        public IEnumerable<MixedCalculationContainer>? MixedCalculationContainers { get; set; }
    }
}
