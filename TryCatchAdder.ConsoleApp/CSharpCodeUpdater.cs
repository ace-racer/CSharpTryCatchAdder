using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchAdder.ConsoleApp
{
    public class CSharpCodeUpdater
    {
        /// <summary>
        /// The placeholder
        /// </summary>
        private const string placeholder = "%%existingCode%%";

        /// <summary>
        /// The replacement
        /// </summary>
        private string replacement = "try" + Environment.NewLine + "{ " + placeholder + " }" + Environment.NewLine + "catch(Exception)" + Environment.NewLine + "{ throw; }";

        /// <summary>
        /// Updates the code with try catch blocks.
        /// </summary>
        /// <param name="publicMethodsWithoutTryCatchBlocks">The public methods without try catch blocks.</param>
        /// <param name="sourceCode">The source code.</param>
        /// <returns>The new code with the try catch added</returns>
        public List<MethodDeclarationSyntax> UpdateCodeWithTryCatchBlocks(List<MethodDeclarationSyntax> publicMethodsWithoutTryCatchBlocks, string sourceCode = "")
        {
            if (publicMethodsWithoutTryCatchBlocks != null && publicMethodsWithoutTryCatchBlocks.Any())
            {
                var methodDeclarations = new List<MethodDeclarationSyntax>();
                foreach (var method in publicMethodsWithoutTryCatchBlocks)
                {
                    try
                    {
                        if (method.Body != null && method.Body.Statements != null)
                        {
                            var existingMethodContents = method.Body.Statements.ToString();
                            var newMethodStatementsText = "{" + replacement.Replace(placeholder, existingMethodContents) + "}";                            
                            var root = (CompilationUnitSyntax)CSharpSyntaxTree.ParseText(newMethodStatementsText).GetRoot();
                            var codeBlock = root.DescendantNodes()
                                .OfType<BlockSyntax>().FirstOrDefault();
                            Console.WriteLine("Root: " + root.GetText().ToString());                        
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }

                return methodDeclarations;
            }

            return null;
        }
    }
}
