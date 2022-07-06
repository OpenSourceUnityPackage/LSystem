using System;
using NUnit.Framework;

namespace LSystemPackage
{
    public class LSystemTest
    {
        struct Rule : ILSystemRule
        {
            public string sequenceToInsert;
            public string SequenceToInsert => sequenceToInsert;
        }
        
        class LSystemVariable : ILSystemRuleVariable
        {
            public char symbol;
            public Rule rule;

            public ILSystemRule Rule => rule;
            public char Symbol => symbol;
        }
        
        public class LSystemActionVariable : ILSystemActionVariable
        {
            public char symbol;
            public Action<char> action;

            public char Symbol => symbol;

            public void OnSymbolFind()
            {
                action(Symbol);
            }
        }

        string ProcessComplexPattern(int iteration)
        {
            Rule XRule = new Rule {sequenceToInsert = "F+[[X]-X]-F[-FX]+X"};
            Rule FRule = new Rule {sequenceToInsert = "FF"};
            
            LSystemVariable[] variables = new LSystemVariable[2];
            variables[0] = new LSystemVariable{symbol = 'X', rule = XRule};
            variables[1] = new LSystemVariable{symbol = 'F', rule = FRule};

            return LSystem.BuildSequence(variables, iteration, "X");
        }
        
        [Test]
        public void LSystemTestComplexPattern0Iteration()
        {
            string rst = "X";
            Assert.AreEqual(rst, ProcessComplexPattern(0));
        }
        
        [Test]
        public void LSystemTestComplexPattern1Iteration()
        {
            string rst = "F+[[X]-X]-F[-FX]+X";
            Assert.AreEqual(rst, ProcessComplexPattern(1));
            
        }
        
        [Test]
        public void LSystemTestComplexPattern2Iteration()
        {
            string rst = "FF+[[F+[[X]-X]-F[-FX]+X]-F+[[X]-X]-F[-FX]+X]-FF[-FFF+[[X]-X]-F[-FX]+X]+F+[[X]-X]-F[-FX]+X";
            Assert.AreEqual(rst, ProcessComplexPattern(2));
        }
        
        [Test]
        public void LSystemTestComplexPattern3Iteration()
        {
            string rst =
                "FFFF+[[FF+[[F+[[X]-X]-F[-FX]+X]-F+[[X]-X]-F[-FX]+X]-FF[-FFF+[[X]-" +
                "X]-F[-FX]+X]+F+[[X]-X]-F[-FX]+X]-FF+[[F+[[X]-X]-F[-FX]+X]-F+[[X]-X]" +
                "-F[-FX]+X]-FF[-FFF+[[X]-X]-F[-FX]+X]+F+[[X]-X]-F[-FX]+X]-FFFF[-FFFFFF+" +
                "[[F+[[X]-X]-F[-FX]+X]-F+[[X]-X]-F[-FX]+X]-FF[-FFF+[[X]-X]-F[-FX]+X]+F" +
                "+[[X]-X]-F[-FX]+X]+FF+[[F+[[X]-X]-F[-FX]+X]-F+[[X]-X]-F[-FX]+X]-FF[-FFF+" +
                "[[X]-X]-F[-FX]+X]+F+[[X]-X]-F[-FX]+X";
            
            Assert.AreEqual(ProcessComplexPattern(3), rst);
        }
        
        [Test]
        public void LSystemTestComplexPatternParsing()
        {
            int XCount = 0;
            int PlusCount = 0;
            
            void increaseXSymbolCount(char symbol)
            {
                Assert.AreEqual('X', symbol);
                XCount++;
            }

            void increasePlusSymbolCount(char symbol)
            {
                Assert.AreEqual('+', symbol);
                PlusCount++;
            }
            
            string sequence = ProcessComplexPattern(1);
            
            LSystemActionVariable[] variables = new LSystemActionVariable[2];
            variables[0] = new LSystemActionVariable{symbol = 'X', action = increaseXSymbolCount};
            variables[1] = new LSystemActionVariable{symbol = '+', action = increasePlusSymbolCount};
            
            LSystem.ProcessSequence(variables, sequence);

            Assert.AreEqual(4, XCount);
            Assert.AreEqual(2, PlusCount);
        }
    }
}