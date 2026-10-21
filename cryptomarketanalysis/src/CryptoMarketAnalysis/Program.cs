using System;
using Topshelf;

namespace CryptoMarketAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>                                   
            {
                x.Service<TwitterService>(s =>                                  
                {
                    s.ConstructUsing(name => new TwitterService());                
                    s.WhenStarted(tc => tc.Start());                         
                    s.WhenStopped(tc => tc.Stop());                         
                });
                x.RunAsLocalSystem();                                     

                x.SetDescription("CryptoMarketReader service");                   
                x.SetDisplayName("CryptoMarketReader");                                
                x.SetServiceName("CryptoMarketReader");                                 
            });                                                            

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  
            Environment.ExitCode = exitCode;
        }
    }
}
