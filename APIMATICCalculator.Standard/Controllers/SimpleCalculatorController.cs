using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using APIMATICCalculator.Standard;
using APIMATICCalculator.Standard.Utilities;
using APIMATICCalculator.Standard.Http.Request;
using APIMATICCalculator.Standard.Http.Response;
using APIMATICCalculator.Standard.Http.Client;
using APIMATICCalculator.Standard.Exceptions;

namespace APIMATICCalculator.Standard.Controllers
{
    public partial class SimpleCalculatorController: BaseController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static SimpleCalculatorController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static SimpleCalculatorController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new SimpleCalculatorController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// Calculates the expression using the specified operation.
        /// </summary>
        /// <param name="Models.GetCalculateInput">Object containing request parameters</param>
        /// <return>Returns the double response from the API call</return>
        public double GetCalculate(Models.GetCalculateInput input)
        {
            Task<double> t = GetCalculateAsync(input);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Calculates the expression using the specified operation.
        /// </summary>
        /// <param name="Models.GetCalculateInput">Object containing request parameters</param>
        /// <return>Returns the double response from the API call</return>
        public async Task<double> GetCalculateAsync(Models.GetCalculateInput input)
        {
            //the base uri for api requests
            string _baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/{operation}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "operation", Models.OperationTypeEnumHelper.ToValue(input.Operation) }
            });

            //process optional query parameters
            APIHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "x", input.X },
                { "y", input.Y }
            },ArrayDeserializationFormat,ParameterSeparator);


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);
            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return double.Parse(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

    }
} 