using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject _Map;
    public GameObject _Hud;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (_Map.activeSelf)
            {
                PlayerController.playercontroller.SetCanMove(true);
                _Hud.SetActive(true);
                _Map.SetActive(false);
            }
            else
            {
                PlayerController.playercontroller.SetCanMove(false);
                _Map.SetActive(true);
                _Hud.SetActive(false);
            }

        }
    }
}
