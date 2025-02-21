using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeControl : MonoBehaviour
{
    [SerializeField] private Image _NewImage;
    [SerializeField] private Image _NewImage2;

    [SerializeField] private Sprite _Image;
    [SerializeField] private Sprite _Image2;
    [SerializeField] private Sprite _Image3;
    [SerializeField] private Sprite _Image4;

    [SerializeField] private AudioSource _music;
    [SerializeField] private float _Volume;
    [SerializeField] private float _Volume2;
    [SerializeField] private Text _textMusic;
    [SerializeField] private Text textAmbient;



    public void musicVolume(float value)
    {

        _music.volume = value;
        _Volume2 = value;

    }
    public void ambientVolume(float value)
    {

        _music.volume = value;
        _Volume = value;

    }

    void Update()
    {
        _textMusic.text = (_music.volume*100).ToString();
        textAmbient.text = (_music.volume * 100).ToString();
        if (_Volume == 0)
        {
            _NewImage.sprite = _Image;
        }
        if (_Volume > 0)
        {
            _NewImage.sprite = _Image2;
        }
        if (_Volume > 0.33)
        {
            _NewImage.sprite = _Image3;
        }
        if (_Volume > 0.66)
        {
            _NewImage.sprite = _Image4;
        }


    // /////////////////////////////////////////////////////////////////
        if (_Volume2 == 0)
        {
            _NewImage2.sprite = _Image;
        }
        if (_Volume2 > 0)
        {
            _NewImage2.sprite = _Image2;
        }
        if (_Volume2 > 0.33)
        {
            _NewImage2.sprite = _Image3;
        }
        if (_Volume2 > 0.66)
        {
            _NewImage2.sprite = _Image4;
        }
    }

}
