using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _;
    [Header("-------- Audio Sourc -------")]
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("-------- Audio Clip -------")]
    public AudioClip music;
    public AudioClip ButtonClick; 
    
    public enum audioType { Main, Music, Sfx}
    private void Start()
    {
        musicSource.clip = music;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
