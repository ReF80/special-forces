using UnityEngine;
using UnityEngine.UI;
public class SettingsWindow : MonoBehaviour
{
    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private Slider _sliderEffects;

    private void Awake()
    {
        _sliderMusic.value = Controller.Instance.MusicSource.volume;
        _sliderEffects.value = Controller.Instance.MusicSource.volume;
    }

    public void ChangeValueMusic(float value)
    {
        Controller.Instance.MusicSource.volume = value;
    }

    public void ChangeValueEffects(float value)
    {
        Controller.Instance.EffectsSource.volume = value;
    }
}
