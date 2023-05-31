using AirWrkChallenge.Models.TextAnalytics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Text;

namespace AirWrkChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextAnalyticsController : ControllerBase
    {
        [HttpPost]
        [Route("analyze")]
        public IActionResult Analyze(string text)
        {
            int characterCounter = 0;
            int sentenceCounter = 0;
            string mostFrequentWord = "";
            int mostFrequentWordFrequency = 0;
            string longestWord;

            StringBuilder wordBuilder = new StringBuilder();
            var words = new List<string>();
            char previous;
            foreach (char item in text)
            {
                if (!char.IsWhiteSpace(item))
                {
                    characterCounter++;

                    if (item == '.')
                    {
                        sentenceCounter++;
                        words.Add(wordBuilder.ToString().ToLower());
                        wordBuilder.Clear();
                    }
                    else
                    {
                        wordBuilder.Append(item);
                    }
                }
                else
                {
                    if (wordBuilder.Length > 0)
                    {
                        words.Add(wordBuilder.ToString().ToLower());
                        wordBuilder.Clear();
                    }
                }
            }

            var wordGroups = words.GroupBy(x => x);

            foreach (var wordGroup in wordGroups)
            {
                if (wordGroup.Count() > mostFrequentWordFrequency)
                {
                    mostFrequentWordFrequency = wordGroup.Count();
                    mostFrequentWord = wordGroup.Key;
                }
            }

            var output = new AnalyzeModel(characterCounter, words.Count, sentenceCounter, new MostFrequentWordDto(mostFrequentWord, mostFrequentWordFrequency), "");
            return Ok(output);
        }
    }
}
