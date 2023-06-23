class Scripture
{
    private string reference;
    private List<string> words;
    private List<int> hiddenIndices;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.words = text.Split(' ').ToList();
        this.hiddenIndices = new List<int>();
    }

    public string GetDisplayText()
    {
        string displayText = $"{reference} - ";
        for (int i = 0; i < words.Count; i++)
        {
            if (hiddenIndices.Contains(i))
            {
                displayText += "___ ";
            }
            else
            {
                displayText += $"{words[i]} ";
            }
        }
        return displayText;
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        List<int> availableIndices = Enumerable.Range(0, words.Count).ToList();
        availableIndices = availableIndices.Except(hiddenIndices).ToList();

        int wordsToHide = Math.Min(count, availableIndices.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = random.Next(0, availableIndices.Count);
            hiddenIndices.Add(availableIndices[randomIndex]);
            availableIndices.RemoveAt(randomIndex);
        }
    }

    public bool AllWordsHidden()
    {
        return hiddenIndices.Count == words.Count;
    }
}