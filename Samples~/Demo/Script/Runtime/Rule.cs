using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LSystemPackage
{
    [Serializable]
    public struct Rule : ILSystemRule
    {
        public string sequenceToInsert;

        [Range(0, 1)] public float probabilityToIgnore;

        public string SequenceToInsert =>
            (probabilityToIgnore != 0f && Random.value < probabilityToIgnore) ? "" : sequenceToInsert;
    }
}