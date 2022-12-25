using ConsoleApp1;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Application

{
    class Program
    {

        //example multithreading
        static public void Main()
        {

            var logger = LoggerFactory.Create(builder => builder.AddNLog()).CreateLogger<Program>();
            logger.LogInformation("Program has started..............");
            
            OnPremAbsoluteURLs onPremAbsoluteURLs = new OnPremAbsoluteURLs();
            onPremAbsoluteURLs.powershelling();

            // ============ //

            //Работает в фоновом режиме

            //Сохранение в базу матрицы ссылок

            //скрипт для создания абсолютных ссылок

            // ============ //


            //Load.DownLoadFiles();

            //многопоточка, в которой запускается:

            //Python script

            //Load.UpLoadFiles();

            //Скрипт с правами

        }

    }
}