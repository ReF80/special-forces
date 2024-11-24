using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _effectsSource;

    public AudioSource MusicSource => _musicSource;
    public AudioSource EffectsSource => _effectsSource;

    public static Controller Instance;
    private void Awake()
    {
        Instance = this;
    }
}
