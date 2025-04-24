using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cellphone_CloudApp : MonoBehaviour
{
    public void TurnPurpleOnceClicked(TextMeshProUGUI _NewsItem){
        //PlayerPrefs.SetInt(_News.ToString() ,1);
        _NewsItem.color = new Color(0.8f, 0f, 1f, 1f); //Change color to purple
    }

    public void DisableAllChildren(GameObject _Parent)
    {
        foreach (Transform child in _Parent.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
