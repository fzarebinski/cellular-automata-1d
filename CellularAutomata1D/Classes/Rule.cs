using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomata1D {
    class Rule {
        private bool[] rules;
        private bool value;

        public Rule(bool rule1, bool rule2, bool rule3, bool value) {
            this.rules = new bool[] { rule1, rule2, rule3 };
            this.value = value;
        }

        public bool Validate(bool[] rules) {
            if (rules.Length != this.rules.Length) return false;

            for (int i = 0; i < this.rules.Length; i++) {
                if (this.rules[i] != rules[i]) {
                    return false;
                };
            };

            return true;
        }

        public bool GetValue() {
            return this.value;
        }

        public void SetValue(bool value) {
            this.value = value;
        }
    }
}
