using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Audio players components.
    public AudioSource SoundSource;
    public AudioSource MusicSource;

    // Random pitch adjustment range.
    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;

    // Singleton instance.
    public static SoundManager Instance = null;

    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
            Instance = this;
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        if (Instance != this)
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    //play sound
    public void PlaySound(AudioClip clip, float startTime = 0, float endTime = 0)
    {
        SoundSource.clip = clip;
        if (endTime != 0)
        {
            SoundSource.time = startTime;
            SoundSource.Play();
            SoundSource.SetScheduledEndTime(AudioSettings.dspTime + (endTime - startTime));
        }
        else
            SoundSource.Play();
    }

    //play sound
    public void PlayMusic(AudioClip clip, float startTime = 0, float endTime = 0)
    {
        MusicSource.clip = clip;
        if (endTime != 0)
        {
            MusicSource.time = startTime;
            MusicSource.Play();
            MusicSource.SetScheduledEndTime(AudioSettings.dspTime + (endTime - startTime));
        }
        else
            MusicSource.Play();
    }

    // Play a random clip from an array, and randomize the pitch slightly.
    public void RandomSoundEffect(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

        MusicSource.pitch = randomPitch;
        MusicSource.clip = clips[randomIndex];
        MusicSource.Play();
    }
}
