using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class TutorialMission : MonoBehaviour
{
    public static TutorialMission tutorialmission;
    Transform _Child; // Unique identifier for each object
    public Text _Text;
    public string _Texts;
    public LocalizedString localizedStringDef;
    public LocalizedString localizedStringBath;
    public LocalizedString localizedStringKitchen;
    public LocalizedString localizedStringGarden;


    private void Update()
    {
        switch (PlayerPrefs.GetInt("Order"))
        {
            case 1:
                localizedStringDef.GetLocalizedStringAsync().Completed += handle =>
                {
                    _Text.text = handle.Result;
                };
                break;
            case 2:
                localizedStringBath.GetLocalizedStringAsync().Completed += handle =>
                {
                    _Text.text = handle.Result;
                };
                break;
            case 3:
                localizedStringKitchen.GetLocalizedStringAsync().Completed += handle =>
                {
                    _Text.text = handle.Result;
                };
                break;
            case 4:
                localizedStringGarden.GetLocalizedStringAsync().Completed += handle =>
                {
                    _Text.text = handle.Result;
                };
                break;
            default:
                PlayerPrefs.SetInt("Order", 1);
                break;
        }
        if (PlayerPrefs.GetInt("MissionCompleted") == 1)
        {
            _Child.gameObject.SetActive(false);
        }
        else { _Child.gameObject.SetActive(true); }
    }
    private void Start()
    {
            _Child = transform.GetChild(0);

        tutorialmission = this;
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("MissionCompleted", 1);
    }

}
