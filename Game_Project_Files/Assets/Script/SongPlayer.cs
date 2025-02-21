using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour
{
    public static SongPlayer songplayer;
    public AudioClip _Clip; // keeps the sound
    [SerializeField ]public AudioSource _AudioSource; 
    public AudioClip _Walk;
    // Start is called before the first frame update
    void Start()
    {
       songplayer = this;
        _AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playsongs(AudioClip Clip) //this "clip" keeps the audio what you wanna play
    {
        _AudioSource.PlayOneShot(Clip); // plays the audio a once
    }
}
