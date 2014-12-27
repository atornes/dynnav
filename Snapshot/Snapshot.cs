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
            string appRoot = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            System.Console.WriteLine(appRoot);
            var startInfo = new ProcessStartInfo
            {
                Arguments = String.Format("{0} {1}", "/Users/janneoren/Projects/dynnav/Snapshot/createSnapshot.js", url),
                FileName = "phantomjs.exe",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                StandardOutputEncoding = System.Text.Encoding.UTF8
            };

            System.Console.WriteLine("Start info created");
            
            var p = new Process();

            p.StartInfo = startInfo;
            p.Start();
            
            System.Console.WriteLine("Process started");
            
            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();

            System.Console.WriteLine(error);

            p.WaitForExit();

            return output;
        }
    }
}