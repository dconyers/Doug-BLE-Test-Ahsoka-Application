using System;
using System.Threading.Tasks;


namespace Ahsoka.Services.BlueLowEnergy.BlueZ
{
    public class Advertisement : PropertiesBase<AdvertisementProperties>, ILEAdvertisement1
    {
        public Advertisement(string objectPath, AdvertisementProperties properties) : base(objectPath, properties)
        {
        }

        public Task ReleaseAsync()
        {
            throw new NotImplementedException();
        }
    }
}