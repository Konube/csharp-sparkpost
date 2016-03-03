﻿using System.Threading.Tasks;

namespace SparkPost
{
    public class Transmissions
    {
        private readonly Client client;
        private readonly RequestSender requestSender;
        private DataMapper dataMapper;

        public Transmissions(Client client)
        {
            this.client = client;
            requestSender = new RequestSender(client);
            dataMapper = new DataMapper("v1");
        }

        public async Task<Response> Send(Transmission transmission)
        {
            var request = new Request
            {
                Method = string.Format("api/{0}/transmissions", client.Version),
                Data = dataMapper.ToDictionary(transmission)
            };

            return await requestSender.Send(request);
        }
    }
}