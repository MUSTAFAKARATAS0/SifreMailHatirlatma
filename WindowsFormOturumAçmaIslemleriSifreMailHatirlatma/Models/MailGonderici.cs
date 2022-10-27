using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WindowsFormOturumAçmaIslemleriSifreMailHatirlatma.Models;
using System.Data.Entity.Core.Metadata.Edm;

namespace WindowsFormOturumAçmaIslemleriSifreMailHatirlatma.Models
{
    public class MailGonderici
    {
        WindowsFormOturumAçmaIslemleriSifreMailHatirlatmaEntitiesConnectionDb db = new WindowsFormOturumAçmaIslemleriSifreMailHatirlatmaEntitiesConnectionDb();
        public void Microsoft(string GondericiMail, string GondericiPass, string AliciMail)
        {
            PersonelGirisTablosu p =db.PersonelGirisTablosu.FirstOrDefault(x=>x.MailAdress==GondericiMail);
            //Random rnd = new Random();
            //p.Password = rnd.Next(1000, 10000).ToString();
            //db.SaveChanges();   
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.outlook.com";
            sc.EnableSsl = true;
            sc.Credentials = new NetworkCredential(GondericiMail, GondericiPass);

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(GondericiMail,"oturum açma örenk projesi");
            mail.To.Add(AliciMail);
            mail.Subject = "Şİfre sıfırlama talebinde bulundunuz";
            mail.IsBodyHtml = true;
            mail.Body = $@"{DateTime.Now.ToString()} Tarihinde şifre sıfırlama talebinde bulundunuz.Yeni şifreniz{p.Password}";
            
            sc.Send(mail);
        }   
    }
}
