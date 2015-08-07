using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.Lottery.Common
{
   public class BrokenRule
    {
       /// <summary>
       /// Constructor to initialize new instance of BrokenRule class
       /// </summary>
       /// <param name="propertyName">The name of the property that caused the rule to be broken</param>
       /// <param name="message">Error message that should be associcated with the broken rule</param>
       public BrokenRule(string propertyName, string message)
       {
           this.PropertyName = propertyName;
           this.Message = message;
       }
       public string PropertyName { get; set; }
       public string Message { get; set; }
    }
}
