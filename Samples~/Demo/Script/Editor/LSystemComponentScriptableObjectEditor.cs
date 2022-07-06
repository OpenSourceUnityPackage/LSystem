using UnityEditor;
using UnityEngine;

namespace LSystemPackage
{
    [CustomEditor(typeof(LSystemComponentScriptableObject))]
    class LSystemComponentScriptableObjectEditor : Editor
    {
        private LSystemComponentScriptableObject current;

        private void OnEnable()
        {
            current = target as LSystemComponentScriptableObject;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Test log sequence"))
                Debug.Log("Test LSystem sequence:" +
                          LSystem.BuildSequence(current.rules, current.iterationCount, current.rootSequence));
        }
    }
}