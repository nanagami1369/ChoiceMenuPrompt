using System;
using System.Text;

namespace Nanagami1369.ColorSelectPrompt
{
    public static class Prompt
    {
        private static void ClearSelectMenu(string[] menuItems)
        {
            Console.CursorTop -= menuItems.Length;
            foreach (var _ in menuItems) Console.WriteLine(new string(' ', Console.BufferWidth));
            Console.CursorTop -= menuItems.Length;
        }

        private static int ConsoleNumberKeyToInteger(ConsoleKey key)
        {
            var number = (int)key - 48;
            if (0 <= number && number < 10)
            {
                return number;
            }
            throw new ArgumentException("not number key");
        }

        private static void PrintSelectMenu(string[] menuItems, int selectIndex)
        {
            var lastIndex = menuItems.Length;
            var largestDigit = lastIndex.ToString().Length;
            for (var index = 0; index < menuItems.Length; index++)
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

        public static int Print(string message, string[] menuItems)
        {
            var currentOutputEncoding = Console.OutputEncoding;
            Console.OutputEncoding = new UTF8Encoding(false);
            var selectIndex = 0;
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
                        if (selectIndex > 0) selectIndex--;
                        Console.CursorTop -= menuItems.Length;
                        PrintSelectMenu(menuItems, selectIndex);
                        continue;
                    // ↓キーで移動
                    case ConsoleKey.DownArrow:
                        if (selectIndex < menuItems.Length - 1) selectIndex++;
                        Console.CursorTop -= menuItems.Length;
                        PrintSelectMenu(menuItems, selectIndex);
                        continue;
                    // 数字キーで項目があるならそこまで移動
                    case ConsoleKey.D0:
                    case ConsoleKey.D1:
                    case ConsoleKey.D2:
                    case ConsoleKey.D3:
                    case ConsoleKey.D4:
                    case ConsoleKey.D5:
                    case ConsoleKey.D6:
                    case ConsoleKey.D7:
                    case ConsoleKey.D8:
                    case ConsoleKey.D9:
                        var selectNumber = ConsoleNumberKeyToInteger(key.Key);
                        if (selectNumber < menuItems.Length)
                        {
                            selectIndex = selectNumber;
                            Console.CursorTop -= menuItems.Length;
                            PrintSelectMenu(menuItems, selectIndex);
                        }

                        continue;
                    default:
                        continue;
                }
            }
        }
    }
}
