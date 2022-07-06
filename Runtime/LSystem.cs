using System.Collections.Generic;
using System.Text;

namespace LSystemPackage
{
    /// <summary>
    /// An L-system or Lindenmayer system is a tools to create grammar sequence depending on rules.
    /// This sequence can be used later by a reader for procedure generation purposes. 
    /// </summary>
    /// <see cref="https://en.wikipedia.org/wiki/L-system"/>
    public static class LSystem
    {
        /// <summary>
        /// Call this function to build a L-System sequence depending on your set of variables
        /// </summary>
        /// <param name="variables">A list/array of you class that override interface ILSystemRuleVariable</param>
        /// <param name="iterationCount"></param>
        /// <param name="rootSequence"></param>
        /// <returns></returns>
        public static string BuildSequence(IEnumerable<ILSystemRuleVariable> variables, int iterationCount,
            string rootSequence)
        {
            return GrowRecursive(variables, iterationCount, rootSequence);
        }

        /// <summary>
        /// Call this function to parse a sequence and call functions depending on your set of variables
        /// </summary>
        /// <param name="variables">A list/array of you class that override interface ILSystemActionVariable</param>
        /// <param name="sequence"></param>
        public static void ProcessSequence(IEnumerable<ILSystemActionVariable> variables, string sequence)
        {
            foreach (char symbol in sequence)
            {
                foreach (ILSystemActionVariable variable in variables)
                {
                    if (variable.Symbol == symbol)
                    {
                        variable.OnSymbolFind();
                    }
                }
            }
        }

        private static string GrowRecursive(IEnumerable<ILSystemRuleVariable> variables, int iterationCount,
            string sequence, int iterationIndex = 0)
        {
            if (string.IsNullOrEmpty(sequence) || iterationIndex >= iterationCount)
            {
                return sequence;
            }

            StringBuilder newSequence = new StringBuilder();

            for (int index = 0; index < sequence.Length; index++)
            {
                char c = sequence[index];
                ProcessRulesRecursively(variables, iterationCount, newSequence, c, iterationIndex);
            }

            return newSequence.ToString();
        }

        private static void ProcessRulesRecursively(IEnumerable<ILSystemRuleVariable> variables, int iterationCount,
            StringBuilder newSequence, char c, int iterationIndex)
        {
            foreach (ILSystemRuleVariable variable in variables)
            {
                if (variable.Symbol == c)
                {
                    newSequence.Append(GrowRecursive(variables, iterationCount, variable.Rule.SequenceToInsert,
                        iterationIndex + 1));
                    return;
                }
            }

            newSequence.Append(GrowRecursive(variables, iterationCount, c.ToString(), iterationIndex + 1));
        }
    }
}