class ScriptureReader
{
    private static List<string> scriptures;

    public static void LoadScriptures()
    {
        scriptures = System.IO.File.ReadAllLines("Scriptures.txt").ToList();
    }

    public static string GetRandomScripture()
    {
        Random random = new Random();
        if (scriptures.Count > 0)
        {
            int randomIndex = random.Next(0, scriptures.Count);
            return scriptures[randomIndex];
        }
        return null;
    }
}