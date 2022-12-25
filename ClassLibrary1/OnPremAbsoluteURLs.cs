using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO.Compression;

using System;
using System.Management.Automation;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

//using System.Management.Automation;


namespace ConsoleApp1;

public class OnPremAbsoluteURLs
{
    ILogger<OnPremAbsoluteURLs> logger = LoggerFactory.Create(builder => builder.AddNLog()).CreateLogger<OnPremAbsoluteURLs>();

    public static void InitMakeAbsoluteUrlsScript()
    {
        //запускаем скрипт
        //что является триггером для запуска?
        //как передавать сайт?

    }

    public void powershelling()
    {
        string ps;
        ps = @"C:\Temp5\ps.ps1";
        //System.Diagnostics.Process
        //.Start(@"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe",
        //        ps + " http://stpa01z502/sites/TestOne" + " arg2" + " arg3");


        //ProcessStartInfo startInfo = new ProcessStartInfo();
        //startInfo.FileName = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
        //startInfo.Arguments = ps + " http://stpa01z502/sites/TestOne" + " arg2" + " arg3";
        //startInfo.RedirectStandardOutput = true;
        //startInfo.RedirectStandardError = true;
        //startInfo.UseShellExecute = false;
        //startInfo.CreateNoWindow = true;
        //Process process = new Process();
        //process.StartInfo = startInfo;
        //process.Start();

        //string output = process.StandardOutput.ReadToEnd();
        //Console.WriteLine("output"+output);
        ////Assert.IsTrue(output.Contains("StringToBeVerifiedInAUnitTest"));

        //string errors = process.StandardError.ReadToEnd();
        //Console.WriteLine("errors" + errors);
        //// Assert.IsTrue(string.IsNullOrEmpty(errors));



        // ...

        PowerShell ps1 = PowerShell.Create();
        ps1
           .AddCommand("Set-ExecutionPolicy")
           .AddParameter("ExecutionPolicy", "Bypass")
           .AddParameter("Scope", "Process")
           .AddParameter("Force");

        ps1.AddScript(ps);
        ps1.AddArgument(" http://stpa01z502/sites/TestOne")
        .AddArgument(" arg2")
        .AddArgument(" arg3");



        Collection<PSObject> result = ps1.Invoke();
        foreach (var outputObject in result)// outputObject contains the result of the powershell script
        {
            logger.LogInformation("result OnPremAbsoluteUrls.ps1 = " + outputObject.ToString());
        }
    }



    //        script ps1
    //        _______________________________________
    //         param([string]$siteUrlLink  = "siteUrlLink", [string]$driveListname = "driveListname", [string]$fileName = "fileName")
    //
    //
    //         Write-Host "Arg: $siteUrlLink";
    //         Write-Host "Arg: $driveListname";
    //         Write-Host "Arg: $fileName";
    //
    // #$return = .\foo.ps1
    //
    // #$e = get-winevent -FilterHashtable @{url='https://www.google.com'} -MaxEvents 1
    // #Invoke-WebRequest -Uri http://localhost/test -Method POST -Body ($e.Properties[0].Value | ConvertTo-Json) -ContentType "application/json"
    //
    //         return 'result: https://www.google.com end'

    //}
}