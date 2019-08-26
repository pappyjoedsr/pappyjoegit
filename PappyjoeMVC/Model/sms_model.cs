using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Model
{
    public class sms_model
    {
        private WebProxy objProxy1 = null;
        public string SendSMS(string User, string password, string Mobile_Number, string Message)
        {
            string stringpost = null;
            stringpost = "User=" + User + "&passwd=" + password + "&mobilenumber=" + Mobile_Number + "&message=" + Message;
            HttpWebRequest objWebRequest = null;
            HttpWebResponse objWebResponse = null;
            StreamWriter objStreamWriter = null;
            StreamReader objStreamReader = null;
            try
            {
                string stringResult = null;
                objWebRequest = (HttpWebRequest)WebRequest.Create("https://www.smscountry.com/SMSCwebservice_bulk.aspx");
                objWebRequest.Method = "POST";
                if ((objProxy1 != null))
                {
                    objWebRequest.Proxy = objProxy1;
                }
                // Use below code if you want to SETUP PROXY.
                //Parameters to pass: 1. ProxyAddress 2. Port
                //You can find both the parameters in Connection settings of your internet explorer.
                //WebProxy myProxy = new WebProxy("YOUR PROXY", PROXPORT);
                //myProxy.BypassProxyOnLocal = true;
                //wrGETURL.Proxy = myProxy;
                objWebRequest.ContentType = "application/x-www-form-urlencoded";
                objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
                objStreamWriter.Write(stringpost);
                objStreamWriter.Flush();
                objStreamWriter.Close();
                objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
                objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
                stringResult = objStreamReader.ReadToEnd();
                objStreamReader.Close();
                return stringResult;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if ((objStreamWriter != null))
                {
                    objStreamWriter.Close();
                }
                if ((objStreamReader != null))
                {
                    objStreamReader.Close();
                }
                objWebRequest = null;
                objWebResponse = null;
                objProxy1 = null;
            }
        }

        private void StreamReader(Stream stream)
        {
            throw new NotImplementedException();
        }

        public string SendSMS(string User, string password, string Mobile_Number, string Message, string SID, string Sname, string scheduledDate, string systemdate)
        {
            //user=drtoms&passwd=gknco113&RID=10&mobilenumber=9037851234&message=hi dear&SenderName=DRTOMS&schedulerName=AS1&ScheduledDateTime=20/11/2015 12:10:00 PM&systemcurrenttime=20/11/2015 10:40:00 AM&interval=0


            System.Object stringpost = "User=" + User + "&passwd=" + password + "&mobilenumber=" + Mobile_Number + "&message=" + Message + "&SenderName=" + SID + "&schedulerName=" + Sname + "&ScheduledDateTime=" + scheduledDate + "&systemcurrenttime=" + systemdate + "&interval=0";
            //string functionReturnValue = null;
            //functionReturnValue = "";
            HttpWebRequest objWebRequest = null;
            HttpWebResponse objWebResponse = null;
            StreamWriter objStreamWriter = null;
            StreamReader objStreamReader = null;
            try
            {
                string stringResult = null;
                objWebRequest = (HttpWebRequest)WebRequest.Create("https://www.smscountry.com/APISetReminder.asp?");
                objWebRequest.Method = "POST";

                if ((objProxy1 != null))
                {
                    objWebRequest.Proxy = objProxy1;
                }

                objWebRequest.ContentType = "application/x-www-form-urlencoded";
                objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
                objStreamWriter.Write(stringpost);
                objStreamWriter.Flush();
                objStreamWriter.Close();
                objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
                objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
                stringResult = objStreamReader.ReadToEnd();
                objStreamReader.Close();
                return (stringResult);
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
            finally
            {
                if ((objStreamWriter != null))
                {
                    objStreamWriter.Close();
                }
                if ((objStreamReader != null))
                {
                    objStreamReader.Close();
                }
                objWebRequest = null;
                objWebResponse = null;
                objProxy1 = null;
            }
        }
    }
}
