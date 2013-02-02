using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Nancy;

namespace AmandaWS
{
    public class Amanda : NancyModule
    {
        public List<EndpointBuilder> builders;

        public string RootRoute { get; set; }

        public Amanda()
        {
            RootRoute = "/api";
            builders = new List<EndpointBuilder>();

            Get["tidada"] = o => true;
        }


        public EndpointBuilder Exposes(Action method)
        {
            var builder = new EndpointBuilder()
                              {
                                  Verb = "Get",
                                  Route = "/" + method.Method.Name,
                                  Action = _ =>
                                               {
                                                   method();
                                                   return HttpStatusCode.OK;
                                               }
                              };

            builders.Add(builder);

            return builder;
        }
      
        public void Exposes(Action<dynamic> method)
        {
        }

        public void Start()
        {
            foreach (var builder in builders)
            {
                builder.Route = RootRoute + builder.Route;

                var routeBuilder = this.GetType().GetProperty(builder.Verb).GetValue(this, null) as RouteBuilder;
                routeBuilder[builder.Route] = builder.Action;
            }
        }

        public void Start(string rootRoute)
        {
            RootRoute = rootRoute;
            Start();
        }
    }
}
