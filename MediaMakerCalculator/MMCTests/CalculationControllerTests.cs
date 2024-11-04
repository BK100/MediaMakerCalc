using MediaMakerCalculator.Controllers;
using MediaMakerCalculator.Data;
using MediaMakerCalculator.Helpers;
using MediaMakerCalculator.Models;
using MediaMakerCalculator.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace MMCTests
{
    public class Tests
    {
        private CalculationController _controller;

        [SetUp]
        public void Setup()
        {
            var mockLogger = new Mock<LogHelper>();
            var calcHelper = new CalculationHelper();
            var options = new DbContextOptionsBuilder<LoggingDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            var context = new LoggingDbContext(options);
            _controller = new CalculationController(calcHelper, mockLogger.Object, context);
        }

        [Test]
        [TestCase(5, 10, 15)]
        [TestCase(5, 5, 10)]
        [TestCase(0, 0, 0)]
        [TestCase(5, -10, -5)]
        public void AddNumbers_Success(float value1, float value2, float returnResult)
        {
            var result = _controller.Add(new CalculatorRequest()
            {
                Values = new List<float>()
            {
                value1, value2
            }
            });
            Assert.That(result == "{\"Result\":" + returnResult.ToString() + "}");
        }

        [Test]
        [TestCase(5, 10, -5)]
        [TestCase(5, 5, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(5, -10, 15)]
        public void SubtractNumbers_Success(float value1, float value2, float returnResult)
        {
            var result = _controller.Subtract(new CalculatorRequest()
            {
                Values = new List<float>()
            {
                value1, value2
            }
            });
            Assert.That(result == "{\"Result\":" + returnResult.ToString() + "}");
        }

        [Test]
        [TestCase(5, 10, 50)]
        [TestCase(5, 5, 25)]
        [TestCase(0, 0, 0)]
        [TestCase(5, -10, -50)]
        public void Multiply_Success(float value1, float value2, float returnResult)
        {
            var result = _controller.Multiply(new CalculatorRequest()
            {
                Values = new List<float>()
            {
                value1, value2
            }
            });
            Assert.That(result == "{\"Result\":" + returnResult.ToString() + "}");
        }

        [Test]
        [TestCase(5, 2, 2.5f)]
        [TestCase(5, 5, 1)]
        [TestCase(10, 2, 5)]
        [TestCase(50, 10, 5)]
        public void Divide_Success(float value1, float value2, float returnResult)
        {
            var result = _controller.Divide(new CalculatorRequest()
            {
                Values = new List<float>()
            {
                value1, value2
            }
            });
            Assert.That(result == "{\"Result\":" + returnResult.ToString() + "}");
        }

        [Test]
        [TestCase(50, 50, 10, 90)]
        [TestCase(1000, 2000, 1000, 2000)]
        public void MixedCalc_Success(float value1, float value2, float value3, float returnResult)
        {
            var request = new List<MixedCalculationContainer>()
            {
                new MixedCalculationContainer()
                {
                    Value = value1,
                    Operator = Operator.Add
                },
                new MixedCalculationContainer()
                {
                    Value = value2,
                    Operator = Operator.Subtract
                },
                new MixedCalculationContainer()
                {
                    Value = value3
                }
            };

            var result = _controller.MixedCalculation(request);
            Assert.That(result == "{\"Result\":" + returnResult.ToString() + "}");
        }

        [Test]
        public void MixedCalc_Fail()
        {
            var request = new List<MixedCalculationContainer>()
            {
                new MixedCalculationContainer()
                {
                    Value = 50,
                },
                new MixedCalculationContainer()
                {
                    Value = 50
                }
            };
            Assert.Throws<Exception>(() => _controller.MixedCalculation(request));
        }
    }
}