using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;

using Nancy;
using Nancy.ModelBinding;
using Nancy.Json;

namespace Amanda
{
    public class AmandaModule : NancyModule
    {
        internal List<EndpointBuilder> builders;

        internal string RootRoute { get; set; }

        internal string ReWrittenBody { get; set; }

        public AmandaModule()
        {
            RootRoute = "/api";
            builders = new List<EndpointBuilder>();
            After.AddItemToEndOfPipeline(x => x.Response.Headers.Add("Access-Control-Allow-Origin", "*"));
        }

        #region Exposes

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

        public EndpointBuilder Exposes<T1, T2, T3, T4>(Action<T1, T2, T3, T4> method)
        {
            return ActionHelper(method);
        }

        public EndpointBuilder Exposes<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> method)
        {
            return ActionHelper(method);
        }

        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> method)
        {
            return ActionHelper(method);
        }

        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> method)
        {
            return ActionHelper(method);
        }

        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> method)
        {
            return ActionHelper(method);
        }

        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> method)
        {
            return ActionHelper(method);
        }

        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> method)
        {
            return ActionHelper(method);
        }

        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> method)
        {
            return ActionHelper(method);
        }

        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> method)
        {
            return ActionHelper(method);
        }

        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> method)
        {
            return ActionHelper(method);
        }

        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> method)
        {
            return ActionHelper(method);
        }

        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> method)
        {
            return ActionHelper(method);
        }

        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> method)
        {
            return ActionHelper(method);
        }

        #endregion

        #region ExposesWithReturn

        public EndpointBuilder ExposesWithReturn<TResult>(Func<TResult> method)
        {
            return FuncHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T1, TResult>(Func<T1, TResult> method)
        {
            return FuncHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T1, T2, TResult>(Func<T1, T2, TResult> method)
        {
            return FuncHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> method)
        {
            return FuncHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> method)
        {
            return FuncHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> method)
        {
            return FuncHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> method)
        {
            return FuncHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> method)
        {
            return FuncHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> method)
        {
            return FuncHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> method)
        {
            return FuncHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> method)
        {
            return FuncHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> method)
        {
            return FuncHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> method)
        {
            return FuncHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> method)
        {
            return FuncHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> method)
        {
            return FuncHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> method)
        {
            return FuncHelper(method);
        }

        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> method)
        {
            return FuncHelper(method);
        }

        #endregion

        public EndpointBuilder ExposesDelegate(MulticastDelegate d)
        {
            if (d.Method.ReturnType == typeof(void))
            {
                return ActionHelper(d);
            }
            else
            {
                return FuncHelper(d);
            }
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

        #region Helpers

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
            var s = this.Request.Method;
            if (Request.Method == "GET")
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
                var bodyparams = jss.Deserialize<dynamic>(ReWrittenBody ?? Request.Body.AsString());

                finalparams = (from mp in methparams
                               where bodyparams[mp.Name] != null
                               select Extensions.Deserialize(jss, jss.Serialize(bodyparams[mp.Name]), mp.ParameterType)).ToList();
            }

            return finalparams;
        }

        private EndpointBuilder ExpositionHelper(MulticastDelegate method, Func<dynamic, dynamic> action)
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

        #endregion
    }
}
