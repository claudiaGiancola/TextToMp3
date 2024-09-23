class InputFile {

    public static string GetInputFile() {

        string text= File.ReadAllText(@"C:\Training\TextToMp3\exportTests\text.txt");

        return text;

    }

}