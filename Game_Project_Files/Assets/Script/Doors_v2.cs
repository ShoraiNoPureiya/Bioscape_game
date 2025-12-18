using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Doors_v2 : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string _levelToLoad;
    [SerializeField] private Vector3 _spawnPointCoords;
    public static bool _Garden;
    private PlayerController _playerController;

    // private void Awake()
    // {
    //     // _sceneSwapManager = SceneSwapManager.instance;
    //     // if (_sceneSwapManager == null)
    //     // {
    //     //     Debug.LogError("SceneSwapManager instance is not found.");
    //     // }
    // }
    public void LoadData(GameData data)
    {
        // Carrega os objetos existentes do save
        _Garden = data._Garden;
    }

    public void SaveData(GameData data)
    {
        // Salva todos os IDs registrados
        data._Garden = _Garden;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (DataPersistenceManager.instance.CurrentOrder == 4)
        {
            _Garden = true;
        }
            if (collision.CompareTag("Player"))
        {
            _playerController = FindObjectOfType<PlayerController>();
            _playerController.SetCanMove(false);
            if (_levelToLoad == "Garden")
            {
                if (_Garden)
                {
                    SceneSwapManager.SwapSceneFromDoorUse(_levelToLoad, _spawnPointCoords);
                }
                else
                {
                    _playerController.SetCanMove(true);
                    return; 
                }
            }
            if (_levelToLoad == "Car")
            {
                if (GetKey._Key)
                {
                    SceneSwapManager.SwapSceneFromDoorUse(_levelToLoad, _spawnPointCoords);
                }
                else
                {
                    _playerController.SetCanMove(true);
                }
            }
            else
            {
                SceneSwapManager.SwapSceneFromDoorUse(_levelToLoad, _spawnPointCoords);
            }
        }
    }
    public void SwitchScene()
    {
        SceneSwapManager.SwapSceneFromDoorUse(_levelToLoad, _spawnPointCoords);
    }
    private void Update()
    {
    }
}
