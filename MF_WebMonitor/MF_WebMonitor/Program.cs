using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;

using MF_WebMonitor.Classes;
using System.Net;
using System.Diagnostics;

namespace MF_WebMonitor
{
    class Program
    {
        static void Main(string[] args)
        {       
            try
            {
                if (DateTime.Now.Hour == 5)
                    WebApplicationCls.ArchiveData();

                DateTime testBatch = DateTime.Now;
                List<WebApplicationCls> apps = WebApplicationCls.GetWebApplications();
                foreach (WebApplicationCls app in apps)
                {
                    try
                    {

                        app.TestBatch = testBatch;
                        app.ExecuteWebTest(true);

                        if (app.Retest == true)
                            app.ExecuteWebTest(true);
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                    }
                }

                apps = WebApplicationCls.GetAdditionalApplications();
                foreach (WebApplicationCls app in apps)
                {
                    try
                    {

                        app.TestBatch = testBatch;
                        app.ExecuteWebTest(true);

                        if (app.Retest == true)
                            app.ExecuteWebTest(true);
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                    }
                }

                LoggingCls.SendAndCreateNotification(testBatch.ToString());

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("MF_WebMonitor", String.Format("Failure during MF_Monitor. {0}", ex.Message), EventLogEntryType.Error);
            }
        }
    }
}
