using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Command
{
    public abstract class Command
    {
        protected Light _light;
        public Command(Light light)
        {
            _light = light;
        }
        public abstract void Execute();
    }
    public class TurnOnCommand : Command
    {
        public TurnOnCommand(Light light) : base(light)
        {
        }
        public override void Execute()
        {
            _light.TurnOn();
        }
    }
    public class TurnOffCommand : Command
    {
        public TurnOffCommand(Light light):base(light)
        {
        }
        public override void Execute()
        {
            _light.TurnOff();
        }
    }

    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Turned On");
        }
        public void TurnOff()
        {
            Console.WriteLine("Turned Off");
        }
    }

    public class Switch
    {
        Command _command;
        public void SetCommand(Command command)
        {
            _command = command;
        }
        public void Execute()
        {
            _command.Execute();
        }
    }

    public class Using
    {
        public static void Use()
        {
            Light _light = new Light();
            Command _turnOnCommand = new TurnOnCommand(_light);
            Command _turnOffCommand = new TurnOffCommand(_light);
            Switch _switch = new Switch();

            _switch.SetCommand(_turnOffCommand);
            _switch.Execute();

            _switch.SetCommand(_turnOnCommand);
            _switch.Execute();
            // Wait for user

            Console.ReadKey();
        }
    }
}
