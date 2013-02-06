using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Nancy;
using Nancy.Json;

namespace Amanda
{
    /// <summary>
    /// A specialized Nancy module that allows for simple exposition of web services
    /// </summary>
    public class AmandaModule : NancyModule
    {
        /// <summary>
        /// Gets or sets the list of all endpoint builders spawned by this module
        /// </summary>
        internal List<EndpointBuilder> builders;

        /// <summary>
        /// Gets or sets the root route used by this module
        /// </summary>
        internal string RootRoute { get; set; }

        /// <summary>
        /// Gets or sets the body of the request if and when the body of the request 
        /// is re-written by Amanda.
        /// </summary>
        internal string ReWrittenBody { get; set; }

        /// <summary>
        /// The constructor for an AmandaModule, setting the RootRoute to "/api",
        /// initialing the builder list and adding a hook to allow CORS from any domain
        /// </summary>
        public AmandaModule()
        {
            RootRoute = "/api";
            builders = new List<EndpointBuilder>();
            After.AddItemToEndOfPipeline(x => x.Response.Headers.Add("Access-Control-Allow-Origin", "*"));
        }

        // This region houses the 17 different versions of the Exposes method,
        // one for every Action delegate provided by the .NET framework
        #region Exposes

        /// <summary>
        /// The method registers an EndpointBuilder for the Action delegate and returns
        /// it for further customisation
        /// </summary>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder Exposes(Action method)
        {
            return ExpositionHelper(method, _ =>
                                                {
                                                    method();
                                                    return HttpStatusCode.OK;
                                                });
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Action delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T">The type of the parameter the delegate method takes</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder Exposes<T>(Action<T> method)
        {
            return ActionHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Action delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder Exposes<T1,T2>(Action<T1,T2> method)
        {
            return ActionHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Action delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the method takes</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder Exposes<T1, T2, T3>(Action<T1, T2, T3> method)
        {
            return ActionHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Action delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder Exposes<T1, T2, T3, T4>(Action<T1, T2, T3, T4> method)
        {
            return ActionHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Action delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the method takes</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder Exposes<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> method)
        {
            return ActionHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Action delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> method)
        {
            return ActionHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Action delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> method)
        {
            return ActionHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Action delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T8">The type of the eigth parameter the delegate method takes</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> method)
        {
            return ActionHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Action delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T8">The type of the eigth parameter the delegate method takes</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter the delegate method takes</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> method)
        {
            return ActionHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Action delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T8">The type of the eigth parameter the delegate method takes</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter the delegate method takes</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter the delegate method takes</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> method)
        {
            return ActionHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Action delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T8">The type of the eigth parameter the delegate method takes</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter the delegate method takes</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter the delegate method takes</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> method)
        {
            return ActionHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Action delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T8">The type of the eigth parameter the delegate method takes</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter the delegate method takes</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T12">The type of the twelveth parameter the delegate method takes</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> method)
        {
            return ActionHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Action delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T8">The type of the eigth parameter the delegate method takes</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter the delegate method takes</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T12">The type of the twelveth parameter the delegate method takes</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter the delegate method takes</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> method)
        {
            return ActionHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Action delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T8">The type of the eigth parameter the delegate method takes</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter the delegate method takes</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T12">The type of the twelveth parameter the delegate method takes</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter the delegate method takes</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> method)
        {
            return ActionHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Action delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T8">The type of the eigth parameter the delegate method takes</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter the delegate method takes</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T12">The type of the twelveth parameter the delegate method takes</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T15">The type of the fifteenth parameter the delegate method takes</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> method)
        {
            return ActionHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Action delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T8">The type of the eigth parameter the delegate method takes</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter the delegate method takes</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T12">The type of the twelveth parameter the delegate method takes</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T15">The type of the fifteenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T16">The type of the sixteenth parameter the delegate method takes</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder Exposes<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> method)
        {
            return ActionHelper(method);
        }

        #endregion

        // This region houses the 17 different versions of the ExposesWithReturn method,
        // one for ever Func delegate provided by the .NET framework
        #region ExposesWithReturn

        /// <summary>
        /// The method registers an EndpointBuilder for the Func delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="TResult">The return type of the delegate method</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder ExposesWithReturn<TResult>(Func<TResult> method)
        {
            return FuncHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Func delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="TResult">The return type of the delegate method</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder ExposesWithReturn<T1, TResult>(Func<T1, TResult> method)
        {
            return FuncHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Func delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="TResult">The return type of the delegate method</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder ExposesWithReturn<T1, T2, TResult>(Func<T1, T2, TResult> method)
        {
            return FuncHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Func delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="TResult">The return type of the delegate method</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder ExposesWithReturn<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> method)
        {
            return FuncHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Func delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="TResult">The return type of the delegate method</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> method)
        {
            return FuncHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Func delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="TResult">The return type of the delegate method</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> method)
        {
            return FuncHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Func delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="TResult">The return type of the delegate method</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> method)
        {
            return FuncHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Func delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="TResult">The return type of the delegate method</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> method)
        {
            return FuncHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Func delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T8">The type of the eigth parameter the delegate method takes</typeparam>
        /// <typeparam name="TResult">The return type of the delegate method</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> method)
        {
            return FuncHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Func delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T8">The type of the eigth parameter the delegate method takes</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter the delegate method takes</typeparam>
        /// <typeparam name="TResult">The return type of the delegate method</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> method)
        {
            return FuncHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Func delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T8">The type of the eigth parameter the delegate method takes</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter the delegate method takes</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter the delegate method takes</typeparam>
        /// <typeparam name="TResult">The return type of the delegate method</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> method)
        {
            return FuncHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Func delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T8">The type of the eigth parameter the delegate method takes</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter the delegate method takes</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter the delegate method takes</typeparam>
        /// <typeparam name="TResult">The return type of the delegate method</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> method)
        {
            return FuncHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Func delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T8">The type of the eigth parameter the delegate method takes</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter the delegate method takes</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T12">The type of the twelveth parameter the delegate method takes</typeparam>
        /// <typeparam name="TResult">The return type of the delegate method</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> method)
        {
            return FuncHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Func delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T8">The type of the eigth parameter the delegate method takes</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter the delegate method takes</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T12">The type of the twelveth parameter the delegate method takes</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter the delegate method takes</typeparam>
        /// <typeparam name="TResult">The return type of the delegate method</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> method)
        {
            return FuncHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Func delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T8">The type of the eigth parameter the delegate method takes</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter the delegate method takes</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T12">The type of the twelveth parameter the delegate method takes</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter the delegate method takes</typeparam>
        /// <typeparam name="TResult">The return type of the delegate method</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> method)
        {
            return FuncHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Func delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T8">The type of the eigth parameter the delegate method takes</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter the delegate method takes</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T12">The type of the twelveth parameter the delegate method takes</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T15">The type of the fifteenth parameter the delegate method takes</typeparam>
        /// <typeparam name="TResult">The return type of the delegate method</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> method)
        {
            return FuncHelper(method);
        }

        /// <summary>
        /// The method registers an EndpointBuilder for the Func delegate and returns
        /// it for further customisation
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter the delegate method takes</typeparam>
        /// <typeparam name="T2">The type of the second parameter the delegate method takes</typeparam>
        /// <typeparam name="T3">The type of the third parameter the delegate method takes</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter the delegate method takes</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter the delegate method takes</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter the delegate method takes</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T8">The type of the eigth parameter the delegate method takes</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter the delegate method takes</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter the delegate method takes</typeparam>
        /// <typeparam name="T12">The type of the twelveth parameter the delegate method takes</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T15">The type of the fifteenth parameter the delegate method takes</typeparam>
        /// <typeparam name="T16">The type of the sixteenth parameter the delegate method takes</typeparam>
        /// <typeparam name="TResult">The return type of the delegate method</typeparam>
        /// <param name="method">The method to expose as a service endpoint</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder ExposesWithReturn<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> method)
        {
            return FuncHelper(method);
        }

        #endregion

        /// <summary>
        /// Exposes any delegate by forgoing the more eye-pleasing syntax of the Exposes
        /// and ExposesWithReturn methods
        /// </summary>
        /// <param name="d">The method to expose</param>
        /// <returns>The endpoint builder associated with the method</returns>
        public EndpointBuilder Exposes(MulticastDelegate d)
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

        /// <summary>
        /// Starts the web service
        /// </summary>
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

        /// <summary>
        /// Starts the web service with a root route other then "/api"
        /// </summary>
        /// <param name="rootRoute">The root route to replace "/api"</param>
        public void Start(string rootRoute)
        {
            RootRoute = rootRoute;
            Start();
        }

        // This region houses helper methods used in the different methods above
        #region Helpers

        /// <summary>
        /// Prepares the route handler code for a method that takes any number of arguments and returns nothing
        /// </summary>
        /// <param name="method">The method to invoke when the route is ran</param>
        /// <returns>The EndpointBuilder associated with the method</returns>
        private EndpointBuilder ActionHelper(MulticastDelegate method)
        {
            return ExpositionHelper(method, _ =>
                                                {
                                                    var finalparams = ParamHelper(method);

                                                    method.Method.Invoke(method.Target, finalparams.ToArray());

                                                    return HttpStatusCode.OK;
                                                });
        }

        /// <summary>
        /// Prepares the route handler code for a method that takes any number of arguments and returns something
        /// </summary>
        /// <param name="method">The method to invoke when the route is ran</param>
        /// <returns>The EndpointBuilder associated with the method</returns>
        private EndpointBuilder FuncHelper(MulticastDelegate method)
        {
            return ExpositionHelper(method, _ =>
            {
                var finalparams = ParamHelper(method);

                return method.Method.Invoke(method.Target, finalparams.ToArray());
            });
        }

        /// <summary>
        /// Prepares the parameters with which a method is invoked, taking them from
        /// the querystring or request body, as appropriate
        /// </summary>
        /// <param name="method">The method to prepare parameters for</param>
        /// <returns>The parameters to be passed to the method when it's invoked</returns>
        private IEnumerable<object> ParamHelper(MulticastDelegate method)
        {
            // Gets the method parameters
            var methparams = method.Method.GetParameters();
            IEnumerable<object> finalparams;

            if (Request.Method == "GET")
            {
                // Gets the querystring key value pairs
                var queryparams = (IDictionary<string, dynamic>)this.Request.Query;

                // Selects the properly named keys in the queryparams and converts them
                // to the correct type
                finalparams = from qp in queryparams
                              from mp in methparams
                              where qp.Key == mp.Name
                              select Convert.ChangeType(qp.Value.Value, mp.ParameterType);
            }
            else
            {
                // Deserializes the body and if desirializing the re-written body, nullifies it
                var jss = new JavaScriptSerializer();
                var bodyparams = jss.Deserialize<dynamic>(ReWrittenBody  ?? Request.Body.AsString());

                ReWrittenBody = null;

                // Normalizes the parameters passed into the body by re-serializing them
                // and then de-serializing them again as the correct type
                finalparams = (from mp in methparams
                               where bodyparams[mp.Name] != null
                               select Extensions.Deserialize(jss, jss.Serialize(bodyparams[mp.Name]), mp.ParameterType)).ToList();
            }

            return finalparams;
        }

        /// <summary>
        /// A helper method for creating and registering ExpositionHelper instances
        /// </summary>
        /// <param name="method">The method that is being registered</param>
        /// <param name="action">A handler for the route (as prepared by previous helper methods)</param>
        /// <returns>The EndpointBuilder assoicated with this method</returns>
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
