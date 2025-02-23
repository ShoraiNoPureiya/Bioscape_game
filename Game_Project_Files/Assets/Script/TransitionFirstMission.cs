using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;


public class TransitionFirstMission : MonoBehaviour
{

    public Animator _Transition;
    public GameObject _TransitionScreen;
    public String _SceneName = "Outside"; //Verify if the character is in a specific scene
    

    public void Start()
    {
        _TransitionScreen.SetActive(false);
    }


    public void Update()
    {
        string CurrentSceneName = SceneManager.GetActiveScene().name; //Get the name of the current scene

        if (CurrentSceneName == _SceneName )
        {
            LoadTransitionScreen();
        }
    }


    public void LoadTransitionScreen()
    {
        StartCoroutine(TransitionMission(8));
    }

    IEnumerator TransitionMission (int levelindex)
    {
        _TransitionScreen.SetActive(true);

        _Transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelindex);
    }
}
