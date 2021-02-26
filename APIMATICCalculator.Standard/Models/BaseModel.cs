
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
namespace APIMATICCalculator.Standard.Models
{
    public class BaseModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Property changed event for observer pattern
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises event when a property is changed
        /// </summary>
        /// <param name="propertyName">Name of the changed property</param>
        protected void onPropertyChanged(System.String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}