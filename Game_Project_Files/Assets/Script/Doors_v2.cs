using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors_v2 : MonoBehaviour
{
    [SerializeField] private string _levelToLoad;
    [SerializeField] private Vector3 _spawnPointID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Load the specified level
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(_levelToLoad);
            
            // Set the player's position to the specified spawn point
            PlayerController.playercontroller._Player.position = _spawnPointID;
            
        }
    }
}
