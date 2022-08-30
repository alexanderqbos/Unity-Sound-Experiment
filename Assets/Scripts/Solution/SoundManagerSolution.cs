using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;    // used for AudioMixer

// To use this SoundManager, drag/drop an instance of it in your scene.
// It persists throughout scenes and you can access it via a singleton reference.
// eg:
//   SoundManager.Instance.PlaySfx(audioClip);
//   SoundManager.Instance.PlayMusic(audioClip);
//   SoundManager.Instance.StopMusic();
//
//  Volume settings are controlled by a mixer which uses 2 sound groups (sfx & music)
//  Volume settings are automatically saved in PlayerPrefs OnDestroy() and restored in Awake()
//
// To copy and use this in another project, you will also need to copy the mixer that has
// been setup to work with this object. 
//
/*
public class SoundManager : MonoBehaviour
{
    // Create a single means of referencing the SoundManager (via a Property)
    // We will be able to use "SoundManager.Instance" to reference the object.
    static public SoundManager Instance { get; private set; } = null;

    [SerializeField] private AudioSource sfxSource;     // source for playing sfx
    [SerializeField] private AudioSource musicSource;   // source for playing music
    [SerializeField] AudioMixer mixer;  // mixer for controlling sfx & music volume

    private float sfxVolume = 1.0f;         // for tracking sfx volume
    private float musicVolume = 1.0f;       // for tracking music volume

    const string PP_MUSIC_VOL = "MusicVol";     // PlayerPrefs key for saving music volume
    const string PP_SFX_VOL = "SfxVol";         // PlayerPrefs key for saving sound volume


    // convert from linear to logarithmic scale (0.0-1.0 to decibels)
    private float LinearToLog(float value)
    {
        return Mathf.Log10(value) * 20;
    }

    // a property to get/set sfx volume
    public float SfxVolume
    {
        get { return sfxVolume; }
        set
        {
            sfxVolume = Mathf.Clamp(value, 0.0f, 1.0f); // limit vol range
            mixer.SetFloat("SfxVolume", LinearToLog(sfxVolume));     // set mixer sfx vol
        }
    }

    // a property to get/set music volume
    public float MusicVolume
    {
        get { return musicVolume; }
        set
        {
            musicVolume = Mathf.Clamp(value, 0.0f, 1.0f); // limit vol range
            mixer.SetFloat("MusicVolume", LinearToLog(musicVolume));   // set mixer music vol
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {  // if Awake has never been called before
            Instance = this;                // remember this as our (one & only) SM.
            DontDestroyOnLoad(gameObject);  // don't destroy the object
            Init();                         // initialize the SM
        }
        else
        {                    // else we already have a SM that exists.        
            Destroy(gameObject);  // destroy the one that was about to be built.
        }
    }

    private void Init()
    {
        // Restore volume slider values [0...1] from PlayerPrefs
        MusicVolume = PlayerPrefs.GetFloat(PP_MUSIC_VOL, 1f);   // if not found, use 1
        SfxVolume = PlayerPrefs.GetFloat(PP_SFX_VOL, 1f);       // if not found, use 1
    }

    private void OnDestroy()
    {
        // Save volume slider values [0...1] to PlayerPrefs
        PlayerPrefs.SetFloat(PP_MUSIC_VOL, musicVolume);    // save
        PlayerPrefs.SetFloat(PP_SFX_VOL, sfxVolume);        // save
    }

    // Play a sfx clip (fire & forget)
    public void PlaySfx(AudioClip clip, float volume = 1.0f)
    {
        sfxSource.PlayOneShot(clip, volume);
    }

    // Play a music clip (capable of being stopped)
    public void PlayMusic(AudioClip clip, float volume = 1.0f)
    {
        musicSource.clip = clip;
        musicSource.volume = volume;
        musicSource.Play();
    }

    // Stop the music!
    public void StopMusic()
    {
        musicSource.Stop();
    }
}
*/