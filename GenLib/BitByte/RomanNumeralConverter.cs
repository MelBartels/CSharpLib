using System.Collections.Generic;

namespace GenLib.BitByte
{
    public class RomanNumeralConverter
    {
        public int Convert(string romanNumeral)
        {
            var context = new Context(romanNumeral);

            // Build the 'parse tree'
            var tree = new List<Expression>
                           {
                               new ThousandExpression(),
                               new HundredExpression(),
                               new TenExpression(),
                               new OneExpression()
                           };

            // Interpret
            tree.ForEach(e => e.Interpret(context));

            return context.Output;
        }
    }

    internal class Context
    {
        public Context(string input)
        {
            Input = input;
        }

        public string Input { get; set; }
        public int Output { get; set; }
    }

    internal abstract class Expression
    {
        public void Interpret(Context context)
        {
            if (context.Input.Length == 0) return;

            if (context.Input.StartsWith(Nine()))
            {
                context.Output += (9*Multiplier());
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Four()))
            {
                context.Output += (4*Multiplier());
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Five()))
            {
                context.Output += (5*Multiplier());
                context.Input = context.Input.Substring(1);
            }

            while (context.Input.StartsWith(One()))
            {
                context.Output += (1*Multiplier());
                context.Input = context.Input.Substring(1);
            }
        }

        public abstract string One();
        public abstract string Four();
        public abstract string Five();
        public abstract string Nine();
        public abstract int Multiplier();
    }

    internal class ThousandExpression : Expression
    {
        public override string One()
        {
            return "M";
        }

        public override string Four()
        {
            return " ";
        }

        public override string Five()
        {
            return " ";
        }

        public override string Nine()
        {
            return " ";
        }

        public override int Multiplier()
        {
            return 1000;
        }
    }

    internal class HundredExpression : Expression
    {
        public override string One()
        {
            return "C";
        }

        public override string Four()
        {
            return "CD";
        }

        public override string Five()
        {
            return "D";
        }

        public override string Nine()
        {
            return "CM";
        }

        public override int Multiplier()
        {
            return 100;
        }
    }

    internal class TenExpression : Expression
    {
        public override string One()
        {
            return "X";
        }

        public override string Four()
        {
            return "XL";
        }

        public override string Five()
        {
            return "L";
        }

        public override string Nine()
        {
            return "XC";
        }

        public override int Multiplier()
        {
            return 10;
        }
    }

    internal class OneExpression : Expression
    {
        public override string One()
        {
            return "I";
        }

        public override string Four()
        {
            return "IV";
        }

        public override string Five()
        {
            return "V";
        }

        public override string Nine()
        {
            return "IX";
        }

        public override int Multiplier()
        {
            return 1;
        }
    }
}