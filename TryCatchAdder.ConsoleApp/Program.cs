using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchAdder.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLocation = ConfigurationManager.AppSettings["fileLocation"];
            var sourceCode = new CSharpFileReader().GetContentsFromCSharpCodeFile(fileLocation);
            var allPublicMethods = new CSharpCodeAnalyzer().GetPublicMethodsWithoutCatchClauseInClass(sourceCode);
            Console.ReadKey();
        }
    }
}
