using Unity.Netcode.Components;

namespace _Assets.Scripts.Services.Multiplayer
{
    public class ClientNetworkTransform : NetworkTransform
    {
        protected override bool OnIsServerAuthoritative()
        {
            return false;
        }
    }
}