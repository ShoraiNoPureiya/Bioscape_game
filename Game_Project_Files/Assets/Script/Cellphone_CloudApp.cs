using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cellphone_CloudApp : MonoBehaviour
{
    public void TurnPurpleOnceClicked(GameObject _News){
        //PlayerPrefs.SetInt(_News.ToString() ,1);
        print(_News.ToString());
    }

    public void DisableAllChildren(GameObject _Parent)
    {
        foreach (Transform child in _Parent.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
