using System;
using System.Text;

namespace ColorSelectPrompt
{
    public static class Prompt
    {
        private static void ClearSelectMenu(string[] menuItems)
        {
            Console.CursorTop -= menuItems.Length;
            foreach (var _ in menuItems)
            {
                Console.WriteLine(new string(' ', Console.BufferWidth));
            }
            Console.CursorTop -= menuItems.Length;
        }

        private static void PrintSelectMenu(string[] menuItems, int selectIndex)
        {
            var lastIndex = menuItems.Length;
            var largestDigit = lastIndex.ToString().Length;
            for (int index = 0; index < menuItems.Length; index++)
            {
                if (selectIndex == index)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{index.ToString().PadLeft(largestDigit)}:{menuItems[index]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{index.ToString().PadLeft(largestDigit)}:{menuItems[index]}");
                }
            }
        }

        public static int Print(string message, string[] menuItems)
        {
            var currentOutputEncoding = Console.OutputEncoding;
            Console.OutputEncoding = new UTF8Encoding(false);
            int selectIndex = 0;
            Console.WriteLine($"{message} [↑キー ↓キー:移動 Enter:確定]");
            PrintSelectMenu(menuItems, selectIndex);
            while (true)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    // Enterで選択
                    case ConsoleKey.Enter:
                        ClearSelectMenu(menuItems);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("✓  ");
                        Console.ResetColor();
                        Console.WriteLine($"{menuItems[selectIndex]}が選択されました");
                        Console.OutputEncoding = currentOutputEncoding;
                        return selectIndex;
                    // ↑キーで移動
                    case ConsoleKey.UpArrow:
                        if (selectIndex > 0)
                        {
                            selectIndex--;
                        }
                        Console.CursorTop -= menuItems.Length;
                        PrintSelectMenu(menuItems, selectIndex);
                        continue;
                    // ↓キーで移動
                    case ConsoleKey.DownArrow:
                        if (selectIndex < menuItems.Length - 1)
                        {
                            selectIndex++;
                        }
                        Console.CursorTop -= menuItems.Length;
                        PrintSelectMenu(menuItems, selectIndex);
                        continue;
                    default:
                        continue;
                }
            }
        }
    }
}
