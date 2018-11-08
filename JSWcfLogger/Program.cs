using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace JSWcfLogger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitTrayIcon();
            Uri baseAddress = new Uri("http://localhost:8888/");
            using (ServiceHost host = new ServiceHost(typeof(LogService), baseAddress))
            {
                // Enable metadata publishing.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);
                host.Open();
                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();
                host.Close();
            }
        }

        private static void InitTrayIcon()
        {
            //@TODO init tray icon and menu
        }
    }
}