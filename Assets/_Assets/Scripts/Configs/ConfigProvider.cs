using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;
        [SerializeField] private CharacterConfig characterConfig;
        public UIConfig UIConfig => uiConfig;
        public CharacterConfig CharacterConfig => characterConfig;
    }
}