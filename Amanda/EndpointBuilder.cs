using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Nancy.Json;

namespace Amanda
{
    /// <summary>
    /// A class that provides a fluent interface to customizing how methods are exposed
    /// </summary>
    public class EndpointBuilder
    {
        /// <summary>
        /// The method associated with the endpoint
        /// </summary>
        internal MulticastDelegate Method { get; set; }

        /// <summary>
        /// The route associated with the endpoint
        /// </summary>
        internal string Route { get; set; }

        /// <summary>
        /// The action, or route handler, assoicated with the endpoint
        /// </summary>
        internal Func<dynamic, dynamic> Action { get; set; }

        /// <summary>
        /// The berb associated with the endpoint
        /// </summary>
        internal Verb Verb { get; set; }

        /// <summary>
        /// The module associated with the endpoint
        /// </summary>
        internal AmandaModule Module { get; set; }

        /// <summary>
        /// Changes the route on which the endpoint is ran
        /// </summary>
        /// <param name="route">The route to run the endpoint on</param>
        /// <returns>The EndpointBuilder the method was ran on</returns>
        public EndpointBuilder WithRoute(string route)
        {
            Route = route;

            return this;
        }

        /// <summary>
        /// Changes the verb the endpoint is ran with
        /// </summary>
        /// <param name="verb">The verb to run the endpoint with</param>
        /// <returns>The EndpointBuilder the method was ran on</returns>
        public EndpointBuilder WithVerb(Verb verb)
        {
            if (verb == Verb.Get && !Method.Method.GetParameters().All(p => p.ParameterType.IsBasic()))
            {
                throw new ArgumentException("Methods with complex parameters can't be exposed with the GET verb.");
            }

            Verb = verb;

            return this;
        }

        /// <summary>
        /// Defines a blacklist for one of the complex parameters associated with the edpoint method
        /// </summary>
        /// <typeparam name="T">The type of the complex parameters who's properties we want to blacklist</typeparam>
        /// <param name="props">The properties on the type T to blacklist</param>
        /// <returns>The EndpointBuilder the method was ran on</returns>
        public EndpointBuilder WithBlakcList<T>(params string[] props)
        {
            Module.Before.AddItemToStartOfPipeline(ctx =>
                                                       {
                                                           if (!ctx.Request.Path.Contains(Route))
                                                           {
                                                               return null;
                                                           }

                                                           string s = Module.ReWrittenBody ?? ctx.Request.Body.AsString();

                                                           if (s.Length > 0)
                                                           {
                                                               var jss = new JavaScriptSerializer();

                                                               var ds = jss.Deserialize<dynamic>(s);

                                                               // Selects the parameters on the method which are of the type T
                                                               var parameters = from mp in Method.Method.GetParameters()
                                                                                where mp.ParameterType == typeof (T)
                                                                                select mp;

                                                               // Transforms the paramaters of the method to their associated values in the deserialized body
                                                               var ls =
                                                                   parameters.Select(parameter => ds[parameter.Name]);

                                                               // Sets the bllacklisted properties to their default value, ignoring the
                                                               // value passed in
                                                               foreach (var elem in ls)
                                                               {
                                                                   foreach (var prop in props)
                                                                   {
                                                                       elem[prop] =
                                                                           ((Type) elem[prop].GetType()).Default();
                                                                   }
                                                               }

                                                               this.Module.ReWrittenBody = jss.Serialize(ds);
                                                           }

                                                           return null;
                                                       });

            return this;
        }
    }
}
