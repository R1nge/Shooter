using UnityEngine;

namespace _Assets.Scripts.Services.Gameplay.Weapons
{
    [CreateAssetMenu(fileName = "Weapon Stats", menuName = "Configs/Weapons/Weapon Stats")]
    public class WeaponStats : ScriptableObject
    {
        public float damage;
        public float reloadTime;
        public float fireRate;
        public int maxAmmo;
    }
}