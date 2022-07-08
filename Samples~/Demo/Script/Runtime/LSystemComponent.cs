using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace LSystemPackage
{
    [Serializable]
    public class LSystemActionVariable : ILSystemActionVariable
    {
        [System.Serializable]
        public class CharEvent : UnityEvent<char>
        {
        }
        
        public string symbol;
        public CharEvent action;

        public char Symbol => symbol.First();

        public void OnSymbolFind()
        {
            action?.Invoke(Symbol);
        }
    }

    public class LSystemComponent : MonoBehaviour
    {
        public LSystemComponentScriptableObject ruleSet;
        public List<LSystemActionVariable> actionSet = new List<LSystemActionVariable>();

        private void Start()
        {
            string sequence = LSystem.BuildSequence(ruleSet.rules, ruleSet.iterationCount, ruleSet.rootSequence);
            LSystem.ProcessSequence(actionSet, sequence);
        }

        public static void ProcessASymbol(char symbol)
        {
            Assert.AreEqual('A', symbol);
            Debug.Log(symbol);
        }

        public static void ProcessBSymbol(char symbol)
        {
            Assert.AreEqual('B', symbol);
            Debug.Log(symbol);
        }
    }
}