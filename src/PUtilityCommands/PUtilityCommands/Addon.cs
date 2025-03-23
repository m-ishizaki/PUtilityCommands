using System;
using System.Collections.Generic;
using System.Text;

namespace RKSoftware.PUtilityCommands
{
    public class Addon : RKSoftware.IPUtilities.AddOns.IAddon
    {
        public string Name => "PUtilityCommands";
        public string Command => "putilitycommands";
        public string Description => "A collection of utility commands for the PUtilities application.";
        public string Version => "1.0.0";
        public void Initialize()
        {
        }
        public void Execute(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: PUtilities putilitycommands rds sqlserver");
                Console.WriteLine("Usage: PUtilities putilitycommands rds upgrade <Path of Implem.CodeDefiner.exe>");
                return;
            }

            if (string.Compare("rds", args[0], true) == 0)
                if (string.Compare("sqlserver", args[1], true) == 0)
                {
                    new Commands.RdsConfig().Execute().Wait();
                    return;
                }
            if (string.Compare("rds", args[0], true) == 0)
                if (string.Compare("upgrade", args[1], true) == 0)
                {
                    new Commands.RdbmsUpgrade().Execute(args);
                    return;
                }


            Console.WriteLine("Invalid command.");
        }
    }
}
