using Aspose.Words;

class InputFile
{

    public static string GetInputFile()
    {

        var doc = new Document(@"C:\Users\ClaGia\Downloads\Martello del Sole Compendio I.docx");

        string text = doc.ToString(SaveFormat.Text).Trim().Replace("Created with an evaluation copy of Aspose.Words. To remove all limitations, you can use Free Temporary License https://products.aspose.com/words/temporary-license/", "").Replace("Evaluation Only. Created with Aspose.Words. Copyright 2003-2024 Aspose Pty Ltd.", "");

        return text;

    }

}