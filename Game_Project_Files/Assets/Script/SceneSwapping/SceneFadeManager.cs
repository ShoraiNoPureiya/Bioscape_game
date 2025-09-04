using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFadeManager : MonoBehaviour
{
    public static SceneFadeManager instance;
    [SerializeField] private Image _fadeImage; // Assuming you have a UI Image for fading
    [SerializeField] private Color _fadeColor = Color.black; // Default fade color
    [SerializeField] [Range(0f,10f)] private float _fadeOutSpeed = 3f;
    [SerializeField] [Range(0f,10f)] private float _fadeInSpeed = 3f;
    public bool _isFadingOut { get; private set; } = false;
    public bool _isFadingIn { get; private set; } = false;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        _fadeImage.color = _fadeColor;
    }

    private void Update()
    {
        if (_isFadingOut)
        {
            if (_fadeImage.color.a < 1f)
            {
                _fadeColor.a += Time.deltaTime * _fadeOutSpeed;
                _fadeImage.color = _fadeColor;
            }
            else
            {
                _isFadingOut = false;
            }
        }
        else if (_isFadingIn)
        {
            if (_fadeImage.color.a > 0f)
            {
                _fadeColor.a -= Time.deltaTime * _fadeInSpeed;
                _fadeImage.color = _fadeColor;
            }
            else
            {
                _isFadingIn = false;
            }
        }
    }

    public void StartFadeOut()
    {
        _fadeColor.a = 0f;
        _isFadingOut = true;
    }

    public void StartFadeIn()
    {
        _fadeColor.a = 1f;
        _isFadingIn = true;
    }
}
