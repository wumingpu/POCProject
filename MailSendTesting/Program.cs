using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailSendTesting
{
    class Program
    {
        static bool mailSent = false;
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
            mailSent = true;
        }
        static void Main(string[] args)
        {
            //System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            //client.Host = "smtp.office365.com";//邮件服务器
            //client.Port = 587;//smtp主机上的端口号,默认是25.
            //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;//邮件发送方式:通过网络发送到SMTP服务器
            //client.Credentials = new System.Net.NetworkCredential("BCI-Athena@us.beyondsoft.com", "Athena@BCI");//凭证,发件人登录邮箱的用户名和密码
            //client.EnableSsl = true;

            ////电子邮件信息类
            //System.Net.Mail.MailAddress fromAddress = new System.Net.Mail.MailAddress("BCI-Athena@us.beyondsoft.com");//发件人Email,在邮箱是这样显示的,[发件人:小明<panthervic@163.com>;]
            //System.Net.Mail.MailAddress toAddress = new System.Net.Mail.MailAddress("wuming3019@126.com");//收件人Email,在邮箱是这样显示的, [收件人:小红<43327681@163.com>;]
            //System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage(fromAddress, toAddress);//创建一个电子邮件类
            //mailMessage.Subject = "邮件的主题";
            //string mailBody = "";
            //mailMessage.Body = mailBody;//可为html格式文本
            //                            //mailMessage.Body = "邮件的内容";//可为html格式文本
            //mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;//邮件主题编码
            //mailMessage.BodyEncoding = System.Text.Encoding.GetEncoding("GB2312");//邮件内容编码
            //mailMessage.IsBodyHtml = true;//邮件内容是否为html格式
            //mailMessage.Priority = System.Net.Mail.MailPriority.High;//邮件的优先级,有三个值:高(在邮件主题前有一个红色感叹号,表示紧急),低(在邮件主题前有一个蓝色向下箭头,表示缓慢),正常(无显示).
            //try
            //{
            //    client.Send(mailMessage);//发送邮件
            //    //client.SendAsync(mailMessage, "ojb");//异步方法发送邮件,不会阻塞线程.
            //}
            //catch (Exception e)
            //{
            //}
            //"wuming3019@126.com;tianyao.gu@us.beyondsoft.com;tianyao19840910@163.com"
            SendMail("wuming3019@126.com");
            SendMail("tianyao.gu@us.beyondsoft.com");
            SendMail("tianyao19840910@163.com");
            SendMail("v-mingpw@microsoft.com");
            SendMail("v-huicw@microsoft.com");
            Console.ReadLine();
        }

        private static void SendMail(string mailAdress)
        {
            // Command line argument must the the SMTP host.
            //using ()
            //{
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.office365.com";//邮件服务器
            client.Port = 587;//smtp主机上的端口号,默认是25.
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;//邮件发送方式:通过网络发送到SMTP服务器
            client.Credentials = new System.Net.NetworkCredential("BCI-Athena@us.beyondsoft.com", "Athena@BCI");//凭证,发件人登录邮箱的用户名和密码
            client.EnableSsl = true;
            // Specify the e-mail sender.
            // Create a mailing address that includes a UTF8 character
            // in the display name.
            MailAddress from = new MailAddress("BCI-Athena@us.beyondsoft.com",
               "BeyondSoft",
            System.Text.Encoding.UTF8);
            // Set destinations for the e-mail message.
            MailAddress to = new MailAddress(mailAdress);
            // Specify the message content.
            MailMessage message = new MailMessage(from, to);
            message.Body = "This is a test e-mail message sent by an application. ";
            // Include some non-ASCII characters in body and subject.
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            message.Body += Environment.NewLine + someArrows + Environment.NewLine + "Thanks," + Environment.NewLine + "Mingpu Wu";
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "test Mail From BeyondSoft Athena";
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            // Set the method that is called back when the send operation ends.
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            // The userState can be any object that allows your callback 
            // method to identify this send operation.
            // For this example, the userToken is a string constant.
            string userState = "test message1";
            client.SendAsync(message, userState);
            Console.WriteLine("Sending message... press c to cancel mail. Press any other key to exit.");
            string answer = Console.ReadLine();
            // If the user canceled the send, and mail hasn't been sent yet,
            // then cancel the pending operation.
            if (answer.StartsWith("c") && mailSent == false)
            {
                client.SendAsyncCancel();
            }
            //}
            // Clean up.
            message.Dispose();
            Console.WriteLine("Goodbye.");
        }
    }
}
