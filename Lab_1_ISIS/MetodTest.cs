using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_1_ISIS
{
    public class MetodTest
    {
        //Проверка на пустоту
        public static string Test1(string text)
        {
            if (text == "")
            {
                return null;
            }
            else
            {
                return "";
            }

        }
        //Кол-во слов по условию
        public static int Test2(string text, int length)
        {
            char[] delimiters = new char[] { ' ', '\r', '\n', ',', '?', '-', '.', ':' }; // разделители
            var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries); // все слова
            return words.Where(x => x.Length == length).ToList().Count; // количество слов по условию 
        }

        //Поиск пробелов
        static bool Space(char chr)
        {
            if (chr == ' ') 
                return true;
            else 
                return false;
        }

        //Кол-во пробелов
        public static int Test3(string str)
        {
            char[] chars = str.ToCharArray();
            char[] findChars = Array.FindAll(chars, Space);
            int count = findChars.Length;
            return count;
        }
        
        //Сумма
        public static int Test4(int a, int b)
        {
            int c = a + b;
            return c;
        }

        //Деление
        public static int Test5(int a, int b)
        {
            int c = a / b;
            return c;
        }

        //Умножение
        public static int Test6(int a, int b)
        {
            int c = a * b;
            return c;
        }
        //Кол-во букв по условию
        public static int Test7(string text, string a)
        {
            int count = text.ToCharArray().Where(c => c == a[0]).Count();
            return count;
        }
        //Длина текста
        public static int Test8(string text)
        {
            int count = text.Length;
            return count;
        }
        //Значение
        public static int Test9(int a)
        {
            int a1 = a;
            return a1;
        }
    }
}
