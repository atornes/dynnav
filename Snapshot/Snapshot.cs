using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.AspNet.Mvc;

namespace DynNav
{
    public class Snapshot
    {
        //Read more here:
        //http://stackoverflow.com/questions/18530258/how-to-make-a-spa-seo-crawlable/18530259#18530259
        public static string Get(string url)
        {
            string appRoot = AppDomain.CurrentDomain.BaseDirectory;

            var startInfo = new ProcessStartInfo
            {
                Arguments = String.Format("{0} {1}", Path.Combine(appRoot, "Snapshot\\phantom-create.js"), url),
                FileName = Path.Combine(appRoot, "Snapshot\\phantomjs.exe"),
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                StandardOutputEncoding = System.Text.Encoding.UTF8
            };

            var p = new Process();

            p.StartInfo = startInfo;
            p.Start();
                        
            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();

            System.Console.WriteLine(error);

            p.WaitForExit();

            return output;
        }
    }
}