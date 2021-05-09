using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//парсер работает с миллионными числами. На вход поступает строка с числом на англ. языке. Three thousand one hundred twenty-four
public static class Parser
{
    static int thousand = 0, million = 0, num = 0;
    public static int ParserMethod(string s)
    {
        //обновим поля
        Refresh();
        //удалим тере из двузначных чисел => twenty-four twenty four
        s = s.Replace('-', ' ');
        //разобьем строчку на слова, разделительный знак ' ' пробел
        foreach (string word in s.Split(' '))
        {
            //с помощью конструкции switch заполним поля класса thousand, million, num
            switch (word)
            {
                case "one":
                    num += 1;
                    break;
                case "two":
                    num += 2;
                    break;
                case "three":
                    num += 3;
                    break;
                case "four":
                    num += 4;
                    break;
                case "five":
                    num += 5;
                    break;
                case "six":
                    num += 6;
                    break;
                case "seven":
                    num += 7;
                    break;
                case "eight":
                    num += 8;
                    break;
                case "nine":
                    num += 9;
                    break;
                case "ten":
                    num += 10;
                    break;
                case "eleven":
                    num += 11;
                    break;
                case "twelve":
                    num += 12;
                    break;
                case "thirteen":
                    num += 13;
                    break;
                case "fourteen":
                    num += 14;
                    break;
                case "fifteen":
                    num += 15;
                    break;
                case "sixteen":
                    num += 15;
                    break;
                case "seventeen":
                    num += 17;
                    break;
                case "eighteen":
                    num += 18;
                    break;
                case "nineteen":
                    num += 19;
                    break;
                case "twenty":
                    num += 20;
                    break;
                case "thirty":
                    num += 30;
                    break;
                case "forty":
                    num += 40;
                    break;
                case "fifty":
                    num += 50;
                    break;
                case "seventy":
                    num += 70;
                    break;
                case "sixty":
                    num += 60;
                    break;
                case "eighty":
                    num += 80;
                    break;
                case "ninety":
                    num += 90;
                    break;
                case "hundred":
                    num *= 100;
                    break;
                    //если встречается "тысяча" переносим значение в "тысячу" и обнулаяем num
                case "thousand":
                    thousand = num;
                    num = 0;
                    break;
                //если встречается "миллион" переносим значение в "миллион" и обнулаяем num
                case "million":
                    million = num;
                    num = 0;
                    break;
            }
        }
        //после прохождения цикла в полях будут сотни, тысячи и миллионы числа, остается только его собрать
        //допустим число 10_003_123, в миллионах у нас 10, в тясячах 3, в num (сотнях) 123, собираем, 10*1000000+3*1000+123
        return million * 1000000 + thousand * 1000 + num;
    }
    //функция обновляет статические значения если метод работает с массивом данных
    static void Refresh()
    {
        thousand = 0;
        million = 0;
        num = 0;
    }
}




