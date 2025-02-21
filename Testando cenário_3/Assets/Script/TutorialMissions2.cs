using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMissions2 : MonoBehaviour
{
    public string _Text; // texto que vai ser usado
    private string _ChangedText; // texto que esta agora
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        _ChangedText = PlayerPrefs.GetString("text"); // retrieves the text stored in PlayerPrefs
        if (_ChangedText == null) // // if there's no text, uses the one in the scene
        {
            PlayerPrefs.SetString("text", _Text);
            Changetext();
            PlayerPrefs.SetInt("Order", 1);
        }

        if (_ChangedText.Equals("Verifique se a chave está na estante do laboratório") && _Text.Equals("Verifique se a chave está no banheiro")) // if the player interacts with the CORRECT object, changes the text
        {
            PlayerPrefs.SetString("text", _Text);
            Changetext();
            PlayerPrefs.SetInt("Order",2);
        }
        if (_ChangedText.Equals("Verifique se a chave está no banheiro") && _Text.Equals("Verifique se a chave está na sala/cozinha (dentro do diário)")) // if the player interacts with the CORRECT object, changes the text
        {
            PlayerPrefs.SetString("text", _Text);
            Changetext();
            PlayerPrefs.SetInt("Order", 3);
        }
        if (_ChangedText.Equals("Verifique se a chave está na sala/cozinha (dentro do diário)") && _Text.Equals("Verifique da onde veio esse som.")) // if the player interacts with the CORRECT object, changes the text
        {
            PlayerPrefs.SetString("text", _Text);
            PlayerPrefs.SetInt("tutorialmission", 1);
            Changetext();
            PlayerPrefs.SetInt("Order", 4);
        }

    }
    void Changetext()
    {

        TutorialMission.tutorialmission.ChangeText(_Text); // used to change the text to "_Text"
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("tutorialmission", 0);
        PlayerPrefs.SetString("text", null);
    }
}