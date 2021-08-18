using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.HomeWork.Dictionary
{
    public class SerializationDictionary:MonoBehaviour, ISerializationCallbackReceiver
    {
        public List<int> _keys = new List<int>{1, 2 ,3, 4, 5};
        public List<string> _value = new List<string> {"walk", "run", "attack", "defence","magic" };

        public Dictionary<int, string> _dictionary = new Dictionary<int, string>();

        public void OnBeforeSerialize()
        {
            _keys.Clear();
            _value.Clear();
            foreach (var dict in _dictionary)
            {
                _keys.Add(dict.Key);
                _value.Add(dict.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            _dictionary = new Dictionary<int, string>();
            for (int i = 0; i != Math.Min(_keys.Count, _value.Count); i++)
                _dictionary.Add(_keys[i],_value[i]);
        }

        private void OnGUI()
        {
            foreach (var dict in _dictionary)
            {
                GUILayout.Label("key: "+ dict.Key + "value: "+ dict.Value);
            }
        }
    }
}