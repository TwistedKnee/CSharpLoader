using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Raditz
{
    class Program
    {
        static void Reflect(string FilePath)
        {
            Assembly dotNetProgram = Assembly.LoadFile(FilePath);
            Object[] parameters = new String[] { null };
            dotNetProgram.EntryPoint.Invoke(null, parameters);
        }
        static void Main(string[] args)
        {
            Reflect(@"C:\Users\User\Documents\GitHub\LearnCSharp\CSharp Loader\HelloFromReflectionWorld\HelloFromReflectionWorld\bin\Release\HelloFromReflectionWorld.exe");
        }
    }
}
