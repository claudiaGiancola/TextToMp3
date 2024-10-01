using Microsoft.AspNetCore.Components.Forms;
using DocumentFormat.OpenXml.Packaging;
using System.Text;

class InputFile
{

    public static async Task<string> GetInputFile(IBrowserFile inputFile)
    {
        StringBuilder textContent = new StringBuilder();

        // Use a MemoryStream to copy the async stream into it
        using (var memoryStream = new MemoryStream())
        {
            // Copy the input file's async stream to memory stream
            await inputFile.OpenReadStream(maxAllowedSize: 10485760).CopyToAsync(memoryStream);

            // Reset the memory stream's position to the beginning
            memoryStream.Position = 0;

            // Open the document from the memory stream for synchronous read operations
            using (WordprocessingDocument doc = WordprocessingDocument.Open(memoryStream, false))
            {
                // Extract the main document part
                var body = doc.MainDocumentPart.Document.Body;

                // Get all the text from the document
                textContent.Append(body.InnerText);
            }
        }

        return textContent.ToString();
    }

}