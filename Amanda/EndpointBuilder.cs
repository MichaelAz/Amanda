using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmandaWS
{
    public class EndpointBuilder
    {
        public string Route { get; set; }
        public Func<dynamic, dynamic> Action { get; set; }
        public string Verb { get; set; }

        public EndpointBuilder WithRoute(string route)
        {
            Route = route;

            return this;
        }

        public EndpointBuilder WithVerb(string verb)
        {
            Verb = verb;

            return this;
        }
    }
}
