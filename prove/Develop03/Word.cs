class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        this.Text = text;
        this.IsHidden = false;
    }

    public void Hide()
    {
        this.IsHidden = true;
    }
}
