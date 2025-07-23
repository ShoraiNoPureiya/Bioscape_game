using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEditor.Localization;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private string profileId = "";

    [Header("Content")]
    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;
    [SerializeField] private TextMeshProUGUI lastLocationTMPUGUI;
    [SerializeField] private LocalizedString location_WordLocalizedString;
    [SerializeField] private TextMeshProUGUI lastPlayedTMPUGUI;
    [SerializeField] private LocalizedString lastPlayed_WordLocalizedString;
    private string location_WordValue;
    private LocalizedString currentSceneLocalizedString;
    private string currentSceneString;
    private string lastPlayedValue;


    [Header("Localized Strings for Scenes")]
    [SerializeField] private List<LocalizedString> _InGameSceneNames;

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
        }
        // there is data for this profileId
        else
        {
            hasData = true;
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);


            currentSceneLocalizedString = null;
            foreach (var ls in _InGameSceneNames)
            {
                var collection = LocalizationEditorSettings.GetStringTableCollection(ls.TableReference);
                var entry = collection.SharedData.GetEntryFromReference(ls.TableEntryReference);
                if (entry.Key == data._currentScene)
                {
                    currentSceneLocalizedString = ls;
                    currentSceneString = ls.GetLocalizedString();
                    break;
                }

            }
            if (currentSceneLocalizedString == null)
            {
                Debug.LogWarning($"No localized string found for scene: {data._currentScene}");
                currentSceneString = data._currentScene;
            }

            // Update the UI with the data
            location_WordValue = location_WordLocalizedString.GetLocalizedString();
            lastLocationTMPUGUI.text = location_WordValue + currentSceneString;

            long ticks = data.lastUpdated;
            DateTime dt = DateTime.FromBinary(ticks);
            // lastPlayedTMPUGUI.text = "LAST PLAYED: " + dt.ToLocalTime().ToString();
            lastPlayedValue = dt.ToLocalTime().ToString();

            lastPlayedTMPUGUI.text = lastPlayed_WordLocalizedString.GetLocalizedString() + lastPlayedValue;
            
        }
    }

    public string GetProfileId()
    {
        return this.profileId;
    }

    public void SetInteractable(bool interactable)
    {
        saveSlotButton.interactable = interactable;
    }

    private void OnEnable()
    {
        location_WordLocalizedString.StringChanged += OnWordLocationChanged;
        lastPlayed_WordLocalizedString.StringChanged += UpdateLastPlayed;
        if (currentSceneLocalizedString != null)
        {
            currentSceneLocalizedString.StringChanged += OnLastSceneChanged;
        }
    }

    private void OnDisable()
    {
        location_WordLocalizedString.StringChanged -= OnWordLocationChanged;
        lastPlayed_WordLocalizedString.StringChanged -= UpdateLastPlayed;
        if (currentSceneLocalizedString != null)
        {
            currentSceneLocalizedString.StringChanged -= OnLastSceneChanged;
        }
    }

    private void OnWordLocationChanged(string value)
    {
        location_WordValue = value;
        UpdateLocation();
    }
    private void OnLastSceneChanged(string value)
    {
        currentSceneString = value;
        UpdateLocation();
    }
    private void UpdateLocation()
    {
        lastLocationTMPUGUI.text = location_WordValue + currentSceneString;
    }



    private void UpdateLastPlayed(string value)
    {
        lastPlayedTMPUGUI.text = value + lastPlayedValue;
    }
    
}
