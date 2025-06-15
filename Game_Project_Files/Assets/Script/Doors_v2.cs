using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors_v2 : MonoBehaviour
{
    [SerializeField] private string _levelToLoad;
    [SerializeField] private Vector3 _spawnPointCoords;
    

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
        if (collision.CompareTag("Player"))
        {
            SceneSwapManager.SwapSceneFromDoorUse(_levelToLoad, _spawnPointCoords);

        }
    }
}
