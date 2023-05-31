using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.IO;
using System;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.Drawing;

namespace ArchimateShape.Data
{
    public class ExportService
    {
        // Export HTML to Image

        public string ConvertImage(string htmlContent, int viewPortSize)
        {

            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.Blink);
            string baseUrl1 = Path.GetFullPath("wwwroot");
            BlinkConverterSettings settings = new BlinkConverterSettings();
           
            
            settings.ViewPortSize = new Syncfusion.Drawing.Size(viewPortSize, 0);
            htmlConverter.ConverterSettings = settings;
            Image image = htmlConverter.ConvertToImage(htmlContent, baseUrl1);

           
            byte[] imageByte = image.ImageData;
            string imagevalue = Convert.ToBase64String(imageByte);
            string imag= "data:image/png;base64," + imagevalue;
            return imag;
        }

        //Export HTML to PDF document.
        public MemoryStream CreatePdf()
        {
            //Initialize HTML to PDF converter 
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

            WebKitConverterSettings settings = new WebKitConverterSettings();

            //Set WebKit path
            settings.WebKitPath = Startup.contentRootPath + @"\QtBinariesWindows\"; ;

            //Assign WebKit settings to HTML converter
            htmlConverter.ConverterSettings = settings;

            //Convert URL to PDF
            PdfDocument document = htmlConverter.Convert("https://www.google.com");

            MemoryStream stream = new MemoryStream();

            //Save and close the PDF document 
            document.Save(stream);

            document.Close(true);

            return stream;
        }
    }
}
