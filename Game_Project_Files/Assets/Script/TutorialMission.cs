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
        if (DataPersistenceManager.instance != null)
        {
            switch (DataPersistenceManager.instance.CurrentOrder)
            {
                case 1:
                    localizedStringDef.GetLocalizedStringAsync().Completed += handle =>
                    {
                        if (_Text != null)
                            _Text.text = handle.Result;
                    };
                    break;
                case 2:
                    localizedStringBath.GetLocalizedStringAsync().Completed += handle =>
                    {
                        if (_Text != null)
                            _Text.text = handle.Result;
                    };
                    break;
                case 3:
                    localizedStringKitchen.GetLocalizedStringAsync().Completed += handle =>
                    {
                        if (_Text != null)
                            _Text.text = handle.Result;
                    };
                    break;
                case 4:
                    localizedStringGarden.GetLocalizedStringAsync().Completed += handle =>
                    {
                        if (_Text != null)
                            _Text.text = handle.Result;
                    };
                    break;
                default:
                    break;
            }
            if (DataPersistenceManager.instance.MissionCompleted == 1)
            {
                _Child.gameObject.SetActive(false);
            }
            else { _Child.gameObject.SetActive(true); }
        }

    }
    private void Start()
    {
            _Child = transform.GetChild(0);

        tutorialmission = this;
    }
    private void OnApplicationQuit()
    {
        DataPersistenceManager.instance.MissionCompleted = 1;
    }

}
