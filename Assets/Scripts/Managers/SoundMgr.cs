using UnityEngine;

public class SoundMgr : Singleton<SoundMgr>
{
    // Audio players components.
    public AudioSource SoundSource;
    public AudioSource MusicSource;

    // Random pitch adjustment range.
    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;

    //play sound
    public void PlaySound(AudioClip clip, bool isLoop = false,float startTime = 0, float endTime = 0)
    {
        SoundSource.clip = clip;
        SoundSource.loop = isLoop;
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
    public void PlayMusic(AudioClip clip, bool isLoop=false,float startTime = 0, float endTime = 0)
    {
        MusicSource.clip = clip;
        MusicSource.loop = isLoop;
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
