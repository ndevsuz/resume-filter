using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace Resume_Filter.Application.Helpers;

public static class FileHelper
{
    public static string ExtractTextFromPdf(string path)
    {
        using (PdfReader reader = new PdfReader(path))
        {
            StringWriter output = new StringWriter();
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                output.WriteLine(PdfTextExtractor.GetTextFromPage(reader, i));
            }
            return output.ToString();
        }
    }
}