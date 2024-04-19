using _Assets.Scripts.Services.Gameplay.Weapons;
using Unity.Netcode;
using UnityEngine;

namespace _Assets.Scripts.Services.Gameplay
{
    public class WeaponController : NetworkBehaviour
    {
        [SerializeField, SerializeReference] private IWeapon weapon;
        
        public void SetWeapon(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public void Shoot()
        {
            weapon?.Attack();
        }

        public void Reload()
        {
            weapon?.Reload();
        }

        private void Update()
        {
            if (!IsOwner) return;

            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }
    }
}