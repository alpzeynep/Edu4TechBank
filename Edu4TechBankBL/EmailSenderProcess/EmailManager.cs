using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Edu4TechBankBL.EmailSenderProcess
{
    public class EmailManager : IEmailManager
    {
        public bool SendEmail(EmailMessageModel model)
        {
            try
            {

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("hgyazilimsinifi@outlook.com");
                mail.To.Add(new MailAddress(model.To));
                mail.Subject = model.Subject;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.UTF8;
                mail.Body = model.Body;
                //Not: CC olacaksa buraya kodları eklememiz gerekiyor
                //Not: Bcc olacaksa buraya kodları eklememiz gerekiyor

                SmtpClient client = new SmtpClient();
                //Not: mayıs  2022 tarihine kadar gmail için de aynısını yapardık
                //Ama sistemi güvenlik nedeniyle değiştirdiler
                //Gmail kullanabilmemiz için gmailden token almamız gerekli

                //Not: Güvenlik nedeniyle hesabın şifresini ve adını böyle yazmamlıyız.
                //Veri tabanında Parameters ya da Degerler tablosu şeklinde bir tabloda tutabiliriz.
                client.Credentials = new System.Net.NetworkCredential("hgyazilimsinifi@outlook.com", "betulkadikoy2023");
                client.Port = 587; //25 
                client.Host = "smtp-mail.outlook.com";
                client.EnableSsl = true;


                client.Send(mail);
                return true;
            }
            catch (Exception)
            {

                return false;

            }

        }


        public async Task SendMailAsync(EmailMessageModel model)
        {
            try
            {

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("hgyazilimsinifi@outlook.com");
                mail.To.Add(new MailAddress(model.To));
                mail.Subject = model.Subject;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.UTF8;
                mail.Body = model.Body;
                //Not: CC olacaksa buraya kodları eklememiz gerekiyor
                //Not: Bcc olacaksa buraya kodları eklememiz gerekiyor

                SmtpClient client = new SmtpClient();
                //Not: mayıs  2022 tarihine kadar gmail için de aynısını yapardık
                //Ama sistemi güvenlik nedeniyle değiştirdiler
                //Gmail kullanabilmemiz için gmailden token almamız gerekli

                //Not: Güvenlik nedeniyle hesabın şifresini ve adını böyle yazmamlıyız.
                //Veri tabanında Parameters ya da Degerler tablosu şeklinde bir tabloda tutabiliriz.
                client.Credentials = new System.Net.NetworkCredential("hgyazilimsinifi@outlook.com", "betulkadikoy2023");
                client.Port = 587; //25 
                client.Host = "smtp-mail.outlook.com";
                client.EnableSsl = true;


                //client.SendAsync(mail, null); // void işaretlediğiniz metot ile kullabnılabilir
                await client.SendMailAsync(mail);

            }
            catch (Exception ex)
            {
                //logtablea kayıt atılabilir 

            }
        }
    }
}
