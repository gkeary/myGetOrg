/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
﻿using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Microsoft.Build.Utilities;

namespace GetOrganized.BuildTasks
{
    public class RemoteTask : Task
    {
        public string ExecutableLocation { get; set; }
        public string RemoteIP { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string WorkingDirectory { get; set; }
        public string RemoteCommand { get; set; }
        public string Parameters { get; set; }

        public override bool Execute()
        {
            string psExecCommand = ExecutableLocation + "\\"
                + "psexec.exe";

            string psExecArguements = "\\\\" + RemoteIP 
                + " -u " + UserName + " -p " + Password;

            string remoteCommand = "-w \"" + WorkingDirectory + 
                "\" \"" + RemoteCommand + "\" " + Parameters;

            try
            {
                Process p = Process.Start(
                    psExecCommand, psExecArguements + " " + remoteCommand);

                p.WaitForExit();
                return true;
            }
            catch (Exception e)
            {
                Log.LogError(e.Message);
                return false;
            }
        }
    }
}