using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior _warrior = new Warrior(new Run());
            _warrior.Run();
            _warrior.State = new Idle();
            _warrior.Run();

            Console.ReadLine();

        }
    }
   
    public interface WarriorState
    {
        void Run(Warrior warrior);
        void Idle(Warrior warrior);
        void Jump(Warrior warrior);
    }

    public class Warrior
    {
        public WarriorState State { set; get; }

        public Warrior(WarriorState state)
        {
            State = state;
        }

        public void Run()
        {
            State.Run(this);
        }
        public void Idle()
        {
            State.Idle(this);
        }
        public void Jump()
        {
            State.Jump(this);
        }


    }

    public class Run : WarriorState
    {
       

        public void Idle(Warrior warrior)
        {
            Console.WriteLine("Перестали стоять");
        }

        public void Jump(Warrior warrior)
        {
            Console.WriteLine("Не прыгаем");
        }

        void WarriorState.Run(Warrior warrior)
        {
            Console.WriteLine("Начали бежать ");
        }
    }
    public class Idle : WarriorState
    {
        void WarriorState.Idle(Warrior warrior)
        {
            Console.WriteLine("Остановились");
        }

        public void Jump(Warrior warrior)
        {
            Console.WriteLine("Все еще не прыгаем");
        }

        void WarriorState.Run(Warrior warrior)
        {
            Console.WriteLine("Перестали бежать");
        }
    }
    public class Jump : WarriorState
    {
        public void Idle(Warrior warrior)
        {
            Console.WriteLine("Перестали стоять");
        }

        void WarriorState.Jump(Warrior warrior)
        {
            Console.WriteLine("Прыгаем");
        }

        public void Run(Warrior warrior)
        {
            Console.WriteLine("Перестали бежать");
        }
    }




}
