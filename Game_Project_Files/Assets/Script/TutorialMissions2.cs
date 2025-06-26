using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class TutorialMissions2 : MonoBehaviour
{
    public string _Text; // texto que vai ser usado
    private string _ChangedText; // texto que esta agora
    private string _IfText; // texto que esta agora
    public string _Texts;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
            if (PlayerPrefs.GetString("textIf") == "") // // if there's no text, uses the one in the scene
            {
                PlayerPrefs.SetString("textIf", _Text);
                DataPersistenceManager.instance.CurrentOrder = 1;
            }

            if (PlayerPrefs.GetString("textIf").Equals("Verifique se a chave est� na estante do laborat�rio") && _Text.Equals("Verifique se a chave est� no banheiro")) // if the player interacts with the CORRECT object, changes the text
            {
                PlayerPrefs.SetString("textIf", "Verifique se a chave est� no banheiro");
                DataPersistenceManager.instance.CurrentOrder = 2;
            }
            if (PlayerPrefs.GetString("textIf").Equals("Verifique se a chave est� no banheiro") && _Text.Equals("Verifique se a chave est� na sala/cozinha (dentro do di�rio)")) // if the player interacts with the CORRECT object, changes the text
            {
                PlayerPrefs.SetString("textIf", "Verifique se a chave est� na sala/cozinha (dentro do di�rio)");
                DataPersistenceManager.instance.CurrentOrder = 3;
            }
            if (PlayerPrefs.GetString("textIf").Equals("Verifique se a chave est� na sala/cozinha (dentro do di�rio)") && _Text.Equals("Verifique da onde veio esse som.")) // if the player interacts with the CORRECT object, changes the text
            {
                PlayerPrefs.SetString("textIf", "Verifique da onde veio esse som.");
                PlayerPrefs.SetInt("tutorialmission", 1);
                DataPersistenceManager.instance.CurrentOrder = 4;
            }
        
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("tutorialmission", 0);
        PlayerPrefs.SetString("text", null);
    }
}