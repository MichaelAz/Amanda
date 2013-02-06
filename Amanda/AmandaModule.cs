using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;

using System.Web.Script.Serialization;
using Nancy;
using Nancy.ModelBinding;

namespace Amanda
{
    public class AmandaModule : NancyModule
    {
        public List<EndpointBuilder> builders;

        public string RootRoute { get; set; }

        internal string ReWrittenBody { get; set; }

        public AmandaModule()
        {
            RootRoute = "/api";
            builders = new List<EndpointBuilder>();
            After.AddItemToEndOfPipeline(x => x.Response.Headers.Add("Access-Control-Allow-Origin", "*"));
        }

        public EndpointBuilder Exposes(Action method)
        {
            return ExpositionHelper(method, _ =>
                                                {
                                                    method();
                                                    return HttpStatusCode.OK;
                                                });
        }

        public EndpointBuilder Exposes<T>(Action<T> method)
        {
            return ActionHelper(method);
        }

        public EndpointBuilder Exposes<T1,T2>(Action<T1,T2> method)
        {
            return ActionHelper(method);
        }

        public EndpointBuilder Exposes<T1, T2, T3>(Action<T1, T2, T3> method)
        {
            return ActionHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T>(Func<T> method)
        {
            return FuncHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T1, T2>(Func<T1, T2> method)
        {
            return FuncHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T1, T2, T3>(Func<T1, T2, T3> method)
        {
            return FuncHelper(method);
        }

        public void Start()
        {
            foreach (var builder in builders)
            {
                builder.Route = RootRoute + builder.Route;

                RouteBuilder routeBuilder = null;

                if (builder.Verb == Verb.Get)
                {
                    routeBuilder = Get;
                }
                else if(builder.Verb == Verb.Post)
                {
                    routeBuilder = Post;
                }

                routeBuilder[builder.Route] = builder.Action;
            }
        }

        public void Start(string rootRoute)
        {
            RootRoute = rootRoute;
            Start();
        }

        private EndpointBuilder ExpositionHelper(MulticastDelegate method, Func<dynamic, dynamic> action )
        {
            Verb verb = method.Method.GetParameters().All(p => p.ParameterType.IsBasic()) ? Verb.Get : Verb.Post;

            var builder = new EndpointBuilder()
            {
                Method = method,
                Verb = verb,
                Route = "/" + method.Method.Name,
                Action = action,
                Module = this
            };

            builders.Add(builder);

            return builder;
        }

        private EndpointBuilder ActionHelper(MulticastDelegate method)
        {
            return ExpositionHelper(method, _ =>
                                                {
                                                    var finalparams = ParamHelper(method);

                                                    method.Method.Invoke(method.Target, finalparams.ToArray());

                                                    return HttpStatusCode.OK;
                                                });
        }

        private EndpointBuilder FuncHelper(MulticastDelegate method)
        {
            return ExpositionHelper(method, _ =>
            {
                var finalparams = ParamHelper(method);

                return method.Method.Invoke(method.Target, finalparams.ToArray());
            });
        }

        private IEnumerable<object> ParamHelper(MulticastDelegate method)
        {
            var methparams = method.Method.GetParameters();
            IEnumerable<object> finalparams;

            if (method.Method.GetParameters().All(p => p.ParameterType.IsBasic()))
            {
                var queryparams = (IDictionary<string, dynamic>)this.Request.Query;

                finalparams = from qp in queryparams
                              from mp in methparams
                              where qp.Key == mp.Name
                              select Convert.ChangeType(qp.Value.Value, mp.ParameterType);
            }
            else
            {
                var jss = new JavaScriptSerializer();
                var bodyparams = jss.Deserialize<dynamic>(ReWrittenBody);

                finalparams = (from mp in methparams
                               where bodyparams[mp.Name] != null
                               select jss.Deserialize(jss.Serialize(bodyparams[mp.Name]), mp.ParameterType)).Cast<object>().ToList();
            }

            return finalparams;
        }
    }
}
