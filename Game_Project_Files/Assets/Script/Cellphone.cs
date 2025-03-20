using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cellphone : MonoBehaviour
{
    public GameObject _Cell;
    public GameObject _ApksChild;
    // Start is called before the first frame update
    void Start()
    {
        _Cell.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (_Cell.activeSelf)
            {
                _Cell.SetActive(false);
            }
            else
            {
                _Cell.SetActive(true);
            }
        }

    }

    public void DisableAllChildren()
    {
        foreach (Transform child in _ApksChild.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}

