using Ahsoka.ServiceFramework;
using Ahsoka.Services;
using Ahsoka.Services.System;
using Ahsoka.System;
using DotnetBleServer.Core;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Tmds.DBus;

namespace Ahsoka.Base;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Starting Ahsoka (Doug) Demo Application");

        //Console.WriteLine("Gen Read Finsihed in ")

        // Use InProcess transport since we are running in a test.
        ConfigurationLoader.SelectRuntimeConfig(TransportType.TCP);

        // Add App Service Client
        SystemServiceClient client = new();
        AhsokaRuntime.CreateBuilder()
                     .AddClients(client)
                     .StartWithInternalServices();


        Console.WriteLine("before commented-out routines");

        // Run Sample Test Code
        //ServiceSelfTests.RunEchoPerfTest(10000, client);
        //ServiceSelfTests.PrintServerMetrics(client);
        Console.WriteLine("after commented-out routines");


        Task.Run(async () =>
        {
//            using (var serverContext = new ServerContext())
            {
                Console.WriteLine("About to call ServerContext Connect");
                //await serverContext.Connect();
                
                Connection dougConnection = new Connection(Address.System);
                await dougConnection.ConnectAsync();


                Console.WriteLine("About to call SampleAdvertisement.RegisterSampleAdvertisement");
                await SampleAdvertisement.RegisterSampleAdvertisement(dougConnection);
                Console.WriteLine("Done w/Call to SampleAdvertisement.RegisterSampleAdvertisement");

                Console.WriteLine("Press CTRL+C to quit");
                await Task.Delay(-1);
            }
        }).Wait();

        // Release System Services to Continue Starting Up
        AhsokaRuntime.ReleaseStartup();

        // Wait for Shutdown Signal
        ApplicationContext.WaitForExitSignal();

        // Stop Server
        client.RequestServiceShutdown();

        // Close Client
        AhsokaRuntime.ShutdownAll();

        return;
    }
}
