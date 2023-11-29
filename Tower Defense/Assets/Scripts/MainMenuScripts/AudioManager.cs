using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private float masterVolume = 1.0f;
    private float soundEffectsVolume = 1.0f;

    private void Awake()
    {
        // Ensure only one instance of AudioManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to set master volume
    public void SetMasterVolume(float volume)
    {
        masterVolume = Mathf.Clamp01(volume);
        ApplyVolumes(); // Apply the updated volumes to all audio sources
    }

    // Method to set sound effects volume
    public void SetSoundEffectsVolume(float volume)
    {
        soundEffectsVolume = Mathf.Clamp01(volume);
        ApplyVolumes(); // Apply the updated volumes to all audio sources
    }

    // Apply the volumes to all audio sources in the scene
    private void ApplyVolumes()
    {
        // Iterate through all audio sources and set their volumes accordingly
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
            if (source.CompareTag("MasterVolume"))
            {
                source.volume = masterVolume;
            }
            else if (source.CompareTag("SoundEffectsVolume"))
            {
                source.volume = soundEffectsVolume;
            }
        }
    }
}
