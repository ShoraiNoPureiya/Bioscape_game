using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour, IDataPersistence
{
    public static bool _Key = false;
    // Start is called before the first frame update
    void Start()
    {
        _Key = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadData(GameData data)
    {
        // Carrega os objetos existentes do save
        _Key = data._Key;
    }

    public void SaveData(GameData data)
    {
        // Salva todos os IDs registrados
        data._Key = _Key;
    }
}
