using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargerArea : MonoBehaviour
{
    public RectTransform targetArea;
    public RectTransform bar;

    public float speed = 100f;
    public float changeTimeMin = 0.5f;
    public float changeTimeMax = 1.5f;

    float direction;
    float timer;
    float minX;
    float maxX;

    void Start()
    {
        float barWidth = bar.rect.width;
        float areaWidth = targetArea.rect.width;

        minX = -barWidth / 2 + areaWidth / 2;
        maxX = barWidth / 2 - areaWidth / 2;

        PickNewDirection();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
            PickNewDirection();

        targetArea.anchoredPosition += Vector2.right * direction * speed * Time.deltaTime;

        float x = Mathf.Clamp(targetArea.anchoredPosition.x, minX, maxX);
        targetArea.anchoredPosition = new Vector2(x, targetArea.anchoredPosition.y);
    }

    void PickNewDirection()
    {
        direction = Random.value < 0.5f ? -1f : 1f;
        timer = Random.Range(changeTimeMin, changeTimeMax);
    }
}
