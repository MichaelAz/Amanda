using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Dynamic;
using System.Web.Script.Serialization;

namespace Amanda.Client
{
    public class AmandaClient : DynamicObject
    {
        private WebClient client;

        private Dictionary<string, List<MetadataProvider>> providers;

        private string serviceUri;

        public AmandaClient(string serviceUri)
        {
            client = new WebClient();
            this.serviceUri = serviceUri;
            providers =
                (new JavaScriptSerializer()).Deserialize<List<List<MetadataProvider>>>(
                    client.DownloadString(serviceUri + "/metadata")).ToDictionary(e => e.First().Name);
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (providers.ContainsKey(binder.Name))
            {
                var provider = providers[binder.Name].First();

                if (provider.Verb == "Get")
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        if (args[i].GetType() != Type.GetType(provider.Parameters.ElementAt(i).Value))
                        {
                            throw new ArgumentException();
                        }
                    }

                    var uriBuilder = new UriBuilder(new Uri(serviceUri + provider.Route));
                    var queryBuilder = new StringBuilder();

                    for (int i = 0; i < provider.Parameters.Count; i++)
                    {
                        queryBuilder.Append(provider.Parameters.ElementAt(i).Key + "=" + args[i]);
                        queryBuilder.Append("&");
                    }

                    uriBuilder.Query = queryBuilder.ToString().TrimEnd('&');

                    var res = client.DownloadString(uriBuilder.Uri);

                    if (res == String.Empty)
                    {
                        result = null;
                    }
                    else
                    {
                        result = res;
                    }

                    return true;
                }
                else
                {
                    var dict = new Dictionary<string, dynamic>();
                    for (int i = 0; i < provider.Parameters.Count; i++)
                    {
                        dict.Add(provider.Parameters.ElementAt(i).Key, args[i]);
                    }

                    var res = client.UploadString(serviceUri + provider.Route,
                                                  (new JavaScriptSerializer()).Serialize(dict));

                    if (res == String.Empty)
                    {
                        result = null;
                    }
                    else
                    {
                        result = res;
                    }

                    return true;
                }
            }

            result = null;
            return false;
        }
    }
}
