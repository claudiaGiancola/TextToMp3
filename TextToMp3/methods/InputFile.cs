using Aspose.Words;

class InputFile
{

    public static string GetInputFile()
    {

        var doc = new Document(@"C:\Users\ClaGia\Downloads\Martello del Sole Compendio I.docx");
        doc.Save(@"C:\Training\TextToMp3\exportTests\Martello del Sole Compendio I.txt");

        string text = File.ReadAllText(@"C:\Training\TextToMp3\exportTests\Martello del Sole Compendio I.txt");

        return text;

    }

}