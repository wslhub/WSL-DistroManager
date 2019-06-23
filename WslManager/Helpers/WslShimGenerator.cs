using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace WslManager.Helpers
{
    internal static class WslShimGenerator
    {
        public static CompilerResults CreateWslShim(string distroName, bool ignoreSwitches, string outputPath, string outputFileName)
        {
            var codeCompileUnit = new CodeCompileUnit();

            var targetNamespace = new CodeNamespace();

            var targetType = new CodeTypeDeclaration("Program")
            {
                IsClass = true,
                Attributes = MemberAttributes.Static | MemberAttributes.Private,
            };

            var mainMethod = new CodeMemberMethod()
            {
                Name = "Main",
                ReturnType = new CodeTypeReference(typeof(int)),
                Attributes = MemberAttributes.Static | MemberAttributes.Private,
                CustomAttributes = new CodeAttributeDeclarationCollection(new CodeAttributeDeclaration[]
                {
                    new CodeAttributeDeclaration(new CodeTypeReference(typeof(STAThreadAttribute))),
                }),
            };

            var argsMethodArgument = new CodeParameterDeclarationExpression(typeof(string[]), "args");
            mainMethod.Parameters.Add(argsMethodArgument);

            var declareDistroNameVariable = new CodeVariableDeclarationStatement(typeof(string), "distroName")
            {
                InitExpression = new CodePrimitiveExpression(distroName),
            };

            var declareWslPathVariable = new CodeVariableDeclarationStatement(typeof(string), "wslPath")
            {
                InitExpression = new CodeMethodInvokeExpression(
                    new CodeMethodReferenceExpression(new CodeTypeReferenceExpression(typeof(Path)), nameof(Path.Combine)),
                    new CodeMethodInvokeExpression(
                        new CodeMethodReferenceExpression(new CodeTypeReferenceExpression(typeof(Environment)), nameof(Environment.GetFolderPath)),
                        new CodePropertyReferenceExpression(new CodeTypeReferenceExpression(typeof(Environment.SpecialFolder)), nameof(Environment.SpecialFolder.System))),
                    new CodePrimitiveExpression("wsl.exe")),
            };

            var declareStringListVariable = new CodeVariableDeclarationStatement(typeof(List<string>), "argsCandidate")
            {
                InitExpression = new CodeObjectCreateExpression(typeof(List<string>)),
            };

            var addPrependSwitchesStatement = new CodeMethodInvokeExpression(
                new CodeVariableReferenceExpression(declareStringListVariable.Name),
                nameof(List<string>.AddRange),
                new CodeArrayCreateExpression(
                    new CodeTypeReference(typeof(string[])),
                    new CodePrimitiveExpression("-d"),
                    new CodeVariableReferenceExpression(declareDistroNameVariable.Name))
                );

            CodeConditionStatement conditionStatement = null;

            if (!ignoreSwitches)
            {
                conditionStatement = new CodeConditionStatement(new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression("args"), CodeBinaryOperatorType.IdentityInequality, new CodePrimitiveExpression(null)));
                conditionStatement.TrueStatements.Add(new CodeMethodInvokeExpression(
                    new CodeVariableReferenceExpression(declareStringListVariable.Name),
                    nameof(List<string>.AddRange),
                    new CodeVariableReferenceExpression("args"))
                );
            }

            var declareWslArgsVariable = new CodeVariableDeclarationStatement(typeof(string), "wslArgs")
            {
                InitExpression = new CodeMethodInvokeExpression(
                    new CodeMethodReferenceExpression(new CodeTypeReferenceExpression(typeof(string)), nameof(string.Join)),
                    new CodePrimitiveExpression(" "),
                    new CodeMethodInvokeExpression(new CodeVariableReferenceExpression(declareStringListVariable.Name), nameof(List<string>.ToArray))
                ),
            };

            var declareProcessStartInfoVariable = new CodeVariableDeclarationStatement(typeof(ProcessStartInfo), "psi")
            {
                InitExpression = new CodeObjectCreateExpression(
                    new CodeTypeReference(typeof(ProcessStartInfo)),
                        new CodeVariableReferenceExpression(declareWslPathVariable.Name),
                        new CodeVariableReferenceExpression(declareWslArgsVariable.Name)),
            };

            var assignPsiUseShellExecuteStatement = new CodeAssignStatement(
                new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(declareProcessStartInfoVariable.Name), nameof(ProcessStartInfo.UseShellExecute)),
                new CodePrimitiveExpression(false));

            var assignPsiCreateNoWindowStatement = new CodeAssignStatement(
                new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(declareProcessStartInfoVariable.Name), nameof(ProcessStartInfo.CreateNoWindow)),
                new CodePrimitiveExpression(false));

            var assignPsiRedirectStderrStatement = new CodeAssignStatement(
                new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(declareProcessStartInfoVariable.Name), nameof(ProcessStartInfo.RedirectStandardError)),
                new CodePrimitiveExpression(false));

            var assignPsiRedirectStdinStatement = new CodeAssignStatement(
                new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(declareProcessStartInfoVariable.Name), nameof(ProcessStartInfo.RedirectStandardInput)),
                new CodePrimitiveExpression(false));

            var assignPsiRedirectStdoutStatement = new CodeAssignStatement(
                new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(declareProcessStartInfoVariable.Name), nameof(ProcessStartInfo.RedirectStandardOutput)),
                new CodePrimitiveExpression(false));

            var assignPsiWindowStyleStatement = new CodeAssignStatement(
                new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(declareProcessStartInfoVariable.Name), nameof(ProcessStartInfo.WindowStyle)),
                new CodePropertyReferenceExpression(new CodeTypeReferenceExpression(typeof(ProcessWindowStyle)), nameof(ProcessWindowStyle.Minimized)));

            var assignPsiWorkingDirectoryStatement = new CodeAssignStatement(
                new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(declareProcessStartInfoVariable.Name), nameof(ProcessStartInfo.WorkingDirectory)),
                new CodePropertyReferenceExpression(new CodeTypeReferenceExpression(typeof(Environment)), nameof(Environment.CurrentDirectory)));

            var declareProcessVariable = new CodeVariableDeclarationStatement(new CodeTypeReference(typeof(Process)), "process")
            {
                InitExpression = new CodeObjectCreateExpression(new CodeTypeReference(typeof(Process))),
            };

            var assignProcessStartInfoStatement = new CodeAssignStatement(
                new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(declareProcessVariable.Name), nameof(Process.StartInfo)),
                new CodeVariableReferenceExpression(declareProcessStartInfoVariable.Name));

            var assignProcessEnableRaisingEventsStatement = new CodeAssignStatement(
                new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(declareProcessVariable.Name), nameof(Process.EnableRaisingEvents)),
                new CodePrimitiveExpression(true));

            var invokeProcessStartStatement = new CodeMethodInvokeExpression(
                new CodeVariableReferenceExpression(declareProcessVariable.Name),
                nameof(Process.Start));

            var invokeWaitForExitStatement = new CodeMethodInvokeExpression(
                new CodeVariableReferenceExpression(declareProcessVariable.Name),
                nameof(Process.WaitForExit));

            var declareExitCodeVariable = new CodeVariableDeclarationStatement(typeof(int), "exitCode")
            {
                InitExpression = new CodePropertyReferenceExpression(
                    new CodeVariableReferenceExpression(declareProcessVariable.Name),
                    nameof(Process.ExitCode)),
            };

            var assignExitCodeStatement = new CodeAssignStatement(
                new CodePropertyReferenceExpression(new CodeTypeReferenceExpression(typeof(Environment)), nameof(Environment.ExitCode)),
                new CodeVariableReferenceExpression(declareExitCodeVariable.Name));

            var invokeDisposeStatement = new CodeMethodInvokeExpression(
                new CodeVariableReferenceExpression(declareProcessVariable.Name),
                nameof(Process.Dispose));

            var returnStatement = new CodeMethodReturnStatement(new CodeVariableReferenceExpression(declareExitCodeVariable.Name));

            mainMethod.Statements.Add(declareDistroNameVariable);
            mainMethod.Statements.Add(declareWslPathVariable);
            mainMethod.Statements.Add(declareStringListVariable);
            mainMethod.Statements.Add(addPrependSwitchesStatement);

            if (!ignoreSwitches)
                mainMethod.Statements.Add(conditionStatement);

            mainMethod.Statements.Add(declareWslArgsVariable);
            mainMethod.Statements.Add(declareProcessStartInfoVariable);
            mainMethod.Statements.Add(assignPsiUseShellExecuteStatement);
            mainMethod.Statements.Add(assignPsiCreateNoWindowStatement);
            mainMethod.Statements.Add(assignPsiRedirectStderrStatement);
            mainMethod.Statements.Add(assignPsiRedirectStdinStatement);
            mainMethod.Statements.Add(assignPsiRedirectStdoutStatement);
            mainMethod.Statements.Add(assignPsiWindowStyleStatement);
            mainMethod.Statements.Add(assignPsiWorkingDirectoryStatement);
            mainMethod.Statements.Add(declareProcessVariable);
            mainMethod.Statements.Add(assignProcessStartInfoStatement);
            mainMethod.Statements.Add(assignProcessEnableRaisingEventsStatement);
            mainMethod.Statements.Add(invokeProcessStartStatement);
            mainMethod.Statements.Add(invokeWaitForExitStatement);
            mainMethod.Statements.Add(declareExitCodeVariable);
            mainMethod.Statements.Add(assignExitCodeStatement);
            mainMethod.Statements.Add(returnStatement);

            targetType.Members.Add(mainMethod);
            targetNamespace.Types.Add(targetType);
            codeCompileUnit.Namespaces.Add(targetNamespace);

            var codeDomProvider = CodeDomProvider.CreateProvider("CSharp");
            var generatorOptions = new CodeGeneratorOptions()
            {
                BracingStyle = "C",
                BlankLinesBetweenMembers = false,
                ElseOnClosing = true,
            };

            var buffer = new StringBuilder();
            codeDomProvider.GenerateCodeFromCompileUnit(codeCompileUnit, new StringWriter(buffer), generatorOptions);

            var iconPath = Path.Combine(
                SharedRoutines.GetIconDirectoryPath(),
                SharedRoutines.GetImageKey(distroName) + ".ico");

            var iconCompilerOption = string.Empty;
            
            if (File.Exists(iconPath))
                iconCompilerOption = $@"/win32icon:""{iconPath}""";

            var compilerParameters = new CompilerParameters(new string[] { "System.dll", })
            {
                GenerateExecutable = true,
                GenerateInMemory = false,
                OutputAssembly = Path.Combine(outputPath, $"{outputFileName}.exe"),
                CompilerOptions = string.Join(" ", "/optimize+", iconCompilerOption),
            };

            return codeDomProvider.CompileAssemblyFromDom(compilerParameters, codeCompileUnit);
        }
    }
}
