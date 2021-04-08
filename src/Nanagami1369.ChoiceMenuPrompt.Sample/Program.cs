using System;

namespace Nanagami1369.ColorSelectPrompt.Sample
{
    internal class Program
    {
        private static void Main()
        {
            string[] menuItem = {"晴れ", "曇り", "雨", "ポケモン", "猫", "犬", "熊", "華麗", "美麗", "勇気", "根性"};
            var result = Prompt.Print("好きなものは？", menuItem);
            Console.WriteLine(result);
        }
    }
}
