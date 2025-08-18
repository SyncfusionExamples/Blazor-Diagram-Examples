using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Hosting;

public class XmlFileService
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public XmlFileService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<XDocument> GetXmlDocumentAsync(string fileName)
    {
        var filePath = Path.Combine(_webHostEnvironment.WebRootPath, fileName);
        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return await XDocument.LoadAsync(stream, LoadOptions.None, default);
    }
}
