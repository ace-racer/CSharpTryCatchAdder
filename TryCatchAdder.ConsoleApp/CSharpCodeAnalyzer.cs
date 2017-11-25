using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace TryCatchAdder.ConsoleApp
{
    /// <summary>
    /// C Sharp code analyzer
    /// </summary>
    public class CSharpCodeAnalyzer
    {
        /// <summary>
        /// The public string
        /// </summary>
        private const string PublicString = "public";

        /// <summary>
        /// Gets the public methods in class.
        /// </summary>
        /// <param name="code">The code.</param>
        public List<MethodDeclarationSyntax> GetPublicMethodsInClass(string code)
        {
            var publicMethods = new List<MethodDeclarationSyntax>();
            try
            {                
                if (!string.IsNullOrWhiteSpace(code))
                {
                    SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
                    var root = (CompilationUnitSyntax)tree.GetRoot();
                    var classMembers = root.DescendantNodes().OfType<MemberDeclarationSyntax>();

                    foreach (var member in classMembers)
                    {
                        var method = member as MethodDeclarationSyntax;
                        if (method != null)
                        {
                            Console.WriteLine("Method name: " + method.Identifier);
                            var modifiers = method.Modifiers.ToList();
                            if (modifiers.Any(s => string.Compare(s.ValueText, PublicString) == 0))
                            {
                                Console.WriteLine("Current method is public");
                                publicMethods.Add(method);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return publicMethods;
        }
    }
}
