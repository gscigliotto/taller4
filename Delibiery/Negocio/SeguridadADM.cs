using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class SeguridadADM
    {
        public static String EncodePassword(String txt)
        {
            HashAlgorithm hashProvider = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.ASCII.GetBytes(txt);
            return ArrayToString(hashProvider.ComputeHash(bytes));
        }

        private static string ArrayToString(byte[] byteArray)
        {
            StringBuilder builder = new StringBuilder(byteArray.Length);
            for (int i = 0; i < byteArray.Length; i++)
            {
                builder.Append(byteArray[i].ToString("X2"));
            }
            return builder.ToString();
        }


        public static string CrearPassword(int longitud)
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return res.ToString();
        }


        public static void SendMailSinConfig(List<string> destinatario, String subject, String body)
        {

            //
            // se crea el mensaje
            //



            MailMessage mail = new MailMessage()
            {
                From = new MailAddress("delibiery.msmm@gmail.com"),
                Body = body,
                Subject = subject,
                IsBodyHtml = false
            };


            //
            // se asignan los destinatarios
            //
            foreach (string item in destinatario)
            {
                mail.To.Add(new MailAddress(item));
            }


            //
            // se define el smtp
            //
            SmtpClient smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("delibiery.msmm@gmail.com", "ort22b2018"),
                EnableSsl = true
            };


            smtp.Send(mail);

        }

    }
}
