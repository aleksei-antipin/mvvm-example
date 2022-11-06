using System;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Infrastructure
{
    [CreateAssetMenu(fileName = "Player Storage", order = 0, menuName = "Test/ Player Storage")]
    public class PlayerStorage : ScriptableObject
    {
        [SerializeField] private MetaPlayerPrototype _playerPrototype;

        public MetaPlayerPrototype PlayerPrototype => PlayerPrototype;

        [Serializable]
        public class IdValuePair
        {
            public int id;
            public float value;
        }

        [Serializable]
        public class MetaPlayerPrototype
        {
            public List<IdValuePair> _wallet;
            public List<IdValuePair> _inventory;
        }
    }
}