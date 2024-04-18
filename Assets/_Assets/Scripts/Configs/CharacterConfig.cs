using Unity.Netcode;
using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "Character Config", menuName = "Configs/Character Config")]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private NetworkObject playerPrefab;
        public NetworkObject PlayerPrefab => playerPrefab;
    }
}