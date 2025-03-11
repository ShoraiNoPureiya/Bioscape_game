using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSequencer : MonoBehaviour
{

    public AudioSource _firstSound;
    private AudioSource _secondSound;
    // Start is called before the first frame update
    void Start()
    {
        _secondSound = GameObject.Find("Musics").GetComponent<AudioSource>();
        StartCoroutine(PlaySoundsSequentially());
    }

    IEnumerator PlaySoundsSequentially()
    
    {

        _firstSound.Play();
        
        while (_firstSound.isPlaying)
        {
            yield return null;
            yield return new WaitForSeconds(2f);
        }
    
        _secondSound.Play();

       
    }

    
}
