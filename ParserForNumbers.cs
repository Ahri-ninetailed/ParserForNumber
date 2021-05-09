using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//парсер работает с числами до миллиона. На вход поступает строка с числом на англ. языке. Three thousand one hundred twenty-four
public static class Parser
{
    static Dictionary<string, string> WordsS = new Dictionary<string, string>()
    {
                { "one", "1" },
                { "two", "2" },
                { "three", "3" },
                { "four", "4" },
                { "five", "5" },
                { "six", "6" },
                { "seven", "7" },
                { "eight", "8" },
                { "nine", "9" },
                { "ten", "10" },
                { "eleven", "11" },
                { "twelve" , "12" },
                { "thirteen", "13" },
                { "fourteen", "14" },
                { "fifteen", "15" },
                { "sixteen", "16" },
                { "seventeen", "17" },
                { "eighteen", "18" },
                { "nineteen", "19" },
                { "twenty", "20" },
                { "million", "000000" },
                { "hundred", "00" },
                { "thousand", "000" },
                { "thous", "000" },
                { "thirty", "30" },
                { "forty", "40" },
                { "fifty", "50" },
                { "sixty", "60" },
                { "seventy", "70" },
                { "eighty", "80" },
                { "ninety", "90" },
                { "zero", "0" },
    };
    //Основная рабочая функция
    //Строка должна начинаться с маленькой буквы, двузначные числа, как 43 или 22, должны быть в таком формате: forty-eight, twenty-two
    public static int ParseInt(string s)
    {
        //удаляем союз and
        s = s.Replace("and", "");
        try
        {
            //удаляем лишние пробелы
            int IndexTemp = s.IndexOf("  ");
            while (IndexTemp != -1)
            {
                s = s.Remove(IndexTemp, 1);
                IndexTemp = s.IndexOf("  ");
            }
        }
        catch { }
        //разбиваем строку на слова и заполняем массив строк
        string[] words = s.Split(' ');
        //создаем более производительный аналог класса String
        StringBuilder num = new StringBuilder();
        StringBuilder thousand = new StringBuilder();
        StringBuilder million = new StringBuilder();
        //в эту переменную будут записывать слова "thousend", "million", "hundred"
        string prev = "";
        //цикл пройдет по каждому слову массива
        for (int i = 0; i < words.Length; i++)
        {
            //добавить число в котором нет '-', twenty подойдет, tweny-five не подойдет
            if (words[i].IndexOf('-') == -1)
            {
                try
                {
                    num.Append(WordsS[words[i]]);
                }
                catch
                { }
            }
            else
            {
                //записать в переменную число с '-'
                int temp = Two_DigitNumbers(words[i]);
                num.Append(temp);
                try
                {
                    //попытаться добавить это число в словарь
                    WordsS.Add(words[i], temp.ToString());
                }
                //если число уже добавлено - проигнорировать
                catch (ArgumentException)
                {

                }
            }
            
            if (words[i] == "thousand" || words[i] == "thous")
            {
                thousand = new StringBuilder(num.ToString());
                num.Clear();
            }
            //если слово миллион, добавить значение в переменную
            if (words[i] == "million")
            {
                million = new StringBuilder(num.ToString());
                num.Clear();
            }
            //если предыдущее слово сотня и в числе есть десятки
            if (prev == "hundred" && (Int32.Parse(WordsS[words[i]]) >= 10 && Int32.Parse(WordsS[words[i]]) <= 99))
                num.Remove(num.Length - 2 - 2, 2);
            //если предыдущее слово сотня и в числе только единицы
            if (prev == "hundred" && (Int32.Parse(WordsS[words[i]]) >= 1 && Int32.Parse(WordsS[words[i]]) <= 9))
                num.Remove(num.Length - 1 - 1, 1);
            if (words[i] == "hundred" || words[i] == "thousand" || words[i] == "thous" || words[i] == "million")
                prev = words[i];
        }
        //если в числе есть миллионы
        if (million.Length != 0)
        {
            million.Remove(million.Length - num.Length, num.Length);
            num.Insert(0, million);
        }
        //если в числе есть тысячи
        if (thousand.Length != 0)
        {
            thousand.Remove(thousand.Length - num.Length, num.Length);
            num.Insert(0, thousand);
        }
        return Int32.Parse(num.ToString());
    }
    //Метод который преобразовывает двузначные числа в цифры
    static int Two_DigitNumbers(string s)
    {
        string[] words = s.Split('-');
        StringBuilder num = new StringBuilder(WordsS[words[0]]);
        num.Remove(1, 1);
        num.Append(WordsS[words[1]]);
        return Int32.Parse(num.ToString());
    }
}




