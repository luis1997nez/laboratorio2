using Function.Integrations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;

namespace Function.IntegrationsTest
{
    public class TestFixture : IDisposable
    {
        private Process process;
        public int port = 7071;
        public HttpClient Client = new HttpClient();

        public TestFixture()
        {
            var dotnet = Environment.ExpandEnvironmentVariables(ConfigHelper.Settings.DotnetExecutablePath);
            var functionHost = Environment.ExpandEnvironmentVariables(ConfigHelper.Settings.FunctionHostPath);
            var functionApp = Path.GetRelativePath(Directory.GetCurrentDirectory(), ConfigHelper.Settings.FunctionApplicationPath);


            process = new Process
            {
                StartInfo =
                {
                    FileName = dotnet,
                    Arguments = $"\"{functionHost}\" start -p {port}",
                    WorkingDirectory = functionApp
                }
            };
            var success = process.Start();
            Client.BaseAddress = new Uri($"http://localhost:{port}");
        }
        public void Dispose()
        {
            if (!process.HasExited) 
            {
                process.Kill();
            }
            process.Dispose();
            
        }
    }
}
