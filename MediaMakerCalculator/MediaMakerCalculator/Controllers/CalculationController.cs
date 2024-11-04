using MediaMakerCalculator.Data;
using MediaMakerCalculator.Models;
using MediaMakerCalculator.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace MediaMakerCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationController : ControllerBase
    {

        // This controller handles calculation operations - can only be accessed using a request with a valid bearer token from the credentials endpoint

        private readonly ICalculationHelper _calculationHelper;
        private readonly ILogHelper _logHelper;
        private readonly LoggingDbContext _context;

        public CalculationController(ICalculationHelper calculationHelper, ILogHelper logHelper, LoggingDbContext context)
        {
            _calculationHelper = calculationHelper;
            _logHelper = logHelper;
            _context = context;
        }

        [Authorize]
        [HttpPost]
        [Route("/Add")]
        public string Add([FromBody] CalculatorRequest request)
        {
            // Logs and executes addition requests
            if (request.Values != null && request.Values.Count() > 0)
            {
                _logHelper.LogItem($"Addition request submitted with {request.Values.Count()} values", "Information", _context);
            }
            else
            {
                _logHelper.LogItem($"Addition request submitted with null or empty values array", "Error", _context);
                throw new Exception("MMC008: Empty or null request data");
            }
            string jsonResult;
            try
            {
                jsonResult = JsonSerializer.Serialize(_calculationHelper.Add(request.Values));
            }
            catch (Exception ex)
            {
                _logHelper.LogItem($"MMC001: Addition error - {ex}", "Error", _context);
                throw new Exception("MMC001: Addition error", ex);
            }
            _logHelper.LogItem($"Addition request completed with value of {jsonResult}", "Information", _context);
            return jsonResult;
        }

        [Authorize]
        [HttpPost]
        [Route("/Subtract")]
        public string Subtract([FromBody] CalculatorRequest request)
        {
            // Logs and executes subtraction requests

            if (request.Values != null && request.Values.Count() > 0)
            {
                _logHelper.LogItem($"Subtraction request submitted with {request.Values.Count()} values", "Information", _context);
            }
            else
            {
                _logHelper.LogItem($"Subtraction request submitted with null or empty values array", "Error", _context);
                throw new Exception("MMC008: Empty or null request data");
            }

            string jsonResult;
            try
            {
                jsonResult = JsonSerializer.Serialize(_calculationHelper.Subtract(request.Values));
            }
            catch (Exception ex)
            {
                _logHelper.LogItem($"MMC002: Subtraction error - {ex}", "Error", _context);
                throw new Exception("MMC002: Subtraction error", ex);
            }
            _logHelper.LogItem($"Subtraction request completed with value of {jsonResult}", "Information", _context);
            return jsonResult;
        }

        [Authorize]
        [HttpPost]
        [Route("/Multiply")]
        public string Multiply([FromBody] CalculatorRequest request)
        {
            // Logs and executes multiplication requests

            if (request.Values != null && request.Values.Count() > 0)
            {
                _logHelper.LogItem($"Multiplication request submitted with {request.Values.Count()} values", "Information", _context);
            }
            else
            {
                _logHelper.LogItem($"Multiplication request submitted with null or empty values array", "Error", _context);
                throw new Exception("MMC008: Empty or null request data");
            }

            string jsonResult;
            try
            {
                jsonResult = JsonSerializer.Serialize(_calculationHelper.Multiply(request.Values));
            }
            catch (Exception ex)
            {
                _logHelper.LogItem($"MMC003: Multiplication error - {ex}", "Error", _context);
                throw new Exception("MMC003: Multiplication error", ex);
            }
            _logHelper.LogItem($"Multiplication request completed with value of {jsonResult}", "Information", _context);
            return jsonResult;
        }

        [Authorize]
        [HttpPost]
        [Route("/Divide")]
        public string Divide([FromBody] CalculatorRequest request)
        {
            // Logs and executes division requests

            if (request.Values != null && request.Values.Count() > 0)
            {
                _logHelper.LogItem($"Division request submitted with {request.Values.Count()} values", "Information", _context);
            }
            else
            {
                _logHelper.LogItem($"Division request submitted with null or empty values array", "Error", _context);
                throw new Exception("MMC008: Empty or null request data");
            }

            string jsonResult;
            try
            {
                jsonResult = JsonSerializer.Serialize(_calculationHelper.Divide(request.Values));
            }
            catch (Exception ex)
            {
                _logHelper.LogItem($"MMC004: Division error - {ex}", "Error", _context);
                throw new Exception("MMC004: Division error", ex);
            }
            _logHelper.LogItem($"Division request completed with value of {jsonResult}", "Information", _context);
            return jsonResult;
        }

        [Authorize]
        [HttpPost]
        [Route("/MixedCalculation")]
        public string MixedCalculation([FromBody] CalculatorRequest request)
        {
            // Logs and executes mixed calculation requests - generates the math logic using the values and operators, can be a mix of any operation

            if (request.MixedCalculationContainers != null && request.MixedCalculationContainers.Count() > 0)
            {
                _logHelper.LogItem($"Mixed calculation request submitted with {request.MixedCalculationContainers.Count()} values", "Information", _context);
            }
            else
            {
                _logHelper.LogItem($"Mixed calculation request submitted with null or empty MixedCalculationContainers array", "Error", _context);
                throw new Exception("MMC008: Empty or null request data");
            }

            string jsonResult;
            try
            {
                jsonResult = JsonSerializer.Serialize(_calculationHelper.MixedCalculation(request.MixedCalculationContainers));
            }
            catch (Exception ex)
            {
                _logHelper.LogItem($"MMC005: Mixed calculation error - {ex}", "Error", _context);
                throw new Exception("MMC005: Mixed calculation error", ex);
            }
            _logHelper.LogItem($"Mixed calculation request completed with value of {jsonResult}", "Information", _context);
            return jsonResult;
        }
    }
}
