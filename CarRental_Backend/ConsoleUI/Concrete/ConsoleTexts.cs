using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ConsoleUI.Concrete
{
    public static class ConsoleTexts
    {
        //Settings
        private const int _frameWidth = 111;
        private const string _frameChar = "*";
        private const int _itemLeftSpaceCount = 5;
        private const int _leftSpaceCount = 5;
        private const ConsoleColor dataListHeaderTextColor = ConsoleColor.Green;
        private const ConsoleColor headTextColor = ConsoleColor.Blue;
        private const ConsoleColor errorTextColor = ConsoleColor.Red;

        private static string _leftSpaceText = RepeatText(" ", _leftSpaceCount) + _frameChar;
        private static string _emptyLineInFrame = _leftSpaceText + _frameChar.PadLeft ( _frameWidth + 1 );

        public static void WriteConsoleMenuInFrame(string headerText, string[] menuItems)
        {
            FrameHeaderFooterLine();
            Header(headerText);
            WriteMenuItems(menuItems);
            FrameHeaderFooterLine();
        }

        public static void FrameHeaderFooterLine()
        {
            string text = _frameChar.PadLeft(_leftSpaceCount+1) + RepeatText(" " + _frameChar, _frameWidth / 2+1);
            Console.WriteLine(text);
        }

        public static void Header(string header, bool fullWidthHeader = false)
        {
            int headerLength = header.Length + _itemLeftSpaceCount * 2 + 2;
            int left = (_frameWidth - headerLength) / 2;
            int right = _frameWidth - (headerLength + left);
            string leftSpaceText = (fullWidthHeader) ? RepeatText(" ", _leftSpaceCount) : _leftSpaceText;
            string headerLeft = leftSpaceText + RepeatText(" ", _itemLeftSpaceCount) + RepeatText("=", left) + " ";
            string lastChar = (fullWidthHeader) ? " " : _frameChar;
            Console.Write(headerLeft);
            Console.ForegroundColor = headTextColor;
            Console.Write(header);
            Console.ResetColor();
            string headerRight = " " + RepeatText("=", right) + RepeatText(" ", _itemLeftSpaceCount) + lastChar;
            Console.WriteLine(headerRight);
            string afterHeader = (fullWidthHeader) ? "\n" : _emptyLineInFrame;
            Console.WriteLine(afterHeader);
        }

        private static string RepeatText(string repeatText, int numberOfRepeat)
        {
            string text = "";
            for (int i = 0; i < numberOfRepeat; i++)
            {
                text += repeatText;
            }
            return text;
        }

        public static void WriteSubMenuItems(string subHeader, string[] menuItems)
        {
            //Düzenlenecek
            Console.WriteLine(_leftSpaceText + RepeatText(" ", _itemLeftSpaceCount + 2) + subHeader + RepeatText(" ", _frameWidth - (6 + subHeader.Length)) + _frameChar);
            Console.WriteLine(_leftSpaceText + RepeatText(" ", _itemLeftSpaceCount + 2) + RepeatText(" ", subHeader.Length) + RepeatText(" ", _frameWidth - (6 + subHeader.Length)) + _frameChar);
            foreach (string item in menuItems)
            {
                string text = _leftSpaceText + RepeatText(" ", _itemLeftSpaceCount + 2) + item + RepeatText(" ", _frameWidth - (6 + item.Length)) + _frameChar;
                Console.WriteLine(text);
            }
            Console.WriteLine(_emptyLineInFrame);
        }

        public static void WriteMenuItems(string[] menuItems)
        {
            if(menuItems != null && menuItems.Length > 0)
            {
                foreach (string item in menuItems)
                {
                    Console.WriteLine(_leftSpaceText + RepeatText(" ", _itemLeftSpaceCount) + item.PadRight(_frameWidth - _itemLeftSpaceCount) + _frameChar);
                }
            }
            else
            {
                int space = (_frameWidth - 15) / 2;
                Console.WriteLine(_leftSpaceText + "".PadRight(space) + "No data to show".PadRight(_frameWidth - space) + _frameChar);
            }
            
            Console.WriteLine(_emptyLineInFrame);
        }

        public static string ConsoleWriteReadLine(string writeText)
        {
            Console.Write("\n{0}: ", writeText);
            return Console.ReadLine();
        }

        public static bool ConfirmAction(string message)
        {
            ColoredErrorText($"\n{message}\n");
            Console.Write("Type Y or N: ");
            return Console.ReadLine() == "Y"
                ? true
                : false;
        }

        public static void ColoredErrorText(string text)
        {
            Console.ForegroundColor = errorTextColor;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void WriteDataList<T>(string tableHeader, List<T> dataList, string[] headers = null)
        {
            Header(tableHeader,true);
            if (headers == null)
            {
                PropertyInfo[] props = dataList.First().GetType().GetProperties();
                headers = new string[props.Length];
                int i = 0;
                foreach (var prop in props)
                {
                    headers[i] = prop.Name;
                    i++;
                }
            }

            int padding = _frameWidth / headers.Length;
            Console.Write("".PadRight(_itemLeftSpaceCount));
            Console.ForegroundColor = dataListHeaderTextColor;
            foreach (string header in headers)
            {
                Console.Write(header.PadRight(padding));
            }

            Console.Write("\n".PadRight(_itemLeftSpaceCount+1));
            foreach (string header in headers)
            {
                string headerItemLine = RepeatText("-", header.Length);
                Console.Write(headerItemLine.PadRight(padding));
            }
            Console.WriteLine("\n");
            Console.ResetColor();


            foreach (T data in dataList)
            {
                Console.Write("".PadRight(_itemLeftSpaceCount));
                PropertyInfo[] props = data.GetType().GetProperties();
                foreach (var prop in props)
                {
                    if(prop.GetValue(data) != null)
                    {
                        Console.Write(prop.GetValue(data).ToString().Trim().PadRight(padding));
                    }
                    else
                    {
                        Console.Write("NULL".PadRight(padding));
                    }

                }
                Console.WriteLine("\n");
            }
            
            Console.WriteLine("\n");
        }

    }
}
