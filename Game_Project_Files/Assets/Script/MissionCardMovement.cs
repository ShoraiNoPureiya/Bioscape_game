using UnityEngine;

public class MissionCardToggle : MonoBehaviour
{
    public RectTransform missionCard; 
    public Vector2 offScreenPosition; 
    public Vector2 centerScreenPosition; 
    public float animationTime = 0.5f; 

    private bool isVisible = false;

    void Start()
    {
       
        missionCard.anchoredPosition = offScreenPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMissionCard();
        }
    }

    void ToggleMissionCard()
    {
        if (isVisible)
        {
            LeanTween.move(missionCard, offScreenPosition, animationTime).setEase(LeanTweenType.easeInOutQuad);
        }
        else
        {
            LeanTween.move(missionCard, centerScreenPosition, animationTime).setEase(LeanTweenType.easeInOutQuad);
        }

        isVisible = !isVisible;
    }
}
