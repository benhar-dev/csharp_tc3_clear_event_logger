using System;
using TcEventLoggerAdsProxyLib;

namespace ConsoleApplication1
{
    class Program
    {
        private const int LangId = 1031;
        private static void Main()
        {
            var logger = new TcEventLogger();

            try
            {
                logger.Connect(); //connect to localhost
                Console.WriteLine("Connected...waiting for events");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to connect to event logger with exception:" + ex);
            }

            try
            {
                TcLoggedEventCollection e = logger.GetLoggedEvents(100);
                int count = e.Count;

                Console.WriteLine("Event log count: " + count);

                if (logger.IsConnected && count != 0)
                {
                    // Call ClearAllAlarms first to ensure ClearLoggedEvents removes everything.
                    logger.ClearAllAlarms();
                    logger.ClearLoggedEvents();

                    Console.WriteLine("Event log count after clear: " + e.Count);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Logger terminated with exception:" + ex);
            }

        }

     }
}
