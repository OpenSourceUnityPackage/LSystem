using LSystemPackage;
using UnityEngine;

public class LSystemVariable : ILSystemRuleVariable
{
    public char symbol;
    public Rule rule;

    public ILSystemRule Rule => rule;
    public char Symbol => symbol;
}

public class LSystemVariableRandomMultiRule : ILSystemRuleVariable
{
    public char symbol;
    public Rule[] rules;

    public ILSystemRule Rule => rules[Random.Range(0, rules.Length)];
    public char Symbol => symbol;
}