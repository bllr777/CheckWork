using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.Lottery.Common
{
    public class BrokenRuleCollection : Collection<BrokenRule>
    {
        /// <summary>
        /// Creates a new Broken Rule instance and adds it to the inner list
        /// </summary>
        /// <param name="message"></param>
        public void Add(string message)
        {
            Add(new BrokenRule(string.Empty, message));
        }
        /// <summary>
        /// Creates a new Broken Rule instance and adds it to the inner list
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="message"></param>
        public void Add(string propertyName, string message)
        {
            Add(new BrokenRule(propertyName, message));
        }
    }
}
