using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSequencer : MonoBehaviour
{

    public AudioSource _firstSound;
    public AudioSource _secondSound;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlaySoundsSequentially());
    }

    IEnumerator PlaySoundsSequentially()
    
    {

        _firstSound.Play();
        
        while (_firstSound.isPlaying)
        {
            yield return null;
            yield return new WaitForSeconds(4f);
        }
    
        _secondSound.Play();

       
    }

    
}
