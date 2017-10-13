using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using System.Net;
using IOPSBackend.Models;
using MimeKit.Cryptography;
using System.Text;
using IOPSBackend.Repositories;
using IOPSBackend.Consts;

namespace IOPSBackend.Services
{
    public class SendMailService
    {
        UserRepository _userrepo;
        public SendMailService(UserRepository repo){
            _userrepo = repo;
        }

        public async Task Send(string subject,string to,string email,string body){
			try
			{
				//From Address  
				string FromAddress = "iops.no.reply@gmail.com";
				string FromAdressTitle = "IOPS";
				//To Address  
				string ToAddress = email;
				string ToAdressTitle = to;
				string Subject = subject;
                string BodyContent = body;


				//Smtp Server  
				string SmtpServer = "smtp.gmail.com";
				//Smtp Port Number  
				int SmtpPortNumber = 587;

				var mimeMessage = new MimeMessage();
				mimeMessage.From.Add(new MailboxAddress(FromAdressTitle, FromAddress));
				mimeMessage.To.Add(new MailboxAddress(ToAdressTitle, ToAddress));
				mimeMessage.Subject = Subject;
				mimeMessage.Body = new TextPart("plain")
				{
					Text = BodyContent

				};

				using (var client = new SmtpClient())
				{
					client.ServerCertificateValidationCallback = (s, c, h, e) => true;

					client.Connect(SmtpServer, SmtpPortNumber, SecureSocketOptions.Auto);
					// Note: only needed if the SMTP server requires authentication  
					// Error 5.5.1 Authentication   
					client.Authenticate("iops.no.reply@gmail.com", "Iops6164");
					client.Send(mimeMessage);
					Console.WriteLine("The mail has been sent successfully !!");
					client.Disconnect(true);

				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
        }

        public async Task SendMailConfirmationToContestantAsync(Contestant c)
        {
            string toGenerate = c.EmailAddress + " " + c.RegistrationDate.ToString();

            Console.WriteLine("to Hash {0} - > Hashed {1}", toGenerate, CalculateMD5Hash(toGenerate));

            _userrepo.SetConfirmationHash(c, CalculateMD5Hash(toGenerate));
            var body = "please click on the link below to confirm your account in IOPS \n "+Settings.URLFRONTEND+"?c="+CalculateMD5Hash(toGenerate);
            await Send("Mail confirmation", c.FirstName + " " + c.LastName, c.EmailAddress, body);
        }

        public string CalculateMD5Hash(string input)

		{

			// step 1, calculate MD5 hash from input

			MD5 md5 = MD5.Create();

			byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

			byte[] hash = md5.ComputeHash(inputBytes);

			// step 2, convert byte array to hex string

			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < hash.Length; i++)

			{

				sb.Append(hash[i].ToString("X2"));

			}

			return sb.ToString();

		}

    }
}
