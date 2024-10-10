using Microsoft.AspNetCore.Components.Forms;
using DocumentFormat.OpenXml.Packaging;
using System.Text;

public class InputFile
{

    public static async Task<string> GetInputFile(IBrowserFile inputFile)
    {
        StringBuilder textContent = new StringBuilder();

        // Use a MemoryStream to copy the async stream into it
        using (MemoryStream memoryStream = new MemoryStream())
        {
            // Copy the input file's async stream to memory stream
            // maxAllowedSize: 1MB
            await inputFile.OpenReadStream(maxAllowedSize: 1048576).CopyToAsync(memoryStream);

            // Reset the memory stream's position to the beginning
            memoryStream.Position = 0;

            // Open the document from the memory stream for synchronous read operations
            using (WordprocessingDocument doc = WordprocessingDocument.Open(memoryStream, false))
            {
                // Extract the main document part
                DocumentFormat.OpenXml.Wordprocessing.Body body = doc.MainDocumentPart!.Document.Body!;

                // Get all the text from the document
                textContent.Append(body.InnerText);
            }
        }

        return textContent.ToString();
    }

}