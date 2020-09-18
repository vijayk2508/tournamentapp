using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using TMS.DTO;

namespace TMS.Library
{
    public class EmailSetting
    {
        /*//Provide your date format 
		string []format = new string []{"dd-MM-yyyy HH:mm:ss"};

		//Your sample date format
		string value = "29-10-2014 15:30:20";

		//Variable to hold the converted datetime
		DateTime datetime;

		//Check if string is a valid date by converting using DateTime.TryParseExact
		if (DateTime.TryParseExact(value, format, System.Globalization.CultureInfo.InvariantCulture,System.Globalization.DateTimeStyles.NoCurrentDateDefault  , out datetime))
		   Console.WriteLine("Valid  Date: " + datetime);
		else
		  Console.WriteLine("Invalid Date");*/
        private const string sOwnerEmail = "asonv.tech@gmail.com";
        private const string sAppPassword = "zsbqbqnhhawlbqeo";

        private static string MailToAddress;
        private const string MailFromAddress = sOwnerEmail;
        private const bool UseSsl = true;
        private const string Username = sOwnerEmail;
        private const string Password = sAppPassword;
        private const string ServerName = "smtp.gmail.com";
        private const int ServerPort = 587;

        #region is Email Exist on Mail Server 
        private bool isEmailExist(string sEmail)
        {
            TcpClient tClient = new TcpClient("gmail-smtp-in.l.google.com", 25);
            string CRLF = "\r\n";
            byte[] dataBuffer;
            string ResponseString;
            NetworkStream netStream = tClient.GetStream();
            StreamReader reader = new StreamReader(netStream);
            ResponseString = reader.ReadLine();

            /* Perform HELO to SMTP Server and get Response */
            dataBuffer = BytesFromString("HELLO KirtanHere" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            ResponseString = reader.ReadLine();
            dataBuffer = BytesFromString("MAIL FROM:<asonv.technology@gmail.com>" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            ResponseString = reader.ReadLine();

            /* Read Response of the RCPT TO Message to know from google if it exist or not */
            dataBuffer = BytesFromString("RCPT TO:<" + sEmail + ">" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            ResponseString = reader.ReadLine();
            bool isExist = GetResponseCode(ResponseString) == 550 ? false : true;

            /* QUITE CONNECTION */

            dataBuffer = BytesFromString("QUITE" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            tClient.Close();

            return isExist;
        }

        private byte[] BytesFromString(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }

        private int GetResponseCode(string ResponseString)
        {
            return int.Parse(ResponseString.Substring(0, 3));
        }
        #endregion

        #region SentEmail
        public static bool SendForgotPassword(PlayerDTO dtoPlayer)
        {

            #region Send Email
            //MailMessage msg = new MailMessage
            //{
            //    From = new MailAddress(sOwnerEmail)
            //};
            //msg.To.Add(dtoPlayer.Player_Email);
            //msg.Subject = "Tournament !!";
            //msg.Body = "Your password is:" + dtoPlayer.Player_Password;
            //msg.IsBodyHtml = true;

            //SmtpClient smt = new SmtpClient
            //{
            //    Host = "smtp.gmail.com"
            //};
            //NetworkCredential ntwd = new NetworkCredential(sOwnerEmail, sAppPassword);

            //smt.UseDefaultCredentials = true;
            //smt.Credentials = ntwd;
            //smt.Port = 587;
            //smt.EnableSsl = true;

            //bool bStatus = false;
            //try
            //{
            //    smt.Send(msg);

            //    // msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            //    switch (msg.DeliveryNotificationOptions)
            //    {
            //        case DeliveryNotificationOptions.OnFailure:
            //            bStatus = false;
            //            break;
            //        case DeliveryNotificationOptions.OnSuccess:
            //            bStatus = true;
            //            break;
            //    }
            //}
            //catch (SmtpFailedRecipientException)
            //{
            //    bStatus = false;
            //}
            #endregion

            bool bStatus = false;

            #region Send Mail
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = UseSsl;
                smtpClient.Host = ServerName;
                smtpClient.Port = ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(Username, Password);

                StringBuilder body = new StringBuilder()
                    .AppendLine("<html>")
                    .AppendLine("<title>")
                    .AppendLine("</title>")
                    .AppendLine("<body>")
                    .AppendLine("your forgot password !!")
                    .AppendFormat("<br>Hi {0:c}", dtoPlayer.Player_Name)
                    .AppendLine("<br>------------------------------------")
                    .AppendFormat("<br>Your Email : {0:c}", dtoPlayer.Player_Email)
                    .AppendFormat("<br>Your Password : {0:c}", dtoPlayer.Player_Password)
                    .AppendLine("<br>------------------------------------")
                    .AppendLine("</body>")
                    .AppendLine("</html>");

                MailToAddress = dtoPlayer.Player_Email;
                MailMessage mailMessage = new MailMessage(
                                MailFromAddress,
                                MailToAddress,
                                "Forgot Password!!!",
                                body.ToString());
                mailMessage.IsBodyHtml = true;
                
                try
                {
                    smtpClient.Send(mailMessage);
                    bStatus = true;
                }
                catch (SmtpException ex)
                {
                    bStatus = false;
                }
            }

            #endregion
            return bStatus;
        }
        #endregion 
    }
}
