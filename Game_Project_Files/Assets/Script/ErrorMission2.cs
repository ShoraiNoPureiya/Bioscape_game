using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorMission2 : MonoBehaviour
{
    public GameObject _Door;
    public GameObject _Dialog;
    // Start is called before the first frame update
    void Start()
    {
        if (DialogSequence._I)
        {
            _Door.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_Door.activeSelf)
        {
            _Dialog.SetActive(true);
        }
    }
}
