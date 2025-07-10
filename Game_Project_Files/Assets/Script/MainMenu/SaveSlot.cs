using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Localization;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private string profileId = "";

    [Header("Content")]
    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;
    [SerializeField] private TextMeshProUGUI percentageCompleteText;
    [SerializeField] private TextMeshProUGUI deathCountText;


    [Header("Localized Strings for Scenes")]
    [SerializeField] private LocalizedString _SampleSceneName;
    [SerializeField] private LocalizedString _HallwayName;

    // [Header("Clear Data Button")]
    // [SerializeField] private Button clearButton;

    public bool hasData { get; private set; } = false;

    private Button saveSlotButton;

    private void Awake()
    {
        saveSlotButton = this.GetComponent<Button>();
    }

    public void SetData(GameData data)
    {
        // there's no data for this profileId
        if (data == null)
        {
            hasData = false;
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
            // clearButton.gameObject.SetActive(false);
        }
        // there is data for this profileId
        else
        {
            hasData = true;
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);
            // clearButton.gameObject.SetActive(true);

            // percentageCompleteText.text = data.GetPercentageComplete() + "% COMPLETE";
            percentageCompleteText.text = "Location: " + data._currentScene;

            long ticks = data.lastUpdated;
            DateTime dt = DateTime.FromBinary(ticks);
            deathCountText.text = "LAST PLAYED: " + dt.ToLocalTime().ToString();
        }
    }

    public string GetProfileId()
    {
        return this.profileId;
    }

    public void SetInteractable(bool interactable)
    {
        saveSlotButton.interactable = interactable;
        // clearButton.interactable = interactable;
    }
    
}
