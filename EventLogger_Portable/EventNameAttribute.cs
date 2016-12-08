using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLogger
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor)]
    public class EventNameAttribute : Attribute
    {
        public EventNameAttribute(string eventName)
        {

        }
    }
}
