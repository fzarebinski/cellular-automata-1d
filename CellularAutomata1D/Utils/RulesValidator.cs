using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomata1D {
    class RulesValidator {
        public static Rule[] Rules = new Rule[] {
            new Rule( true, true, true, false ),
            new Rule( true, true, false, false ),
            new Rule( true, false, true, false ),
            new Rule( true, false, false, false ),
            new Rule( false, true, true, false ),
            new Rule( false, true, false, false ),
            new Rule( false, false, true, false ),
            new Rule( false, false, false, false )
        };

        public static void DeclareRule(int number) {
            string binary = Convert.ToString(number, 2);

            for (int i = (RulesValidator.Rules.Length - 1), j = (binary.Length - 1); j >= 0; i--, j--) {
                RulesValidator.Rules[i].SetValue(binary[j] == '1');
            };
        }

        private static bool GetPrevious(bool[] currentCell, int i) {
            i--;

            if (i < 0) return currentCell[currentCell.Length - 1];
            return currentCell[i];
        }

        private static bool GetNext(bool[] currentCell, int i) {
            i++;

            if (i >= currentCell.Length) return currentCell[0];
            return currentCell[i];
        }

        public static bool[] GenerateArray(bool[] currentCell) {
            bool[] newCell = new bool[currentCell.Length];

            for (int i = 0; i < currentCell.Length; i++) {
                for (int j = 0; j < RulesValidator.Rules.Length; j++) {
                    bool[] rules = new bool[] {
                        RulesValidator.GetPrevious(currentCell, i),
                        currentCell[i],
                        RulesValidator.GetNext(currentCell, i)
                    };

                    if (RulesValidator.Rules[j].Validate(rules)) {
                        newCell[i] = RulesValidator.Rules[j].GetValue();
                        break;
                    };
                };
            }

            return newCell;
        }
    }
}
