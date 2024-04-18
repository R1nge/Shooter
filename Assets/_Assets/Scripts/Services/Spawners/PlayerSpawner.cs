using _Assets.Scripts.Services.Factories;
using Unity.Netcode;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.Spawners
{
    public class PlayerSpawner : NetworkBehaviour
    {
        [SerializeField] private Transform spawnPosition;
        [Inject] private PlayerFactory _playerFactory;

        private void Awake()
        {
            NetworkManager.Singleton.OnClientConnectedCallback += Spawn;
        }

        private void Spawn(ulong ownerId)
        {
            if (!NetworkManager.Singleton.IsServer) return;
            _playerFactory.Create(spawnPosition.position, ownerId);
        }

        public override void OnDestroy()
        {
            if (!NetworkManager.Singleton) return;
            NetworkManager.Singleton.OnClientConnectedCallback -= Spawn;
            base.OnDestroy();
        }
    }
}