using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class SettingsController : MonoBehaviour
    {
        public Slider musicSlider;
        public Slider effectsSlider;

        private SettingsManager _settingsManager;

        private void Start()
        {
            _settingsManager = SettingsManager.Instance;
            
            musicSlider.value = _settingsManager.musicVolume;
            effectsSlider.value = _settingsManager.effectsVolume;
            
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
            effectsSlider.onValueChanged.AddListener(SetEffectsVolume);
        }

        private void SetMusicVolume(float value)
        {
            _settingsManager.SetMusicVolume(value);
        }

        private void SetEffectsVolume(float value)
        {
            _settingsManager.SetEffectsVolume(value);
        }
    }
}