using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class InteractSecondMission : MonoBehaviour, IDataPersistence
{
    // Start is called before the first frame update
    public GameObject _Mission;
    public bool _I;
    void Start()
    {
        _Mission.SetActive(true);
        _I = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadData(GameData data)
    {
        // Carrega os objetos existentes do save
        _I = data._InteractSecondMission;
    }

    public void SaveData(GameData data)
    {
        // Salva todos os IDs registrados
        data._InteractSecondMission = _I;
    }
}
