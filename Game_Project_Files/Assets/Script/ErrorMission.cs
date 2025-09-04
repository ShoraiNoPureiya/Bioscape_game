using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorMission : MonoBehaviour
{
    public GameObject _DialogBox;
    public bool _HasRunned;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_HasRunned)
        {
            _DialogBox.SetActive(true);
            _HasRunned = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _HasRunned = false;
    }

}
