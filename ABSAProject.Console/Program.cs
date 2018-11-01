using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSAProject.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter a set of instructions.");
                System.Console.WriteLine("For Example: N4,E2,S2,W4");
                return;
            }

            string[] instructions = args[0].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            List<string> steps = new List<string>();
            instructions.ToList().ForEach(item => steps.AddRange(Enumerable.Repeat<String>(item.Substring(0, 1), Convert.ToInt32(item.Substring(1, 1))).ToList<String>()));
            Dictionary<string, string> ht = new Dictionary<string, string>();

            int x_point = 0;
            int y_point = 0;
            int stepCount = 0;

            foreach (string step in steps)
            {
                if (stepCount == 0 && x_point == 0 && y_point == 0)
                {
                    ht.Add($"x{x_point}_y{y_point}", step);
                    stepCount = stepCount + 1;
                    continue;
                }

                if (step == "N")
                {
                    y_point = y_point + 1;
                }

                if (step == "S")
                {
                    y_point = y_point - 1;
                }

                if (step == "E")
                {
                    x_point = x_point + 1;
                }

                if (step == "W")
                {
                    x_point = x_point - 1;
                }

                if (!ht.ContainsKey($"x{x_point}_y{y_point}"))
                {
                    ht.Add($"x{x_point}_y{y_point}", step);
                    stepCount = stepCount + 1;
                }
            }

            System.Console.WriteLine($"Number Of Steps: {stepCount}");
        }
    }
}
