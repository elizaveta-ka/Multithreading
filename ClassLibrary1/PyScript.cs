using System.Diagnostics;

namespace ClassLibrary1;

public class PyScript
{
    public static void PyScriptInit()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo(@"C:\Users\Professional\PycharmProjects\ParseProjectPython\src\test.py");
        Process process = new Process();

        string directory = @"C:\Users\Professional\PycharmProjects\ParseProjectPython\src\";
        string script = "test.py one two three";

        startInfo.WorkingDirectory = directory;
        startInfo.Arguments = script;
        startInfo.UseShellExecute = false;
        startInfo.CreateNoWindow = true;
        startInfo.RedirectStandardError = true;
        startInfo.RedirectStandardOutput = true;
        
        
        process.StartInfo = startInfo;

        process.Start();
        // using BinaryReader reader = new BinaryReader(process.StandardOutput.BaseStream);
        StreamReader reader = new StreamReader(process.StandardOutput.BaseStream);
        
        // int result = reader.ReadInt32();
        String result = reader.ReadToEnd();

        Console.WriteLine(result);

        Console.ReadKey(false);

        process.Close();
        
    }
    
    
    public static string RunPython()
    {
        string args = "test.exe one two three";
        string cmd = "python";
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = @"C:\Users\Professional\PycharmProjects\ParseProjectPython\output\test\test.exe";
        start.Arguments = string.Format("\"{0}\" \"{1}\"", cmd, args);
        start.UseShellExecute = false;
        start.CreateNoWindow = true;
        start.RedirectStandardOutput = true;
        start.RedirectStandardError = true;
        using (Process process = Process.Start(start))
        {
            using (StreamReader reader = process.StandardOutput)
            {
                string stderr = process.StandardError.ReadToEnd();
                string result = reader.ReadToEnd();
                Console.WriteLine(result);
                return result;
            }
        }
    }

    public static void NewRunPy()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        Process process = new Process();
        
        string script = @"C:\Users\Professional\PycharmProjects\ParseProjectPython\src\test.py";
        
        startInfo.FileName = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
        startInfo.Arguments = script + " one" + " two" + " three"; 
        startInfo.UseShellExecute = false;
        startInfo.CreateNoWindow = true;
        startInfo.RedirectStandardError = true;
        startInfo.RedirectStandardOutput = true;
        
        process.StartInfo = startInfo;
        
        process.Start();

        string result = process.StandardOutput.ReadToEnd();
        Console.WriteLine("Result: " + result);
        process.WaitForExit();


        // string script;
        // script = @"C:\Users\Professional\PycharmProjects\ParseProjectPython\output\test\test.exe";
        // var smth = Process.Start(@"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe",
        //     script + " one" + " two" + " three");
    }
}