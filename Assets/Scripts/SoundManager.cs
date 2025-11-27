using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class NamedAudioClip
{
    public string key;        // e.g. "JUMP", "HURT", "COIN"
    public AudioClip clip;    // assign in Inspector
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private AudioSource audioSource;

    // Assignable list in Inspector
    public List<NamedAudioClip> audioClips;

    // Internal lookup
    private Dictionary<string, AudioClip> clipMap;

    private void Awake()
    {
        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();

        // Build dictionary from Inspector list
        clipMap = new Dictionary<string, AudioClip>();
        foreach (var entry in audioClips)
        {
            if (!clipMap.ContainsKey(entry.key))
            {
                clipMap.Add(entry.key, entry.clip);
            }
        }
    }

    public void PlaySFX(string key, float volume = 1f)
    {
        if (clipMap.ContainsKey(key) && clipMap[key] != null)
        {
            audioSource.PlayOneShot(clipMap[key], volume);
        }
        else
        {
            Debug.LogWarning($"SoundManager: No clip mapped for key '{key}'");
        }
    }
}
