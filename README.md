# ChoiceMenuPrompt

コンソールに色付きの、きれいなプロンプトを表示するライブラリー

<img src="https://raw.githubusercontent.com/nanagami1369/ChoiceMenuPrompt/main/readme-image/menuSelectSample.gif" alt="メニューの動いている様子" title="メニューの動いている様子" >

# 使い方

```csharp
using System;
using ColorSelectPrompt;

namespace ColorSelectPromptSample
{
    internal class Program
    {
        private static void Main()
        {
            string[] menuItem = {
                "晴れ",
                "曇り",
                "雨",
                "ポケモン",
                "猫",
                "犬",
                "熊",
                "華麗",
                "美麗",
                "勇気",
                "根性"
            };
            var result = Prompt.Print("好きなものは？", menuItem);
            Console.WriteLine(result);
        }
    }
}
```
