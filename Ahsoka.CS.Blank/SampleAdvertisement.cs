﻿using System.Threading.Tasks;
using DotnetBleServer.Core;
using DotnetBleServer.Advertisements;

namespace Ahsoka.Base
{
    public class SampleAdvertisement
    {
        public static async Task RegisterSampleAdvertisement(ServerContext serverContext)
        {
            var advertisementProperties = new AdvertisementProperties
            {
                Type = "peripheral",
                ServiceUUIDs = new[] { "12345678-1234-5678-1234-56789abcdef0"},
                LocalName = "A",
            };

            await new AdvertisingManager(serverContext).CreateAdvertisement(advertisementProperties);
        }
    }
}