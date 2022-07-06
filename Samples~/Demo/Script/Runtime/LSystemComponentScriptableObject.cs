using UnityEngine;

namespace LSystemPackage
{
    [CreateAssetMenu(fileName = "LSystem", menuName = "ScriptableObjects/L-system/LSystemComponent", order = 1)]
    public class LSystemComponentScriptableObject : ScriptableObject
    {
        public LSystemGenericVariable[] rules;

        [Min(0)] public int iterationCount;
        public string rootSequence;
    }
}