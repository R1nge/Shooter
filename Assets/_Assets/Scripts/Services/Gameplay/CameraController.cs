using Unity.Netcode;
using UnityEngine;

namespace _Assets.Scripts.Services.Gameplay
{
    public class CameraController : NetworkBehaviour
    {
        [SerializeField] private Camera playerCamera;

        public override void OnNetworkSpawn()
        {
            playerCamera.enabled = IsOwner;
            playerCamera.GetComponent<AudioListener>().enabled = IsOwner;
        }
    }
}