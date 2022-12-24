using System.IO.Compression;

namespace ConsoleApp1;

public class OnPremAbsoluteURLs
{
    public static void InitMakeAbsoluteUrlsScript()
    {
        //запускаем скрипт
        //что является триггером для запуска?
        //как передавать сайт?
        
        
        
    }
    
    
    public static void powershelling()
    {
        string ps;
        ps = @"C:\Users\Professional\Desktop\Programming\foo.ps1";
        System.Diagnostics.Process
            .Start(@"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe", 
                ps + " http://stpa01z502/sites/TestOne" + " arg2" + " arg3");
        
//         
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

    }
}