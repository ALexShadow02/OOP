using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Media;
using System.Threading;
using SubjectArea;
namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Performance> perfs = new List<Performance>();
            perfs.Add(new Performance("Тартюф", "Мольер", Genres.Comedy, DateTime.Now.AddDays(2)));
            perfs.Add(new Performance("Тартюф", "Мольер", Genres.Comedy, DateTime.Now));
            perfs.Add(new Performance("Укрощение строптивой", "Уильям Шекспир", Genres.Comedy, DateTime.Now.AddDays(1)));
            perfs.Add(new Performance("Укрощение строптивой", "Уильям Шекспир", Genres.Comedy, DateTime.Now));
            perfs.Add(new Performance("Король забавляется", "Виктор Гюго", Genres.Drama, DateTime.Now.AddDays(1)));
            perfs.Add(new Performance("Мария Тюдор", "Виктор Гюго", Genres.Drama, DateTime.Now));
            perfs.Add(new Performance("Мариан Делорм", "Виктор Гюго", Genres.Tragedy, DateTime.Now.AddDays(2)));
            perfs.Add(new Performance("Орлеанская дева", "Фридрих Шиллер", Genres.Drama, DateTime.Now));
            perfs.Add(new Performance("Мария Стюарт", "Фридрих Шиллер", Genres.Tragedy, DateTime.Now.AddDays(1)));
            perfs.Add(new Performance("Кошки", "Ллойд Уэббер", Genres.Musical, DateTime.Now.AddDays(2)));
            perfs.Add(new Performance("Призрак оперы", "Ллойд Уэббер", Genres.Musical, DateTime.Now.AddDays(1)));
            Affiche aff = new Affiche(perfs);
            AfficheInteraction AffInter = new AfficheInteraction(aff);
            AffInter.Intro();
        }
    }
    sealed class PerformanceInteraction
    {
        Performance perf;
        public PerformanceInteraction(Performance perf)
        {
            this.perf = perf;
        }
        public void TakeTicket()
        {
            WriteLine("Переход в кассу...");
            Thread.Sleep(2000);
            Clear();
            int num;
            while (true)
            {
                Write("Укажите желаемое количество билетов: ");
                if (Int32.TryParse(ReadLine(),out num))
                {
                    if (num <= perf.TicketsLeft())
                    {
                        if (num == 1)
                        {
                            Clear();
                            int price;
                            while (true)
                            {
                                WriteLine("Билеты доступны в следующих ценовых категориях: 100 у.е.,300 у.е.,500 у.е.,1000 у.е.\n");
                                Write("Выберите цену билета: ");
                                if (Int32.TryParse(ReadLine(), out price) && (price == 100 || price == 300 || price == 500 || price == 1000)) break;
                                Clear();
                            }
                            WriteLine("Билет куплен успешно");
                            ref int ticketpointer = ref perf.GetTickPtr(price);
                            ref Ticket[] ticketarray = ref perf.GetTickArr(price);
                            ticketarray[ticketpointer].Buy();
                            ticketpointer++;
                            WriteLine("Осталось в данной ценовой категории: " + perf.TicketsLeft(price));
                        }
                        else
                        {
                            byte choice;
                            while (true)
                            {
                                WriteLine("Все билеты в разных ценовых категориях - 1");
                                WriteLine("Все билеты в одной ценовой категории - 2");
                                choice = Convert.ToByte(ReadLine());
                                if (choice == 1 || choice == 2) break;
                                Clear();
                            }
                            Clear();
                            if (choice == 1)
                            {
                                for (int i = 1; i <= num; i++)
                                {
                                    int price;
                                    while (true)
                                    {
                                        if (i == 1) WriteLine("Билеты доступны в следующих ценовых категориях: 100 у.е.,300 у.е.,500 у.е.,1000 у.е.\n");
                                        Write($"Выберите цену {i}-го билета: ");
                                        if (Int32.TryParse(ReadLine(), out price) && (price == 100 || price == 300 || price == 500 || price == 1000)) break;
                                        Clear();
                                    }
                                    if (perf.TicketsLeft(price) > 0)
                                    {
                                        WriteLine("Билет куплен успешно");
                                        ref int ticketpointer = ref perf.GetTickPtr(price);
                                        ref Ticket[] ticketarray = ref perf.GetTickArr(price);
                                        ticketarray[ticketpointer].Buy();
                                        ticketpointer++;
                                        WriteLine($"Осталось в данной ценовой категории: {perf.TicketsLeft(price)}");
                                    }
                                    else
                                    {
                                        WriteLine("К сожалению, в данной ценовой категории билетов не осталось");
                                    }
                                }
                            }
                            else
                            {
                                int price;
                                while (true)
                                {
                                    WriteLine("Билеты доступны в следующих ценовых категориях: 100 у.е.,300 у.е.,500 у.е.,1000 у.е.");
                                    Write("Выберите цену каждого билета: ");
                                    if (Int32.TryParse(ReadLine(), out price) && (price == 100 || price == 300 || price == 500 || price == 1000)) break;
                                    Clear();
                                }
                                if (perf.TicketsLeft(price) >= num)
                                {

                                    WriteLine("Билеты куплены успешно");
                                    ref int ticketpointer = ref perf.GetTickPtr(price);
                                    ref Ticket[] ticketarray = ref perf.GetTickArr(price);
                                    for (int i = ticketpointer; i < ticketpointer + num; i++) ticketarray[i].Buy();
                                    ticketpointer += num;
                                    WriteLine($"Осталось в данной ценовой категории: {perf.TicketsLeft(price)}");
                                }
                                else
                                {
                                    Clear();
                                    WriteLine("В данной ценовой категории осталось меньше билетов, чем вы желаете");
                                }
                            }
                        }
                    }
                    else WriteLine("К сожалению, осталось меньше билетов, чем вы желаете.");
                    break;
                }
                else Clear();
            }
            Thread.Sleep(2000);
        }
        public void Menu()
        {
            WriteLine("Переход в меню...");
            Thread.Sleep(1000);
            Clear();
            ConsoleKeyInfo choice;
            while (true)
            {
                WriteLine("Выбрать билет - 1");
                WriteLine("Просмотреть количество оставшихся билетов - 2");
                Write("Ваш выбор: ");
                choice = ReadKey();
                WriteLine();
                if (choice.Key == ConsoleKey.D1 || choice.Key==ConsoleKey.D2)
                {
                    Clear();
                    if (choice.Key == ConsoleKey.D1) TakeTicket();
                    else
                    {
                        ConsoleKeyInfo quit;
                        while (true)
                        {
                            WriteLine("Количество оставшихся билетов в каждой ценовой категории: ");
                            WriteLine($"100 у.е. - {perf.TicketsLeft(100)}");
                            WriteLine($"300 у.е. - {perf.TicketsLeft(300)}");
                            WriteLine($"500 у.е. - {perf.TicketsLeft(500)}");
                            WriteLine($"1000 у.е. - {perf.TicketsLeft(1000)}");
                            WriteLine($"Всего - {perf.TicketsLeft()}");
                            WriteLine("Вернуться назад - Q");
                            quit = ReadKey();
                            if (quit.Key == ConsoleKey.Q) break;
                            Clear();
                        }
                    }
                    break;
                }
                Clear();
            }
        }
        public override string ToString() => $"Название: {perf.Name}. Автор: {perf.Author}. Жанр: {perf.Genre}.";
    }
    class AfficheInteraction {
        PerformanceInteraction PerfInter;
        Affiche aff;
        public AfficheInteraction(Affiche aff)
        {
            this.aff = aff;
        }
        public void Intro()
        {
            while (true)
            {
                ConsoleKeyInfo choice1;
                while (true)
                {
                    WriteLine("Перед вами афиша представлений. Выберите интересующее вас, введя соответсвующую цифру: ");
                    WriteLine($"Текущая дата: {aff.Date.ToString("dd.MM.yyyy")}\n");
                    int i = 1;
                    for (int c=0; c < aff.Performances.Count; c++)
                    {
                        if (aff.Performances[c].Date.ToString("dd.MM.yyyy") == aff.Date.ToString("dd.MM.yyyy"))
                        {
                            WriteLine("    " + aff.Performances[c] + " - " + i);
                            i++;
                        }
                    }
                    if (i == 1) WriteLine("    К сожалению, сегодня доступных представлений нет.");
                    WriteLine();
                    WriteLine("Следующий день - 9");
                    WriteLine("Вернуться домой - home");
                    WriteLine("Поиск по определенному критерию - S");
                    WriteLine("Выход из программы - 0");
                    Write("Ваш выбор: ");
                    choice1 = ReadKey();
                    WriteLine();
                    if (choice1.Key == ConsoleKey.D1 || choice1.Key == ConsoleKey.D2 || choice1.Key == ConsoleKey.D3 || choice1.Key == ConsoleKey.D4 || choice1.Key == ConsoleKey.D5) break;
                    else if (choice1.Key == ConsoleKey.D0)
                    {
                        Clear();
                        Environment.Exit(0);
                    }
                    else if (choice1.Key == ConsoleKey.Home || choice1.Key==ConsoleKey.D9)
                    {
                        aff.Date=choice1.Key==ConsoleKey.Home? DateTime.Now: aff.Date.AddDays(1);
                        Clear();
                        Intro();
                        Environment.Exit(1);
                    }
                    else if (choice1.Key == ConsoleKey.S)
                    {
                        Clear();
                        SearchMenu();
                    }
                    Clear();
                }
                Performance perf = aff.Performances[Convert.ToInt32(Char.GetNumericValue(choice1.KeyChar)) - 1];
                Clear();
                PerfInter = new PerformanceInteraction(perf);
                PerfInter.Menu();
                while (true)
                {
                    ConsoleKeyInfo choice2;
                    Clear();
                    WriteLine("Желаете выбрать билеты на иное представление - 1");
                    WriteLine("Покинуть афишу - 2");
                    Write("Ваш выбор: ");
                    choice2 = ReadKey();
                    WriteLine();
                    if (choice2.Key == ConsoleKey.D1)
                    {
                        Clear();
                        break;
                    }
                    if (choice2.Key == ConsoleKey.D2)
                    {
                        Clear();
                        Environment.Exit(0);
                    }
                    Clear();
                }
            }
        }
        void SearchMenu()
        {
            void LocalFunction(byte type)
            {
                string temp;
                while (true)
                {
                    Clear();
                    if (type == 1)
                    {
                        WriteLine("Доступные авторы: ");
                        foreach (string author in aff.Authors) WriteLine(author);
                        Write("Введите автора: ");
                    }
                    else if (type == 2) {
                        WriteLine("Доступные названия: ");
                        foreach (string name in aff.Names) WriteLine(name);
                        Write("Введите имя: ");
                    }
                    else {
                        WriteLine("Доступные жанры: ");
                        foreach (string genre in aff.Genres) WriteLine(genre);
                        Write("Введите жанр: ");
                    }
                    temp = ReadLine();
                    List<Performance> list;
                    if (type == 1) list = aff.GetByAuthor(temp);
                    else if (type == 2) list = aff.GetByName(temp);
                    else list = aff.GetByGenre(temp);
                    bool qflag;
                    ConsoleKeyInfo next;
                    while (true)
                    {
                        if (list.Count == 0) WriteLine("К сожалению, по вашему запросу ничего не найдено");
                        else foreach (Performance perf in list) WriteLine(perf+$" Дата: {perf.Date.ToString("dd.MM.yyyy")}");
                        WriteLine("Попробовать снова  - A");
                        WriteLine("Покинуть меню поиска - Q");
                        next = ReadKey();
                        if (next.Key == ConsoleKey.Q) { qflag = true; break; }
                        if (next.Key == ConsoleKey.A) { qflag = false; break; }
                        Clear();
                    }
                    if (qflag) break;
                    else continue;
                }
            }
            ConsoleKeyInfo choice;
            while (true)
            {
                WriteLine("Критерии поиска: ");
                WriteLine("По автору - 1");
                WriteLine("По названию - 2");
                WriteLine("По жанру - 3");
                Write("Ваш выбор: ");
                choice = ReadKey();
                if (choice.Key == ConsoleKey.D1 || choice.Key == ConsoleKey.D2 || choice.Key == ConsoleKey.D3) break;
                Clear();
            }
            LocalFunction((byte)Char.GetNumericValue(choice.KeyChar));
        }
    }
}
