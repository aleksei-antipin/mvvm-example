using System;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Application
{
    [CreateAssetMenu(fileName = "Player Storage", order = 0, menuName = "Test/ Player Storage")]
    public class PlayerStorage : ScriptableObject
    {
        [SerializeField] private MetaPlayerPrototype _playerPrototype;

        public MetaPlayerPrototype PlayerPrototype => _playerPrototype;

        [Serializable]
        public class IdValuePair
        {
            public int id;
            public float value;
        }

        [Serializable]
        public class MetaPlayerPrototype
        {
            public List<IdValuePair> wallet;
            public List<IdValuePair> inventory;
        }
    }
}