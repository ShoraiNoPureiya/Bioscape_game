using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiltinhoSecondMission : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _M1;
    public GameObject _M2;
    void Start()
    {
        if (SecondMissionDialog._I == 3)
        {
            _M1.SetActive(false);
            _M2.SetActive(true);
        }
        else
        {
            _M1.SetActive(true);
            _M2.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
