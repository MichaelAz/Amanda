using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmandaWS
{
    public class EndpointBuilder
    {
        public MulticastDelegate Method { get; set; }
        public string Route { get; set; }
        public Func<dynamic, dynamic> Action { get; set; }
        public Verb Verb { get; set; }

        public EndpointBuilder WithRoute(string route)
        {
            Route = route;

            return this;
        }
        
        public EndpointBuilder WithVerb(Verb verb)
        {
            if (verb == Verb.Get && !Method.Method.GetParameters().All(p => p.ParameterType.IsBasic()))
            {
                throw new ArgumentException("Methods with complex parameters can't be exposed with the GET verb.");
            }

            Verb = verb;

            return this;
        }

        //public EndpointBuilder WithoutParameters(params string[] parameters)
        //{
            
        //}
    }
}
