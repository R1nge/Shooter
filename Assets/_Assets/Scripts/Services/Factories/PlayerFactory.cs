using _Assets.Scripts.Configs;
using Unity.Netcode;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
    public class PlayerFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;

        private PlayerFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }

        public NetworkObject Create(Vector3 position, ulong owner)
        {
            var player = _objectResolver.Instantiate(_configProvider.CharacterConfig.PlayerPrefab, position, Quaternion.identity);
            player.SpawnWithOwnership(owner);
            return player;
        }
    }
}