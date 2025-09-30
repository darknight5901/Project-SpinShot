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
    private void Awake()
    {
        if (_ == null)
        {
            _ = this;
        }
    }
    public enum audioType { Main, Music, Sfx}
    private void Start()
    {
       PlayMusic(music, false, transform , 1f);
    }
    public void PlaySFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn game object
        AudioSource audioSource = Instantiate(SFXSource, spawnTransform.position, Quaternion.identity);
        //assign the audioClip
        audioSource.clip = audioClip;   
        

        //assign volume
        audioSource.volume = volume;
        // play sound
        audioSource.Play();
        //get length of clip
        float clipLength = audioSource.clip.length;
        // destroy object after done playing
        Destroy(audioSource, clipLength);
        print(audioSource + " should be destoryed " + clipLength);
    }
    public void PlayRandomSFXClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        int rand = Random.Range(0, audioClip.Length);
        //spawn game object
        AudioSource audioSource = Instantiate(SFXSource, spawnTransform.position, Quaternion.identity);
        //assign the audioClip
        audioSource.clip = audioClip[rand];   
        

        //assign volume
        audioSource.volume = volume;
        // play sound
        audioSource.Play();
        //get length of clip
        float clipLength = audioSource.clip.length;
        // destroy object after done playing
        Destroy (audioSource, clipLength);
        print(audioSource.name + " should be destoryed " + clipLength);
    }

    public void PlayMusic(AudioClip audioClip,bool looping, Transform spawnTransform, float volume)
    {
        //spawn game object
        AudioSource audioSource = Instantiate(musicSource, spawnTransform.position, Quaternion.identity);
        //assign the audioClip
        audioSource.clip = audioClip;


        //assign volume
        audioSource.volume = volume;
        // play sound
        audioSource.Play();
        //get length of clip
        float clipLength = audioSource.clip.length;
        // destroy object after done playing
        if (!looping)
        {
            Destroy(audioSource, clipLength);
            print(audioSource + " should be destoryed" + clipLength);
        }
        print(audioSource + "is looping");

    }
}
