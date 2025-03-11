using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public AudioSource _backButton;
    
    void Start()
    {
        Button button = GetComponent<Button>();

        button.onClick.AddListener(PlaySound);
    }


    void PlaySound()
    {
       _backButton.Play();
    }
}
