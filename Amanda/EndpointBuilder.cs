using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;
using Nancy.IO;

namespace Amanda
{
    public class EndpointBuilder
    {
        internal MulticastDelegate Method { get; set; }
        internal string Route { get; set; }
        internal Func<dynamic, dynamic> Action { get; set; }
        internal Verb Verb { get; set; }
        internal AmandaModule Module { get; set; }

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

        public EndpointBuilder WithBlakcList<T>(params string[] props)
        {
            Module.Before.AddItemToStartOfPipeline(ctx =>
                                                       {
                                                           string s = ctx.Request.Body.AsString();

                                                           if (s.Length > 0)
                                                           {
                                                               var jss = new JavaScriptSerializer();

                                                               var ds = jss.Deserialize<dynamic>(s);

                                                               var parameters = from mp in Method.Method.GetParameters()
                                                                                where mp.ParameterType == typeof (T)
                                                                                select mp;

                                                               var ls =
                                                                   parameters.Select(parameter => ds[parameter.Name]);

                                                               foreach (var elem in ls)
                                                               {
                                                                   foreach (var prop in props)
                                                                   {
                                                                       elem[prop] =
                                                                           ((Type) elem[prop].GetType()).Default();
                                                                   }
                                                               }

                                                               this.Module.ReWrittenBody = jss.Serialize(ds);

                                                               //var ser = ls.Select(param => jss.Serialize(param));
                                                               //var deser = ser.Select(sers => jss.Deserialize<T>(sers)).Cast<T>();

                                                               //var elems = new List<T>();

                                                               //foreach (var prop in props)
                                                               //{
                                                               //    foreach (var elem in deser)
                                                               //    {
                                                               //        var locProp = elem.GetType().GetProperty(prop);
                                                               //        locProp.SetValue(elem, locProp.PropertyType.Default(), null);

                                                               //        elems.Add(elem);
                                                               //    }
                                                               //}
                                                           }

                                                           //ctx.Request.Body.Flush();
                                                           //ctx.Request.Body.Write(
                                                           //    Encoding.Unicode.GetBytes(s.ToArray()), 0,
                                                           //    Encoding.Unicode.GetBytes(s.ToArray()).Count());

                                                           //var ss = ctx.Request.Body.AsString();
                                                           return null;
                                                       });

            return this;
        }
    }
}
