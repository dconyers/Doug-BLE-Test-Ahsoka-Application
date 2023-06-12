using System.Threading.Tasks;
using DotnetBleServer.Core;
using DotnetBleServer.Advertisements;
using System.Collections.Generic;
using System;
using Tmds.DBus;
using Ahsoka.Services.BlueLowEnergy.BlueZ;

using AdvertisementProperties = Ahsoka.Services.BlueLowEnergy.BlueZ.AdvertisementProperties;
using Advertisement = Ahsoka.Services.BlueLowEnergy.BlueZ.Advertisement;

namespace Ahsoka.Base
{
    public class SampleAdvertisement
    {
        public static async Task RegisterSampleAdvertisement(Connection dougConnection)
        {
            var advertisementProperties = new AdvertisementProperties
            {
                Type = "peripheral",
                ServiceUUIDs = new[] { "12345678-1234-5678-1234-56789abcdef0"},
                LocalName = "Berni",
            };

            var advertisement = new Advertisement("/org/bluez/example/advertisement0", advertisementProperties);

            await dougConnection.RegisterObjectAsync(advertisement);
            Console.WriteLine($"advertisement object {advertisement.ObjectPath} created");



            ILEAdvertisingManager1 adMan = dougConnection.CreateProxy<ILEAdvertisingManager1>("org.bluez", "/org/bluez/hci0");

                await adMan.RegisterAdvertisementAsync(((IDBusObject)advertisement).ObjectPath,
                new Dictionary<string, object>());

            Console.WriteLine($"advertisement {advertisement.ObjectPath} registered in BlueZ advertising manager");


            //            await new AdvertisingManager(serverContext).CreateAdvertisement(advertisementProperties);
        }
    }
}