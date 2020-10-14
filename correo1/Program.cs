using System;
using System.Net.Mail;

namespace correo1
{
    class Program
    {
        static void Main(string[] args)
        {
            string EmailOrigen = "pruebasumg2020@gmail.com";
            string Contrasenia = "Recon2020";
            string EmailDestino;
            String sAsunto;
            String sMensaje;

            Console.Write("Email destino: ");
            EmailDestino = Console.ReadLine();

            Console.Write("Asunto del correo: ");
            sAsunto = Console.ReadLine();

            Console.Write("Escriba el mensaje del correo: ");
            sMensaje = Console.ReadLine();

            //Objetos para el mensaje
            //1. Creo objeto mensaje y lo instancio
            MailMessage oMailMessage = new MailMessage(EmailOrigen,EmailDestino, sAsunto, sMensaje);

            //2. Habilitar opcion
            oMailMessage.IsBodyHtml = true;

            //3. Creo objeto cliente de smtp
            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");

            //4. Habilitar seguridad SSL credenciales defaul
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;

            //5. Habilitar puerto
            oSmtpClient.Port = 587;

            //6. Habilitar credenciales
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contrasenia);

            //7. Enviar correo con el objeto mensaje
            try
            {
                oSmtpClient.Send(oMailMessage);
                Console.Clear();
                Console.WriteLine("Correo enviado exitosamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un error enviando el correo hacia el destinatario ", ex.ToString());
            }

            //8. Destruir objetos despues de enviar todo
            oSmtpClient.Dispose();
             
         }
    }
}
