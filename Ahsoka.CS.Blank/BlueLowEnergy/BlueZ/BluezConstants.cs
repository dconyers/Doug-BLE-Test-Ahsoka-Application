using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahsoka.Services.BlueLowEnergy.BlueZ;


public static class BluezConstants
{
    public const string DBusService = "org.bluez";

    public const string AdapterInterface = "org.bluez.Adapter1";
    public const string BatteryInterface = "org.bluez.Battery1";
    public const string DeviceInterface = "org.bluez.Device1";
    public const string GattServiceInterface = "org.bluez.GattService1";
    public const string GattManagerInterface = "org.bluez.GattManager1";
    public const string GattCharacteristicInterface = "org.bluez.GattCharacteristic1";
    public const string GattDescriptorInterface = "org.bluez.GattDescriptor1";
    public const string LeAdvertisementInterface = "org.bluez.LEAdvertisement1";
    public const string LeAdvertisingManagerInterface = "org.bluez.LEAdvertisingManager1";
}
