using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using APIMATICCalculator.Standard;
using APIMATICCalculator.Standard.Utilities; 
using APIMATICCalculator.Standard.Http.Client;
using APIMATICCalculator.Standard.Http.Response;
using APIMATICCalculator.Tests.Helpers;
using NUnit.Framework;
using APIMATICCalculator.Standard;
using APIMATICCalculator.Standard.Controllers;
using APIMATICCalculator.Standard.Exceptions;

namespace APIMATICCalculator.Tests
{
    [TestFixture]
    public class SimpleCalculatorControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests)
        /// </summary>
        private static SimpleCalculatorController controller;

        /// <summary>
        /// Setup test class
        /// </summary>
        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().SimpleCalculator;
        }

        /// <summary>
        /// Check if multiplication works 
        /// </summary>
        [Test]
        public async Task TestMultiply() 
        {
            // Parameters for the API call
            Standard.Models.GetCalculateInput input = new Standard.Models.GetCalculateInput();
            input.Operation = Standard.Models.OperationTypeEnumHelper.ParseString("MULTIPLY");
            input.X = 4;
            input.Y = 5;

            // Perform API call
            double result = 0;

            try
            {
                result = await controller.GetCalculateAsync(input);
            }
            catch(APIException) {};

            // Test response code
            Assert.AreEqual(200, httpCallBackHandler.Response.StatusCode,
                    "Status should be 200");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");

 
            Assert.AreEqual(
                    20, result, ASSERT_PRECISION,
                    "Response should match expected value");
        }

    }
}