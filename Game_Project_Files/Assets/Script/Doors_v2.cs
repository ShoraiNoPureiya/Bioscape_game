using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Doors_v2 : MonoBehaviour
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
                } else
                {
                    _playerController.SetCanMove(true);
                }
            }
            else { 
            SceneSwapManager.SwapSceneFromDoorUse(_levelToLoad, _spawnPointCoords);
            }
        }
    }
}
