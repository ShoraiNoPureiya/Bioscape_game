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
    

    public void Start()
    {
        _TransitionScreen.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
