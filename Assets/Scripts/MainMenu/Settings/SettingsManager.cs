using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Settings
{
    public class SettingsManager : MonoBehaviour
    {
        [Range(0f, 1f)] public float musicVolume = 1f;
        [Range(0f, 1f)] public float effectsVolume = 1f;

        public static SettingsManager Instance { get; private set; }

        public List<AudioSource> audioEffects = new List<AudioSource>();
        public AudioSource audioMusic;

        private void Start()
        {
            CollectAllAudioSources();
        }
        
        private void CollectAllAudioSources()
        {
            var audioSourcesArray = FindObjectsOfType<AudioSource>();
            audioEffects.AddRange(audioSourcesArray);
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            LoadSettings();
        }

        public void SetMusicVolume(float volume)
        {
            musicVolume = volume;
            UpdateMusicVolume();
            SaveSettings();
        }

        public void SetEffectsVolume(float volume)
        {
            effectsVolume = volume;
            UpdateEffectsVolume();
            SaveSettings();
        }

        private void UpdateMusicVolume()
        {
            audioMusic.volume = musicVolume;
        }

        private void UpdateEffectsVolume()
        {
            foreach (var source in audioEffects)
            {
                source.volume = effectsVolume;
            }
        }

        private void SaveSettings()
        {
            PlayerPrefs.SetFloat("MusicVolume", musicVolume);
            PlayerPrefs.SetFloat("EffectsVolume", effectsVolume);
            PlayerPrefs.Save();
        }

        private void LoadSettings()
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
            effectsVolume = PlayerPrefs.GetFloat("EffectsVolume", 1f);
            UpdateMusicVolume();
        }
        
    }
}