using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------AudioSource------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("------AudioClip------")]
    public AudioClip background;
    public AudioClip bigJump;
    public AudioClip smallJump;
    public AudioClip powerUp;
    public AudioClip powerUp_Appears;
    public AudioClip coin;
    public AudioClip kick;
    public AudioClip stomp;
    public AudioClip pipe;
    public AudioClip flagPoge;
    public AudioClip stageClear;
    public AudioClip death;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }


    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

   
    public void StopBackgroundMusic()
    {
        musicSource.Stop();
    }
}
