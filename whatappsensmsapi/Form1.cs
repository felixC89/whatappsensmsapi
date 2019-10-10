//link to site api: https://niceapi.net  ********************ESTA APP ENVIA MENSAJES DE WHASTAPP A LOS NUMEROS REGISTRADOS EN ESTA CUENTA: felix2019  
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.IO;

namespace whatappsensmsapi
{
    public partial class whatsappsender : Form
    {
        
        public whatsappsender()
        {
            InitializeComponent();
        }

        private void btnenviar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
          
            string yourid = "HauDGis1ukC6ZPDwUvrfgmZlbGl4X2RvdF9jYWxkZXJvbl9kb3RfbmljX2F0X2dtYWlsX2RvdF9jb20=";
            string yourmobile = "";
            string mensaje = tbmensaje.Text;

            if (rb1.Checked)
            {
                yourmobile = "+50557421576";
            }
            else if (rb2.Checked)
            {
                yourmobile = "+50588299992";
            }
            else 
            {
                MessageBox.Show("No se ha seleccionado ningun numero");
                this.Cursor = Cursors.Default;
                Application.Exit();
            }

            try
            {
                string url = "https://NiceApi.net/API";
                HttpWebRequest request =(HttpWebRequest)WebRequest.Create(url);
                request.Method="POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("X-APIId",yourid);
                request.Headers.Add("X-APIMobile",yourmobile);

                using(StreamWriter StreamOut = new StreamWriter(request.GetRequestStream()))
                {
                    StreamOut.Write(mensaje);
                }
                using (StreamReader StreamIn = new StreamReader(request.GetResponse().GetResponseStream())) 
                {
                    Console.WriteLine(StreamIn.ReadToEnd());
                }

                MessageBox.Show("El mensaje se ha enviado");
                tbmensaje.Text = "";
                this.Cursor = Cursors.Default;
            }
            catch (SystemException ex)
            {

                Console.WriteLine(ex.Message);//throw;
            }

        }
    }
}
