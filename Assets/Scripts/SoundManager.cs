using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource muiscSource;

    [SerializeField] private AudioMixer mixer;

    static public SoundManager Instance { get; private set; } =  null;

    private float sfxVolume = 1.0f;
    private float musicVolume = 1.0f;

    const string PP_MUSIC_VOL = "MUSICVOLUME";
    const string PP_SFX_VOL = "SFXVOLUME";

    private float LinearToLog(float value)
    {
        return Mathf.Log10(value);
    }

    public float SfxVolume {
        get {return sfxVolume;}
        set {
            sfxVolume = Mathf.Clamp(value, 0.0f, 1.0f);
            mixer.SetFloat("SfxVolume", LinearToLog(sfxVolume));
        }
    }

    public float MusicVolume {
        get {return musicVolume;}
        set {
            musicVolume = Mathf.Clamp(value, 0.0f, 1.0f);
            mixer.SetFloat("MusicVolume", LinearToLog(musicVolume));
        }
    }

    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            Init();
        }
        else {
            Destroy(gameObject);
        }
    }

    public void PlaySfx(AudioClip clip, float volume = 1.0f)
    {
        sfxSource.PlayOneShot(clip, volume);
    }

    public void PlayMusic(AudioClip clip, float volume = 1.0f)
    {
        muiscSource.clip = clip;
        muiscSource.volume = volume;
        muiscSource.Play();
    }

    public void StopMusic()
    {
        muiscSource.Stop();
    }

    private void Init()
    {
        MusicVolume = PlayerPrefs.GetFloat(PP_MUSIC_VOL, 1.0f);
        SfxVolume = PlayerPrefs.GetFloat(PP_SFX_VOL, 1.0f);
    }

    private void OnDestroy() {
        PlayerPrefs.SetFloat(PP_MUSIC_VOL, MusicVolume);
        PlayerPrefs.SetFloat(PP_SFX_VOL, SfxVolume);
    }
}
