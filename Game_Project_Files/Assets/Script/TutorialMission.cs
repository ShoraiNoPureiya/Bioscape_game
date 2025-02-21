using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMission : MonoBehaviour
{
    public static TutorialMission tutorialmission;
    Transform _Child; // Unique identifier for each object
    public Text _Text;


    private void Update()
    {
        _Text.text = PlayerPrefs.GetString("text"); ; // sets the text stored in PlayerPrefs
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
    public void ChangeText(string i) // function used to change the text
    {
        PlayerPrefs.SetString("text", i);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("MissionCompleted", 1);
        PlayerPrefs.SetString("text", "Verifique se a chave está na estante do laboratório");
    }

}
