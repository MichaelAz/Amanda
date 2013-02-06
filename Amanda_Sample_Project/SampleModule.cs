using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Amanda;

namespace Amanda_Sample_Project
{
    public class SampleModule : AmandaModule
    {
        public SampleModule()
        {
            // Expose no parameter action - exposed as GET /api/DoNothing
            this.Exposes(BuisnesLogic.DoNothing);

            // Expose 1 parameter action - exposed as GET /api/DoNothingFor?i={something}
            this.Exposes<int>(BuisnesLogic.DoNothingFor);

            // Expose 2 parameter action - exposed as GET /api/DoNothingForFactor?d={something}&i={something}
            this.Exposes<double, int>(BuisnesLogic.DoNothingForFactor);

            // Expose no parameter func - exposed as GET /api/GetWastedTime
            this.ExposesWithReturn(BuisnesLogic.GetWastedTime);

            // Expose 1 parameter func - exposed as POST /api/GetUsersUsername
            this.ExposesWithReturn<User, string>(BuisnesLogic.GetUsersUsername);

            // Expose 2 parameter func - exposed as POST /api/SpliceUsers
            this.ExposesWithReturn<User, User, User>(BuisnesLogic.SpliceUsers);

            // Expose a non static method - exposed as POST /api/Serialize
            this.ExposesWithReturn<object, string>((new Nancy.Json.JavaScriptSerializer()).Serialize);

            // Expose a method with explicit path - exposed as POST /api/Serialize/This
            this.ExposesWithReturn<object, string>((new Nancy.Json.JavaScriptSerializer()).Serialize)
                .WithRoute("/Serialize/This");

            // Expose a method with explicit verb - exposed as POST /api/GetWastedTime
            this.ExposesWithReturn(BuisnesLogic.GetWastedTime)
                .WithVerb(Verb.Post);

            // Expose a method with single blacklist - exposed as POST /api/GetUsersUsername
            this.ExposesWithReturn<User, string>(BuisnesLogic.GetUsersUsername)
                .WithBlakcList<User>("Password");

            // Start with non default root route
            // this.Start("/nonstandard");

            // Start with default root route - /api
            this.Start();
        }
    }
}