using System;
using System.IO;
using System.Text;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace Patchy
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (CompilerInfo ci in CodeDomProvider.GetAllCompilerInfo())
            {
                foreach (string language in ci.GetLanguages())
                {
                    Console.Write("{0}	", language);
                }

                Console.WriteLine();
            }
        }
    }
}