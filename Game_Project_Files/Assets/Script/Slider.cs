using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [Header("UI")]
    public RectTransform cursor;
    public RectTransform targetArea;
    public Slider progressSlider;
    public GameObject _Win;

    [Header("Configurações")]
    public float cursorSpeed = 300f;
    public float progressUpSpeed = 0.4f;
    public float progressDownSpeed = 0.6f;

    private float direction = 1f;
    private float minX;
    private float maxX;

    void Start()
    {
        minX = -75.1f;
        maxX = 73.6f;

        progressSlider.value = 0.5f;
    }

    void Update()
    {
        HandleInput();
        MoveCursor();
        UpdateProgress();
    }
    void HandleInput()
    {
        if (Input.GetMouseButton(0)) // botão esquerdo pressionado
            direction = 1f;          // direita
        else
            direction = -1f;         // esquerda
    }

    void MoveCursor()
    {
        cursor.anchoredPosition += Vector2.right * direction * cursorSpeed * Time.deltaTime;

        // Limites da barra
        float x = cursor.anchoredPosition.x;
        x = Mathf.Clamp(x, minX, maxX);

        cursor.anchoredPosition = new Vector2(x, cursor.anchoredPosition.y);
    }

    void UpdateProgress()
    {
        if (IsCursorInsideTarget())
            progressSlider.value += progressUpSpeed * Time.deltaTime;
        else
            progressSlider.value -= progressDownSpeed * Time.deltaTime;

        progressSlider.value = Mathf.Clamp01(progressSlider.value);

        if (progressSlider.value >= 1f)
        {
            _Win.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    bool IsCursorInsideTarget()
    {
        float cursorX = cursor.position.x;
        float targetMin = targetArea.position.x - targetArea.rect.width / 2;
        float targetMax = targetArea.position.x + targetArea.rect.width / 2;

        return cursorX >= targetMin && cursorX <= targetMax;
    }
}
