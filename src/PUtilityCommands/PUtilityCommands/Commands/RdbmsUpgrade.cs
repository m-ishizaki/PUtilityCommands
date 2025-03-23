using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace RKSoftware.PUtilityCommands.Commands
{
    internal class RdbmsUpgrade
    {
        public void Execute(string[] args)
        {
            if (!Validation(args)) return;

            Process(args[2]);
        }

        bool Validation(string[] args)
        {
            if (args.Length > 2)
                if (string.Compare("rds", args[0], true) == 0)
                    if (string.Compare("upgrade", args[1], true) == 0)
                        if (File.Exists(args[2]))
                            return true;
            Console.WriteLine("Usage: PUtilities putilitycommands rds upgrade <Path of Implem.CodeDefiner.exe>");
            return false;
        }

        void Process(string path)
        {
            using Process process = new Process();
            process.StartInfo.FileName = path;
            process.StartInfo.Arguments = "_rds";
            process.Start();
            process.WaitForExit();
        }
    }
}
