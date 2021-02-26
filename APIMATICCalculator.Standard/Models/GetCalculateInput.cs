using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using APIMATICCalculator.Standard;
using APIMATICCalculator.Standard.Utilities;


namespace APIMATICCalculator.Standard.Models
{
    public class GetCalculateInput : BaseModel 
    {
        // These fields hold the values for the public properties.
        private Models.OperationTypeEnum operation;
        private double x;
        private double y;

        /// <summary>
        /// The operator to apply on the variables
        /// </summary>
        [JsonProperty("operation", ItemConverterType = typeof(StringValuedEnumConverter))]
        public Models.OperationTypeEnum Operation 
        { 
            get 
            {
                return this.operation; 
            } 
            set 
            {
                this.operation = value;
                onPropertyChanged("Operation");
            }
        }

        /// <summary>
        /// The LHS value
        /// </summary>
        [JsonProperty("x")]
        public double X 
        { 
            get 
            {
                return this.x; 
            } 
            set 
            {
                this.x = value;
                onPropertyChanged("X");
            }
        }

        /// <summary>
        /// The RHS value
        /// </summary>
        [JsonProperty("y")]
        public double Y 
        { 
            get 
            {
                return this.y; 
            } 
            set 
            {
                this.y = value;
                onPropertyChanged("Y");
            }
        }
    }
} 