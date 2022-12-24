namespace ConsoleApp1;

using System.Diagnostics;

public class MultiThreading
{
    
    public void Init()
    {
    // Create List<>
            // Add all files all directories to List
            //While or foreach for all files in List 
            // Open Threads

            List<string> listAllFiles = new List<string>();
            
            DirectoryInfo DirInfo = new DirectoryInfo(@"/Users/elizavetakabak/Example");
                
                openDirectory(listAllFiles, DirInfo);
                List<Thread> threads = new List<Thread>();
                
                foreach (var element in listAllFiles)
                {
                    // Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess().Threads.Count.ToString());
                    while (threads.Count() > 20)
                    {
                        for (int i = 0; i < threads.Count(); i++)
                        {
                            if (!threads[i].IsAlive)
                            {
                                threads.Remove(threads[i]);
                            }
                        }
                        if(threads.Count() > 20)
                        Thread.Sleep(1000);
                    }

                    Thread thread = new Thread(() => Function1(listAllFiles, element))
                    {
                        // IsBackground = true,  //выполнение при закрытии программы
                        // Priority = ThreadPriority.Highest
                    }; // Создаём поток
                    threads.Add(thread);
                    thread.Start(); // Запуск потока
                }
        }
            
            //рекурсия?

            static void openDirectory(List<string> listFiles, DirectoryInfo directoryInfo)
            {
                var directories = directoryInfo.GetDirectories();
                foreach (var directory in directories)
                {
                    openDirectory(listFiles,directory); //?
                    var files = from file in directory.EnumerateFiles() 
                        select file;
                    foreach (var file in files)
                    {
                        listFiles.Add(file.FullName);
                    }
                }
            }
            
            
            static void Function1(List<string> listAllFiles, string pathToFile)
        {   
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (listAllFiles.Contains(pathToFile))
            {
                String line;
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(pathToFile);
                    //Read the first line of text
                    line = sr.ReadLine();
                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        //write the line to console window
                        Console.WriteLine(line);
                        Console.WriteLine("----------------------------");
                        //Read the next line
                        line = sr.ReadLine();
                    }

                    //close the file
                    sr.Close();
                    Console.ReadLine();
                    // listAllFiles.Remove(pathToFile);

                    stopwatch.Stop();
                    // Console.WriteLine(stopwatch.ElapsedMilliseconds);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                // finally
                // {
                //     Console.WriteLine("Executing finally block.");
                // }
            }
        }

}