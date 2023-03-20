using System.Collections.Generic;
using UnityEngine;

namespace Tower.Assets._Scripts._Enemy
{
    [CreateAssetMenu(fileName = "CharactersViewModel", menuName = "SO/Characters/CharactersViewModel", order = 1)]
    public class CharactersViewModel : ScriptableObject
    {
        public Transform Player { get; set; }

        public List<Transform> Enemies { get; set; } = new List<Transform>();
    }
}


