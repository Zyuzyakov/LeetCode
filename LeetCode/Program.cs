using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    // hard 301: удалить неверные скобки.
    // Дана строка s, содержащая скобки и буквы. Удалите минимальное количество недопустимых скобок, чтобы сделать входную строку допустимой.
    // Верните список уникальных строк, которые являются допустимыми с минимальным количеством удалений. Вы можете вернуть ответ в любом порядке.
    // ref: https://leetcode.com/problems/remove-invalid-parentheses/description/
    public static class Program
    {
        private static HashSet<string> _hSet = new HashSet<string>();
        private static int _maxLength = 0;
        private static int countBigO = 0;

        public static void Main(string[] args)
        {
            string param = "(((((((((((((((aaaa)))))";
            Console.WriteLine("Исходная строка: " + param);
            RemoveInvalidParentheses(param).Select(x => { Console.WriteLine(x); return x; }).ToList(); // ["(a())()","(a)()()"]
            Console.WriteLine("Итераций: " + countBigO);
            Console.ReadKey();
        }

        static IList<string> RemoveInvalidParentheses(string s)
        {
            Search(s, 0, new LineParentheses());

            return _hSet.ToList();
        }

        static void Search(string str, int index, LineParentheses line)
        {
            if (!line.IsValid && (line.Open - line.Close) > str.Length - index)
                return;

            countBigO++;

            if (line.IsValid)
                AddToHashSet(line);

            if (index >= str.Length)
                return;

            var currentChar = str[index++];
            var newLine = new LineParentheses(line, currentChar);
            if (newLine.IsBad)
                newLine = new LineParentheses();

            if (newLine.ToString() != line.ToString())
            {
                Search(str, index, line);
                Search(str, index, newLine);
            }
            else
            {
                Search(str, index, line);
            }
        }

        static void AddToHashSet(LineParentheses line)
        {
            if (line.Length > _maxLength)
            {
                _maxLength = line.Length;
                _hSet.Clear();
                _hSet.Add(line.ToString());
            }
            else if (line.Length == _maxLength)
            {
                _hSet.Add(line.ToString());
            }
        }

        private class LineParentheses
        {
            public StringBuilder Line { get; private set; } = new StringBuilder();
            public int Length => Line.Length;
            public bool IsValid => Open == Close;
            public bool IsBad => Close > Open;
            public int Open { get; private set; }
            public int Close { get; private set; }

            public LineParentheses() { }
            public LineParentheses(LineParentheses cloneFrom, char c)
            {
                Open = cloneFrom.Open;
                Close = cloneFrom.Close;
                Line.Append(cloneFrom.ToString());
                Add(c);
            }

            public void Add(char c)
            {
                if (IsBad)
                    throw new Exception("Строка недопустима.");

                if (c == '(')
                    Open++;
                else if (c == ')')
                    Close++;

                Line.Append(c);
            }

            public override string ToString() => Line.ToString();
        }
    }
}