using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Model
{
    public class sms
    {

        private WebProxy objProxy1 = null;
        Communication_model mdl = new Communication_model();
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
        public string SendSMS(string User, string password, string Mobile_Number, string Message, string Mtype)
        {
            System.Object stringpost = "User=" + User + "&passwd=" + password + "&mobilenumber=" + Mobile_Number + "&message=" + Message + "&MType=" + Mtype;
            HttpWebRequest objWebRequest = null;
            HttpWebResponse objWebResponse = null;
            StreamWriter objStreamWriter = null;
            StreamReader objStreamReader = null;
            try
            {
                string stringResult = null;
                objWebRequest = (HttpWebRequest)WebRequest.Create("https://www.smscountry.com/SMSCwebservice_bulk.aspx?");
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
        public string SendSMS(string User, string password, string Mobile_Number, string Message, string Mtype, string DR)
        {
            System.Object stringpost = "User=" + User + "&passwd=" + password + "&mobilenumber=" + Mobile_Number + "&message=" + Message + "&MType=" + Mtype + "&DR=" + DR;
            HttpWebRequest objWebRequest = null;
            HttpWebResponse objWebResponse = null;
            StreamWriter objStreamWriter = null;
            StreamReader objStreamReader = null;
            try
            {
                string stringResult = null;
                objWebRequest = (HttpWebRequest)WebRequest.Create("https://www.smscountry.com/SMSCwebservice_bulk.aspx?");
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
        public string SendSMS(string User, string password, string Mobile_Number, string Message, string Mtype, string DR, string SID)
        {
            System.Object stringpost = "User=" + User + "&passwd=" + password + "&mobilenumber=" + Mobile_Number + "&message=" + Message + "&MType=" + Mtype + "&DR=" + DR + "&SID=" + SID;
            HttpWebRequest objWebRequest = null;
            HttpWebResponse objWebResponse = null;
            StreamWriter objStreamWriter = null;
            StreamReader objStreamReader = null;
            try
            {
                string stringResult = null;
                objWebRequest = (HttpWebRequest)WebRequest.Create("https://www.smscountry.com/SMSCwebservice_bulk.aspx?");
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
        public string SendSMS(string User, string password, string Mobile_Number, string Message, string SID, string Sname, string scheduledDate, string systemdate)
        {
            System.Object stringpost = "User=" + User + "&passwd=" + password + "&mobilenumber=" + Mobile_Number + "&message=" + Message + "&SenderName=" + SID + "&schedulerName=" + Sname + "&ScheduledDateTime=" + scheduledDate + "&systemcurrenttime=" + systemdate + "&interval=0";
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
