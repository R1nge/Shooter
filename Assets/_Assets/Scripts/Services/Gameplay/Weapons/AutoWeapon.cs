using UnityEngine;

namespace _Assets.Scripts.Services.Gameplay.Weapons
{
    public class AutoWeapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private WeaponStats weaponStats;
        
        public void Attack()
        {
        }

        public void Reload()
        {
        }
    }
}