using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Texter.Models
{
    public class Message
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }

        public void Send()
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/ACa4f8544a68ff139fcdb465bbb8d6a814/Messages", Method.POST);
            request.AddParameter("To", To);
            request.AddParameter("From", From);
            request.AddParameter("Body", Body);
            client.Authenticator = new HttpBasicAuthenticator("ACa4f8544a68ff139fcdb465bbb8d6a814", "b33429a73f6f1171c7a9c2ee3949ef4a");
            client.ExecuteAsync(request, response => {
                Console.WriteLine(response.Content);
            });
        }
        public static List<Message> GetMessages()
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/ACa4f8544a68ff139fcdb465bbb8d6a814/Messages.json", Method.GET);
            client.Authenticator = new HttpBasicAuthenticator("ACa4f8544a68ff139fcdb465bbb8d6a814", "b33429a73f6f1171c7a9c2ee3949ef4a");
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }
    }
}