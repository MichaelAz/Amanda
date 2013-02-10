using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Amanda.Client;

namespace Amanda_Client_Sample_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic client = new AmandaClient("http://localhost:15534/api");
            client.DoNothingForFactor(1.5, 1);
            client.GetUsersUsername(new {Username = "testUser", Password = "leettleeto"});
        }
    }
}
