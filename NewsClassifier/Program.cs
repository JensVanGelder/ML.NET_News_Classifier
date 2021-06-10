using NewsClassifierModel;
using System;

namespace NewsClassifier
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("News classifier");
            Console.WriteLine();

            string[] headlines = new[]
            {
                "C9 fails to win the tournament again",
                "Tesla car drives over old lady, yet again.",
                "Dogecoin loses stonks",
                "Biden revokes Trump orders targeting TikTok and WeChat and issues fresh order"
            };

            foreach (var headline in headlines)
            {
                ModelInput input = new ModelInput { Title = headline };
                var classification = ConsumeModel.Predict(input);
                var category = GetCategoryName(classification);
                Console.WriteLine($"{category}: {headline}");
            }

            Console.WriteLine();
        }

        private static string GetCategoryName(ModelOutput classification)
        {
            switch (classification.Category)
            {
                case "b":
                    return "Business";

                case "t":
                    return "Technology";

                case "e":
                    return "Entertainment";

                case "m":
                    return "Medicine";

                default:
                    return "Unknown";
            }
        }
    }
}