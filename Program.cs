using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_HW_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task_1();
        }

        public static void Task_1()
        {
            /*Написать класс Money, предназначенный для хранения денежной суммы (в гривнах и копейках). Для класса
        реализовать перегрузку операторов + (сложение денежных сумм), – (вычитание сумм), / (деление суммы на целое
        число), * (умножение суммы на целое число), ++ (сумма
        увеличивается на 1 копейку), -- (сумма уменьшается на
        1 копейку), <, >, ==, !=.
        Класс не может содержать отрицательную сумму.
        В случае если при исполнении какой-либо операции получается отрицательная сумма денег, то класс генерирует
        исключительную ситуацию «Банкрот».
        Программа должна с помощью меню продемонстрировать все возможности класса Money. Обработка исключительных ситуаций производится в программе.*/
            int rub = 0;
            byte kop = 0;
            byte choice = 0;
            bool allRight = true;

            Money money = EnteringOfMoney();

            bool exit = false;

            do
            {

                Console.Clear();
                do
                {
                    Console.WriteLine("Перечень действий: ");
                    Console.WriteLine("1. Сложение денежных сумм.");
                    Console.WriteLine("2. Вычитание денежных сумм.");
                    Console.WriteLine("3. Деление суммы счёта на целое число.");
                    Console.WriteLine("4. Умножение суммы счёта на целое число.");
                    Console.WriteLine("5. Увеличение суммы счёта на одну копейку.");
                    Console.WriteLine("6. Уменьшение суммы счёта на одну копейку.");
                    Console.WriteLine("7. Сравнение суммы счёта с введённой суммой.");
                    Console.WriteLine("8. Выход.");
                    try
                    {
                        Console.Write("Введите номер действия: ");
                        choice = Convert.ToByte(Console.ReadLine());
                        if (choice < 1 || choice > 8)
                        {
                            throw new ArgumentOutOfRangeException("Число должно быть от 1 до 7 включительно.");
                        }
                    }
                    catch (FormatException fe)
                    {
                        allRight = false;
                        Console.WriteLine(fe.Message);
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        allRight = false;
                        Console.WriteLine(ex.Message);
                        Console.ReadKey();
                    }
                    Console.Clear();
                    if (allRight)
                    {
                        break;
                    }
                    allRight = true;
                } while (true);

                if(choice == 1)     // сложение денежных сумм
                {
                    Console.WriteLine("Сложение денежных сумм.");
                    Money money_2 = EnteringOfMoney();

                    Console.WriteLine(money.ToString() + " + " + money_2.ToString() + " = " + (money + money_2));
                    money = money + money_2;
                    Console.ReadKey();
                }else if (choice == 2)  // вычитание дележных сумм
                {
                    Console.WriteLine("Вычитание денежных сумм.");
                    Money money_2 = EnteringOfMoney();
                    Console.WriteLine(money.ToString() + " - " + money_2.ToString() + " = " + (money - money_2));
                    money = money - money_2;
                    Console.ReadKey();
                }
                else if(choice == 3)    // Деление суммы счёта на целое число
                {
                    Console.WriteLine("Деление суммы счёта на целое число.");
                    int number = CheckNumber();                    
                    Console.WriteLine(money.ToString() + " / " + number + " = " + (money / number));
                    money = money / number;
                    Console.ReadKey();
                }
                else if (choice == 4)   // Умножение суммы счёта на целое число
                {
                    Console.WriteLine("Умножение суммы счёта на целое число.");
                    int number = CheckNumber();
                    Console.WriteLine(money.ToString() + " * " + number + " = " + (money * number));
                    money = money * number;
                    Console.ReadKey();
                }
                else if (choice == 5)   // Увеличение суммы счёта на одну копейку
                {
                    Console.WriteLine("Увеличение суммы счёта на одну копейку.");
                    Console.Write(money.ToString() + "++ = "); 
                    money++;
                    Console.Write(money);
                    Console.ReadKey();
                }
                else if (choice == 6)   // Уменьшение суммы счёта на одну копейку
                {
                    Console.WriteLine("Уменьшение суммы счёта на одну копейку.");
                    Console.Write(money.ToString() + "-- = ");
                    money--;
                    Console.Write(money);
                    Console.ReadKey();
                }
                else if (choice == 7)   // Сравнение суммы счёта с введённой суммой
                {
                    Console.WriteLine("Сравнение суммы счёта с введённой суммой.");
                    Money money_2 = EnteringOfMoney();
                    if(money_2 < money)
                    {
                        Console.WriteLine(money_2.ToString() + " < " + money.ToString());
                    }else if (money < money_2)
                    {
                        Console.WriteLine(money_2.ToString() + " > " + money.ToString());
                    }
                    else if (money == money_2)
                    {
                        Console.WriteLine(money.ToString() + " = " + money_2.ToString());
                    }
                    Console.ReadKey();
                }
                else if (choice == 8)   // Выход
                {
                    exit = true;
                }



            } while (!exit);
        }

        public static Money EnteringOfMoney()
        {
            int rub = 0;
            int kop = 0;
            bool allRight = true;
            do
            {
                Console.Write("Введите размер счёта:\nколичество рублей: ");
                try
                {
                    rub = Convert.ToInt32(Console.ReadLine());
                    Console.Write("количество копеек: ");
                    kop = Convert.ToByte(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    allRight = false;
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
                if (allRight)
                {
                    break;
                }
                allRight = true;
                Console.Clear();
            } while (true);
            Money money = new Money(rub, kop);
            return money;
        }

        public static int CheckNumber()
        {
            int number = 0;
            bool flag;
            do
            {
                flag = true;
                try
                {
                    Console.Write("Введите целое число: ");
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    flag = false;
                }


            } while (!flag);
            return number;
        }
    }
}
