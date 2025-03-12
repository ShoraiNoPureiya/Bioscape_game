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
    private bool _CutscenePlayed = false;


    public void Start()
    {
        _TransitionScreen.SetActive(false);
    }


    public void Update()
    {
        string CurrentSceneName = SceneManager.GetActiveScene().name; //Get the name of the current scene

        if (CurrentSceneName == _SceneName && !_CutscenePlayed)
        {
            StartCoroutine(TransitionMission(8));
            _CutscenePlayed = true;

        }
    }


    

    IEnumerator TransitionMission (int levelindex)
    {
        _TransitionScreen.SetActive(true);

        _Transition.SetTrigger("Start");

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(levelindex);

        _TransitionScreen.SetActive(false);

        StopCoroutine(TransitionMission(8));

    }
}
