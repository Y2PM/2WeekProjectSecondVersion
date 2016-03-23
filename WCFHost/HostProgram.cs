using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFServiceCL;

namespace WCFHost
{
    class HostProgram
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ServiceMethodClass)))
            {
                string address = "http://" + Dns.GetHostName() + ":8081/Service";
                host.AddServiceEndpoint(typeof(IServe), new BasicHttpBinding(), address);

                host.Open();

                Console.WriteLine("Press enter to stop.");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}
