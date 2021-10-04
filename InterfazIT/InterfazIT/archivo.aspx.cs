using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Pdf;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace InterfazIT
{
    public partial class archivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            // Especificar la ruta del servidor donde se guardaran los archivos.
            String savePath = @"C:\tempera\";

            // Antes de iniciar validaremos que los FileUpload contengan datos.
            if (FileUpload1.HasFile && FileUpload2.HasFile && FileUpload3.HasFile)
            {
                // Obtenemos el nombre del archivo a subir.
                string filePDF = Server.HtmlEncode(FileUpload1.FileName);
                string fileFirma = Server.HtmlEncode(FileUpload2.FileName);
                string fileImg = Server.HtmlEncode(FileUpload3.FileName);

                // Obtenemos la extension del archivo a subir.
                string extensionPDF = System.IO.Path.GetExtension(filePDF);
                string extensionFirma = System.IO.Path.GetExtension(fileFirma);
                string extensionImg = System.IO.Path.GetExtension(fileImg);

                if (extensionPDF == ".pdf" && extensionFirma == ".p12" &&
                    (extensionImg == ".jpg" || extensionImg == ".png"))
                {
                    // Concatenamos el nombre del archivo con la ruta del servidor.
                    String savePathPDF = savePath + filePDF;
                    String savePathFirma = savePath + fileFirma;
                    String savePathImg = savePath + fileImg;

                    // Llamamos al metodo SaveAs para guardar el archiv osubido el ruta especificada.
                    // Los archivos con el mismo nombre se sobrescribiran.
                    FileUpload1.SaveAs(savePathPDF);
                    FileUpload2.SaveAs(savePathFirma);
                    FileUpload3.SaveAs(savePathImg);

                    using (PdfDocumentProcessor documentProcessor = new PdfDocumentProcessor())
                    {
                        //documento a firmar en pdf...*obligatorio
                        documentProcessor.LoadDocument(savePathPDF);
                        //certificado de la firma (documento con la firma electronica)...*obligatorio, clave de la firma...*obligatorio
                        X509Certificate2 certificate = new X509Certificate2(savePathFirma, "amuzo2021A");
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
                        PdfOrientedRectangle signatureBounds = new PdfOrientedRectangle(new PdfPoint(70, 90), 70, 50 /*,angleInRadians*/);
                        //metodo firma de pdf 
                        PdfSignature signature = new PdfSignature(certificate, imageData, pageNumber, signatureBounds);

                        //detalles de la firma
                        signature.Location = "USA";
                        signature.ContactInfo = "john.smith@example.com";
                        signature.Reason = "Approved";

                        //retorno de documento firmado
                        string FinalPath = savePath + "SignedTest.pdf";
                        documentProcessor.SaveDocument(FinalPath, new PdfSaveOptions() { Signature = signature });
                        FileStream fs = File.OpenRead(FinalPath);
                        byte[] data = new byte[fs.Length];
                        fs.Read(data, 0, (int)fs.Length);
                        fs.Close();

                        Response.Buffer = true;
                        Response.Clear();
                        Response.ContentType = "application/pdf";

                        Response.BinaryWrite(data);
                        Response.End();
                    }
                    // Notificamos al usuario que su archivo ha sido subido con exito.
                    UploadStatusLabel.Text = "Tus archivos han sido subidos con éxito!";
                }
                else
            {
                // Notificamos al usuario que su archivo tiene una extension no valida dentro de los
                // parametros antes asignados.
                UploadStatusLabel.Text = "Seleccione archivos validos.";
                }
            }
            else
            {
                // Notificamos al usuario que su archivo no pudo ser subido.
                UploadStatusLabel.Text = "Seleccione los archivos necesarios para continuar.";
            }
        }
    }
}