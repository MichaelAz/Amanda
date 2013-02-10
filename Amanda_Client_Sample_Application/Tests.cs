using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Amanda.Client;

using NUnit.Framework;
using FluentAssertions;

namespace Amanda_Client_Sample_Application
{
    [TestFixture]
    class Tests
    {
        [Test]
        public static void Should_Succed_On_Exposed_Methods()
        {
            dynamic client = new AmandaClient("http://localhost:15534/api");

            var actions = new Action[]
                              {
                                  () => client.DoNothing(),
                                  () => client.DoNothingFor(1),
                                  () => client.DoNothingForFactor(1.5, 2),
                                  () => client.GetWastedTime(),
                                  () => client.GetUsersUsername(new {ID = 1, Username = "test", Password = "pass"}),
                                  () =>
                                  client.SpliceUsers(new {ID = 1, Username = "test", Password = "pass"},
                                                     new {ID = 2, Username = "test2", Password = "pass2"})
                              };

            foreach (var action in actions)
            {
                action.ShouldNotThrow();
            }

        }

        [Test]
        public static void Should_Verify_Simple_Params()
        {
            dynamic client = new AmandaClient("http://localhost:15534/api");

            Action doNothingForFactor = () => client.DoNothingFor(1, 2.5);

            doNothingForFactor.ShouldThrow<ArgumentException>();
        }
    }
}
