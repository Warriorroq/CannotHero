using System.IO;

public static class FileReader
{
    public static string _path = "D:\\Shit\\CannotHero\\Saves\\Save.txt";
    public static int ReadParam(string paramName)
    {
        using (StreamReader sr = new StreamReader(_path))
        {
            do
            {
                var data = sr.ReadLine().Split();
                if (data[0].Equals(paramName))
                {
                    return int.Parse(data[1]);
                }
            } while (sr.EndOfStream == false);
        }
        return 0;
    }
}
