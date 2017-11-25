using System;
using System.IO;

namespace TryCatchAdder.ConsoleApp
{
    public class CSharpFileReader
    {
        /// <summary>
        /// The c sharp file extension
        /// </summary>
        private const string CSharpFileExtension = ".cs";

        /// <summary>
        /// Gets the contents from c sharp code file.
        /// </summary>
        /// <param name="completeFilePath">The complete file path.</param>
        /// <returns></returns>
        public string GetContentsFromCSharpCodeFile(string completeFilePath)
        {
            if (!string.IsNullOrWhiteSpace(completeFilePath))
            {
                try
                {
                    if (File.Exists(completeFilePath))
                    {
                        var fileInfo = new FileInfo(completeFilePath);
                        var fileExtension = fileInfo.Extension;
                        if (string.Compare(fileExtension, CSharpFileExtension, true) == 0)
                        {
                            var code = File.ReadAllText(completeFilePath);
                            return code;
                        }
                        else
                        {
                            Console.WriteLine("The file is not a C Sharp file");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The file: " + completeFilePath + " does not exist");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while reading C# file: " + ex.Message);
                }
            }

            return null;
        }
    }
}
