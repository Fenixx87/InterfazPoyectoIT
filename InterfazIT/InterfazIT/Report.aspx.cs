using DevExpress.BarCodes;
using DevExpress.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazIT
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLlenar_Click(object sender, EventArgs e)
        {
            
            XtraReport1 Page = new XtraReport1();
            //string ruta = "C:\\tempera\\reporte.pdf";

            String savePath = @"C:\tempera\";
            String savePathFirma = savePath + "SignTest.p12";
            // Llamamos al metodo SaveAs para guardar el archivo subido el ruta especificada.
            // Los archivos con el mismo nombre se sobrescribiran.
            //uso de libreria de DevExpress
            PdfDocumentProcessor documentProcessor = new PdfDocumentProcessor();
            //documento a firmar en pdf...*obligatorio
            //documentProcessor.LoadDocument(ruta);
            //certificado de la firma (documento con la firma electronica)...*obligatorio, clave de la firma...*obligatorio
            X509Certificate2 certificate = new X509Certificate2(savePathFirma, "amuzo2021A");
            //alias del certificado
            string nombre = certificate.FriendlyName;
            //fecha caducidad certificado
            var fechaCaducidad = Convert.ToDateTime(certificate.GetExpirationDateString());
            //fecha de firmado
            var fechaActual = Convert.ToDateTime(DateTime.Now);
            //resto 
            var rest = fechaCaducidad - fechaActual;
            var restDays = rest.ToString("dd");

            // Create a QR code.
            BarCode barCode = new BarCode();
            barCode.Symbology = Symbology.QRCode;
            barCode.CodeText = nombre + "\n" + "Dias de vigencia: " + restDays + "\n" + "www.firmadigital.gob.ec";
            barCode.BackColor = Color.White;
            barCode.ForeColor = Color.Black;
            barCode.RotationAngle = 0;
            barCode.CodeBinaryData = Encoding.Default.GetBytes(barCode.CodeText);
            barCode.Options.QRCode.CompactionMode = QRCodeCompactionMode.Byte;
            barCode.Options.QRCode.ErrorLevel = QRCodeErrorLevel.Q;
            barCode.Options.QRCode.ShowCodeText = true;
            barCode.CodeTextHorizontalAlignment = StringAlignment.Near;
            barCode.DpiX = 90;
            barCode.DpiY = 90;
            barCode.Module = 3f;

            //guardamos el QRCode como imagen ()
            barCode.Save(@"C:\tempera\BarCodeImage.png", System.Drawing.Imaging.ImageFormat.Png);
            String savePathImg = savePath + "BarCodeImage.png";

            //Metodo de relleno de reporte
            Page.InitData(txtName.Text, txtLastName.Text, savePathImg);

            Page.CreateDocument();
            //Especificar la ruta del servidor donde se guardaran los archivos.
            //cambiar ruta 
            string ruta = savePath + "reporte.pdf";
            Page.ExportToPdf(ruta);
            documentProcessor.LoadDocument(ruta);

            //Obtencion de datos de la firma
            string locacion = CmbLocacion.SelectedValue;
            string razon = txtRazon.Text;

            //imagen de la firma...*obligatorio
            byte[] imageData = File.ReadAllBytes(savePathImg);
            //posicion de la firma respecto al numero de pagina del documento...*obligatorio
            int pageNumber = 1;
            //angulo  de la firma
            //int angleInDegrees = 0;
            //conversion a radianes
            //double angleInRadians = angleInDegrees * (Math.PI / 180);
            //coordenadas de la firma ((x,y),relacion de aspecto?,angulo de la firma)
            //punto 0 fuera de la pagina
            PdfOrientedRectangle signatureBounds = new PdfOrientedRectangle(new PdfPoint(0, 0), 0, 0 /*,angleInRadians*/);
            //metodo firma de pdf 
            PdfSignature signature = new PdfSignature(certificate, imageData, pageNumber, signatureBounds);
            //detalles de la firma
            signature.Location = locacion;
            signature.Reason = razon;
            //signature.ContactInfo = infoContacto;

            //retorno de documento firmado
            string FinalPath = savePath + "SignedTest.pdf";
            documentProcessor.SaveDocument(FinalPath, new PdfSaveOptions() { Signature = signature });

            //previsualizacion de PDF
            FileStream fs = File.OpenRead(ruta);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, (int)fs.Length);
            fs.Close();

            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = "application/pdf";

            Response.BinaryWrite(data);
            Response.End();
        }

        protected void btnRedFirmar_Click(object sender, EventArgs e)
        {
            
            //Response.Redirect("archivo.aspx");
        }
    }
}