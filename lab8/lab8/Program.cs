using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    abstract class Film
    {
        public string Name { get; set; }
        public Film()
        {
            Name = "неизвестно";
        }
        public Film(string name)
        {
            this.Name = name;
        }
        public virtual void Show()
        {
            Console.WriteLine("Название: " + Name);
        }
    }
    class News : Film
    {
        public string theme;
        public int speakers;
        public News()
        {
            theme = "something";
            speakers = 0;
        }
        public News(string theme, int speakers, string name): base(name)
        {
            this.theme = theme;
            this.speakers = speakers;
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Тема: " + theme + "\n" + "Ведущиx: " + speakers);
        }
    }
    interface IGenrable<T>
    {
        void Add(T elem);
        void Remove(T elem);
        void Show(Set<T> elems);
    }
    public class Exceptionist : Exception
    {
        public Exceptionist(string message) : base(message)
        {

        }
    }
    public class Set<T> : IGenrable<T>
    {
        public List<T> Items = new List<T>();

        public void Add(T item)
        {
            if (!Items.Contains(item))
            {
                Items.Add(item);
            }
        }
       
        public void Remove(T item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
            else
            {
                throw new Exceptionist("элемента не существует, невозможно удалить");
            }
        }

        public void Show(Set<T> Item)
        {
            foreach (T elem in Item.Items)
            {
                Console.Write($"{elem}  ");
            }
            Console.WriteLine();
        }
        public static int count;
        public Set()
        {
            count++;
            Console.WriteLine($"Создано {count}-е множество");
        }
        public static string operator >(T elem, Set<T> item)
        {

            if (item.Items.Contains(elem))
            {
                return $"{elem} находится в этом множестве";
            }
            else
            {
                return $"{elem} нету в  этом множестве";
            }
        }
        public static string operator <(T item1, Set<T> item2)
        {
            if (!item2.Items.Contains((item1)))
            {
                return $"{item1} нету в этом множестве";
            }
            else
            {
                return $"{item1} есть в этом множестве";
            }
        }
        public static string operator *(Set<T> item1, Set<T> item2)
        {
            Console.WriteLine("Пересечение множеств");
            List<T> item3 = new List<T>();
            foreach (T elem in item1.Items)
            {
                if (item2.Items.Contains(elem))
                {
                    item3.Add(elem);
                }
            }
            foreach (T elems in item3)
            {
                Console.WriteLine(elems);
            }
            return null;
        }
        
    }
   
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Set<int> obj1 = new Set<int>();
                obj1.Add(-5);
                obj1.Add(3);
                obj1.Add(-2);
                obj1.Add(7);
                obj1.Add(3);
                obj1.Add(-1);
                obj1.Show(obj1);
                Set<News> obj2 = new Set<News>();
                News a1;
                a1 = new News("Weather", 2, "Morning show");
                obj2.Add(a1);
                a1.Show();

            }
            catch(Exceptionist ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("конец!");
            }
        }
    }
}
