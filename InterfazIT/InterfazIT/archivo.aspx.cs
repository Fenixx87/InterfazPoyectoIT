using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Pdf;
using System.IO;
using System.Reflection;


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
            if (FileUpload1.HasFile && FileUpload2.HasFile)
            {
                // Get the name of the file to upload.
                //String filePDF = FileUpload1.FileName;
                //String fileFirma = FileUpload2.FileName;

                // Get the name of the file to upload.
                string filePDF = Server.HtmlEncode(FileUpload1.FileName);
                string fileFirma = Server.HtmlEncode(FileUpload2.FileName);

                // Get the extension of the uploaded file.
                string extensionPDF = System.IO.Path.GetExtension(filePDF);
                string extensionFirma = System.IO.Path.GetExtension(fileFirma);

                if (extensionPDF == ".pdf" && extensionFirma == ".p12")
                {
                    // Append the name of the file to upload to the path.
                    String savePathPDF = savePath + filePDF;
                    String savePathFirma = savePath + fileFirma;

                    // Call the SaveAs method to save the 
                    // uploaded file to the specified path.
                    // This example does not perform all
                    // the necessary error checking.               
                    // If a file with the same name
                    // already exists in the specified path,  
                    // the uploaded file overwrites it.
                    FileUpload1.SaveAs(savePathPDF);
                    FileUpload2.SaveAs(savePathFirma);

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