using _Assets.Scripts.Ecs.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using Unity.Netcode;

namespace _Assets.Scripts.Ecs.Providers
{
    public class NetworkObjectProvider : MonoProvider<NetworkComponent>
    {
        private void Start()
        {
           Entity.GetComponent<NetworkComponent>().netId = NetworkManager.Singleton.LocalClientId; 
        }
    }
}