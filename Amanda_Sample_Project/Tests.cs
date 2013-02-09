using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NUnit.Framework;
using FluentAssertions;
using Nancy;
using Nancy.Testing;

namespace Amanda_Sample_Project
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public static void Amanda_Exposes_No_Parameter_Action()
        {
            var bootstraper = new DefaultNancyBootstrapper();
            var browser = new Browser(x =>
                                          {
                                              x.RootPathProvider(new DefaultRootPathProvider());
                                          });

            var result = browser.Get("/api/DoNothing", ctx =>
                                                           {
                                                               ctx.HttpRequest();
                                                           });

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public static void Amanda_Exposes_1_Parameter_Action()
        {
            var bootstraper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstraper);

            var result = browser.Get("/api/DoNothingFor", ctx =>
                                                              {
                                                                  ctx.Query("i", "5");
                                                                  ctx.HttpRequest();
                                                              });

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public static void Amanda_Exposes_2_Parameter_Action()
        {
            var bootstraper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstraper);

            var result = browser.Get("/api/DoNothingForFactor", ctx =>
            {
                ctx.Query("i", "5");
                ctx.Query("d", "5");
                ctx.HttpRequest();
            });

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public static void Amanda_Exposes_No_Parameter_Func()
        {
            var bootstraper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstraper);

            var wasteTime = browser.Get("/api/DoNothing", ctx =>
            {
                ctx.HttpRequest();
            });

            var result = browser.Get("/api/GetWastedTime", ctx =>
            {
                ctx.HttpRequest();
            });

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Body.AsString().Should().Be("1000");
        }
    }
}