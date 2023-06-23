using System;
using System.Collections.Generic;

class Scripture
{
    private Reference reference;
    private List<Word> words;
    private List<int> hiddenIndices;

    public Scripture(Reference reference, string scriptureText)
    {
        this.reference = reference;
        this.words = ParseScriptureText(scriptureText);
        this.hiddenIndices = new List<int>();
    }

    private List<Word> ParseScriptureText(string scriptureText)
    {
        string[] wordArray = scriptureText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        List<Word> wordList = new List<Word>();

        foreach (string word in wordArray)
        {
            wordList.Add(new Word(word));
        }

        return wordList;
    }

    public string GetDisplayText()
    {
        string displayText = $"{reference.GetReferenceText()} - ";
        for (int i = 0; i < words.Count; i++)
        {
            if (hiddenIndices.Contains(i))
            {
                displayText += "____ ";
            }
            else
            {
                displayText += $"{words[i].GetWordText()} ";
            }
        }
        return displayText;
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        List<int> availableIndices = new List<int>();

        for (int i = 0; i < words.Count; i++)
        {
            if (!hiddenIndices.Contains(i))
            {
                availableIndices.Add(i);
            }
        }

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
