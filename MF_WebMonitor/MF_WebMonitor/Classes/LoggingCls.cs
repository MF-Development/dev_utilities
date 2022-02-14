using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;

namespace MF_WebMonitor.Classes
{
    public class LoggingCls
    {
        public static bool SendAndCreateNotification(string testBatch)
        {
            bool isSuccessful = true;

            List<WebMonitoringResultsCls> results = WebMonitoringResultsCls.GetResults(testBatch);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html><body><h1>Web Scenario Results</h1>");
            

            List<WebMonitoringResultsCls> failures = results.Where(r => r.Success == false && r.ExpectedToFail == false && r.IgnoreErrors == false).ToList();
            if (failures == null) failures = new List<WebMonitoringResultsCls>();

            int successes = results.Count - failures.Count;
            string mailSubject = "Web Monitoring Results for " + testBatch.ToString();
            bool firstTeeFailure = false;

            if (failures.Count > 0)
            {
                if (failures.Count > 1)
                    mailSubject = "Web Monitoring Results [FAILED] for " + testBatch.ToString();

                isSuccessful = false;

                sb.AppendLine("<h3>Failures</h3>");

                sb.AppendLine("<table><tr><th>Club</th><th>Club Name</th><th>Admin Url</th><th>Failure Reason</th><th>Other Failures in Last 24 Hours</th><th>Server</th></tr>");
                

                foreach (WebMonitoringResultsCls result in failures)
                {
                    if (!String.IsNullOrEmpty(result.ServerName))
                    {
                        try
                        {
                            string temp = ConfigurationManager.AppSettings[result.ServerName].ToString();
                            if (!String.IsNullOrEmpty(temp)) result.ServerName = temp;

                            if( result.ClubName.ToLower().Contains("the first tee"))
                            {
                                firstTeeFailure = true;
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                    sb.AppendLine("<tr>");
                    sb.AppendLine(String.Format("<td>{0}</td>", result.ClubID));
                    sb.AppendLine(String.Format("<td>{0}</td>", result.ClubName));
                    sb.AppendLine(String.Format("<td>{0}</td>", result.Url + "Admin"));
                    sb.AppendLine(String.Format("<td>{0}</td>", String.IsNullOrEmpty(result.FailureReason) ? "Unknown" : result.FailureReason));
                    sb.AppendLine(String.Format("<td>{0}</td>", result.FailuresInLast24Hours));
                    sb.AppendLine(String.Format("<td>{0}</td>", result.ServerName));
                    sb.AppendLine("</tr>");
                }

                sb.AppendLine("</table>");

                sb.AppendLine("<h3>Successes</h3>");
                sb.AppendLine("<p>Total Successful tests: " + successes.ToString() + "</p>");
            }
            else
            {
                sb.AppendLine("<p>No failures for this test batch.</p>");
                sb.AppendLine("<p>Total Successful tests: " + successes.ToString() + "</p>");
                sb.AppendLine("<h3>Successes</h3>");
            }

            sb.AppendLine("<table><tr><th>Club</th><th>Club Name</th><th>Admin Url</th><th>Server</th><th>&nbsp;</th></tr>");
                        
            foreach (WebMonitoringResultsCls result in results)
            {
                if (result.Success == false && result.IgnoreErrors == false) continue;
                if (result.ExpectedToFail == true && result.IgnoreErrors == false) continue;

                if (!String.IsNullOrEmpty(result.ServerName))
                {
                    try
                    {
                        string temp = ConfigurationManager.AppSettings[result.ServerName].ToString();
                        if (!String.IsNullOrEmpty(temp)) result.ServerName = temp;
                    }
                    catch (Exception ex)
                    {
                    }
                }

                sb.AppendLine("<tr>");
                sb.AppendLine(String.Format("<td>{0}</td>", result.ClubID));
                sb.AppendLine(String.Format("<td>{0}</td>", result.ClubName));
                sb.AppendLine(String.Format("<td>{0}</td>", result.Url + "Admin"));
                sb.AppendLine(String.Format("<td>{0}</td>", result.ServerName));
                sb.AppendLine(String.Format("<td>{0}</td>", result.FailureReason));
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</table>");

            sb.AppendLine("</body></html>");

            try
            {
                SmtpClient client = new SmtpClient();

                string msgTo = ConfigurationManager.AppSettings["SuccessEmail"].ToString();
                if (isSuccessful == false) msgTo = ConfigurationManager.AppSettings["FailureEmail"].ToString();

                List<String> addresses = new List<string>();
                if (msgTo.Contains(','))
                {
                    string[] msgTos = msgTo.Split(',');
                    foreach (string msgToAddr in msgTos)
                        addresses.Add(msgToAddr);
                }
                else
                    addresses.Add(msgTo);

                if (firstTeeFailure)
                {
                    addresses.Add(ConfigurationManager.AppSettings["FirstTeeFailureEmail"].ToString());
                }

                MailMessage mailMessage = new MailMessage();
                foreach (string addr in addresses)
                {
                    mailMessage.To.Add(addr);
                }
                
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = sb.ToString();
                mailMessage.Subject = mailSubject;
                client.Send(mailMessage);

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
