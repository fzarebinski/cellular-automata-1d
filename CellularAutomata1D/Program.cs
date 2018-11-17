using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomata1D {
    class Program {
        static void Main(string[] args) {
            // Set init values
            int length = 80;
            int steps = 29;
            int rule = 18;

            // Prepare array, set true in center
            bool[] cell = new bool[length];

            cell[length / 2] = true;

            // Declare rule to generate
            RulesValidator.DeclareRule(rule);

            // Generate array and print it
            for (int i = 0; i < steps; i++) {
                for (int j = 0; j < cell.Length; j++) {
                    Console.Write(cell[j] ? 'X' : ' ');
                };

                cell = RulesValidator.GenerateArray(cell);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
