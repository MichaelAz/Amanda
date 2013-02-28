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
            return InvokeHelper(binder.Name, args, out result);
        }

        private bool InvokeHelper(string methodName, object[] args, out object result)
        {
            if (providers.ContainsKey(methodName))
            {
                var provider = providers[methodName].First();

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
                        if (Type.GetType(provider.Result).IsBasic())
                        {
                            result = Convert.ChangeType(res, Type.GetType(provider.Result));
                        }
                        else
                        {
                            var jss = new JavaScriptSerializer();

                            try
                            {
                                result = Extensions.ToExpando(jss.Deserialize<dynamic>(res));
                            }
                            catch (Exception)
                            {
                                result = jss.Deserialize<List<dynamic>>(res).Select(e => Extensions.ToExpando(e)).ToList();
                            }
                        }
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

                    if (Type.GetType(provider.Result).IsBasic())
                    {
                        result = Convert.ChangeType(res, Type.GetType(provider.Result));
                    }
                    else
                    {
                        var jss = new JavaScriptSerializer();

                        try
                        {
                            result = Extensions.ToExpando(jss.Deserialize<dynamic>(res));
                        }
                        catch (Exception)
                        {
                            result = jss.Deserialize<List<dynamic>>(res).Select(e => Extensions.ToExpando(e)).ToList();
                        }
                    }

                    return true;
                }
            }

            result = null;
            return false;
        }
    }
}
