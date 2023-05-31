namespace AirWrkChallenge.Models.TextAnalytics
{
    public class AnalyzeModel
    {
        public AnalyzeModel()
        {
        }

        public AnalyzeModel(int charCount, int wordCount, int sentenceCount, MostFrequentWordDto mostFrequentWord, string longestWord)
        {
            CharCount = charCount;
            WordCount = wordCount;
            SentenceCount = sentenceCount;
            MostFrequentWord = mostFrequentWord;
            LongestWord = new LongestWordDto(longestWord);
        }

        public int CharCount { get; set; }
        public int WordCount { get; set; }
        public int SentenceCount { get; set; }
        public MostFrequentWordDto MostFrequentWord { get; set; }
        public LongestWordDto LongestWord { get; set; }
    }

    public class MostFrequentWordDto
    {
        public MostFrequentWordDto(string word, int frequency)
        {
            Word = word;
            Frequency = frequency;
        }

        public string Word { get; }
        public int Frequency { get;  }
    }

    public class LongestWordDto
    {
        public LongestWordDto(string word)
        {
            Word = word;
            Length = word.Length;
        }

        public string Word { get;  }
        public int Length { get;  }
    }

}
