using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMissionInteracts : MonoBehaviour, IDataPersistence
{
    public GameObject _GameObject;
    public bool _I;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_I)
        {
            _GameObject.SetActive(true);
        }
    }
    public void LoadData(GameData data)
    {
        _I = data._InteractSecondMission;
    }

    public void SaveData(GameData data)
    {

    }
}
