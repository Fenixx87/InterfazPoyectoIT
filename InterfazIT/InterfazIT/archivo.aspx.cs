using System;
using System.Collections.Generic;
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
            // Specify the path on the server to
            // save the uploaded file to.
            String savePath = @"C:\tempera\";

            // Before attempting to perform operations
            // on the file, verify that the FileUpload 
            // control contains a file.
            if (FileUpload1.HasFile && FileUpload2.HasFile && FileUpload3.HasFile)
            {
                // Get the name of the file to upload.
                //String filePDF = FileUpload1.FileName;
                //String fileFirma = FileUpload2.FileName;

                // Get the name of the file to upload.
                string filePDF = Server.HtmlEncode(FileUpload1.FileName);
                string fileFirma = Server.HtmlEncode(FileUpload2.FileName);
                string fileImg = Server.HtmlEncode(FileUpload3.FileName);

                // Get the extension of the uploaded file.
                string extensionPDF = System.IO.Path.GetExtension(filePDF);
                string extensionFirma = System.IO.Path.GetExtension(fileFirma);
                string extensionImg = System.IO.Path.GetExtension(fileImg);

                if (extensionPDF == ".pdf" && extensionFirma == ".p12" && (extensionImg == ".jpg" || extensionImg == ".png" || extensionFirma == ".emf"))
                {
                    // Append the name of the file to upload to the path.
                    String savePathPDF = savePath + filePDF;
                    String savePathFirma = savePath + fileFirma;
                    String savePathImg = savePath + fileImg;

                    // Call the SaveAs method to save the 
                    // uploaded file to the specified path.
                    // This example does not perform all
                    // the necessary error checking.               
                    // If a file with the same name
                    // already exists in the specified path,  
                    // the uploaded file overwrites it.
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
                    // Notify the user of the name of the file
                    // was saved under.
                    UploadStatusLabel.Text = "Tus archivos han sido subidos con éxito!";
                }
                else
            {
                // Notify the user that a file was not upload for correct extension.
                UploadStatusLabel.Text = "Seleccione archivos validos.";
            }
        }
        else
        {
            // Notify the user that a file was not uploaded.
            UploadStatusLabel.Text = "Seleccione los archivos necesarios para continuar.";
    }
            //using (PdfDocumentProcessor processor = new PdfDocumentProcessor())
            //{
            //    // Load a document.
            //    var CurrentDirectory = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            //    processor.LoadDocument(txtFile.Text);

            //    // Attach a file to the PDF document. 
            //    processor.AttachFile(new PdfFileAttachment()
            //    {
            //        CreationDate = DateTime.Now,
            //        Description = "This is my attach file.",
            //        FileName = "MyAttach.txt",
            //        Data = File.ReadAllBytes("..\\..\\FileToAttach.txt")
            //    });

            //    // The attached document.
            //    processor.SaveDocument("..\\..\\Result.pdf");
            //}

        }
    }
}