using System;
using APIMATICCalculator.Standard.Controllers;
using APIMATICCalculator.Standard.Http.Client;
using APIMATICCalculator.Standard.Utilities;

namespace APIMATICCalculator.Standard
{
    public partial class APIMATICCalculatorClient
    {

        /// <summary>
        /// Singleton access to SimpleCalculator controller
        /// </summary>
        public SimpleCalculatorController SimpleCalculator
        {
            get
            {
                return SimpleCalculatorController.Instance;
            }
        }
        /// <summary>
        /// The shared http client to use for all API calls
        /// </summary>
        public IHttpClient SharedHttpClient
        {
            get
            {
                return BaseController.ClientInstance;
            }
            set
            {
                BaseController.ClientInstance = value;
            }        
        }
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public APIMATICCalculatorClient() { }
        #endregion
    }
}