using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures_Algorithms.Algorithms
{
    //https://elemarjr.com/clube-de-estudos/mapreduce-alem-do-obvio-aplicacoes-surpreendentes-e-casos-de-uso/
    public class MapReduceCountWords
    {
        public void Test()
        {
            // Dados de exemplo
            List<Comment> coments = new List<Comment>()
            {
                new Comment() { Text = "Great product, I am very satisfied!!" },
                new Comment() { Text = "It's not great, but for the price it's great value for money." },
                new Comment() { Text = "Low quality product, do not recommend." },
                new Comment() { Text = "I have no opinion about the product." }
            };

            // Fase Map
            var keyWords = coments
                .SelectMany(comment => comment.Text.Replace(",", "").ToLower().Split(' '))
                .Where(word => !string.IsNullOrEmpty(word))
                .Select(word => new { Word = word, Count = 1 });

            // Fase Reduce
            var result = keyWords
                .GroupBy(item => item.Word)
                .Select(group => new WordCountResult()
                {
                    Word = group.Key,
                    Count = group.Sum(item => item.Count)
                })
                .ToList();

            // Exibindo o resultado
            foreach (var item in result)
            {
                Console.WriteLine($"Word: {item.Word}. Count: {item.Count}");
            }
        }

        private class Comment
        {
            public string Text { get; set; }
        }
        private class WordCountResult
        {
            public string Word { get; set; }
            public int Count { get; set; }
        }
    }
}
