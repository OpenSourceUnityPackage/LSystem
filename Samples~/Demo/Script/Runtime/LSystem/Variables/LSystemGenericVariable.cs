using System;
using System.Linq;
using LSystemPackage;
using Random = UnityEngine.Random;

[Serializable]
public class LSystemGenericVariable : ILSystemRuleVariable
{
    public string symbol; // As char but string for list inspection (element name)
    public Rule[] rules;
    public bool useRandom;

    public char Symbol => symbol.First();
    public ILSystemRule Rule => useRandom ? rules[Random.Range(0, rules.Length)] : rules[0];
}