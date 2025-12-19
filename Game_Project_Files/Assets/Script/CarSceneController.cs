using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSceneController : MonoBehaviour
{
    public GameObject _House;
    public GameObject _Farm;
    public GameObject _Aquifer;
    public GameObject _Committe;
    // Start is called before the first frame update
    void Start()
    {
        _House.SetActive(true);
        if (GetKey._Key)
        {
            _Farm.SetActive(true);
        }
        if (DataPersistenceManager.instance.Task1Result)
        {
            _Aquifer.SetActive(true);
        }
        if (TalkedToMilton._I)
        {
            _Committe.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
