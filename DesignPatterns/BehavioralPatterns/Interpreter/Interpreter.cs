using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Interpreter
{
    public class Context
    {
        private string _input;
        public Context(string input)
        {
            _input = input;
        }
        public string Input { get { return _input; } set { _input = value; } }
    }
    abstract class AbstractExpression
    {
        public void Interpret(Context context)
        {
            if (context.Input.Length == 0)
                return;
            if (context.Input.StartsWith(Sentence()))
            {
                Draw();
                context.Input = context.Input.Substring(Sentence().Length).Trim();
            }
        }
        public abstract string Sentence();
        public abstract void Draw();
    }
    class CircleExpression : AbstractExpression
    {
        public override void Draw()
        {
            Console.WriteLine("Circle");
        }

        public override string Sentence()
        {
            return "circle";
        }
    }
    class RectangleExpression : AbstractExpression
    {
        public override void Draw()
        {
            Console.WriteLine("Rectangle");
        }

        public override string Sentence()
        {
            return "rectangle";
        }
    }
    public class Using
    {
        public static void Use()
        {
            var exp = "circle rectangle";
            Context context = new Context(exp);

            List<AbstractExpression> expressionTree = new List<AbstractExpression>();
            expressionTree.Add(new CircleExpression());
            expressionTree.Add(new RectangleExpression());
            foreach (var item in expressionTree)
            {
                item.Interpret(context);
            }
            // Wait for user

            Console.ReadKey();
        }
    }
}
