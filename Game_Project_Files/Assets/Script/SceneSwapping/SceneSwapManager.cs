using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapManager : MonoBehaviour, IDataPersistence
{
    public static SceneSwapManager instance;
    public UnityEngine.Vector3 _updatedCoords;
    private PlayerController _playerController;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public static void SwapSceneFromDoorUse(string sceneName, UnityEngine.Vector3 updatedCoords)
    {
        instance.StartCoroutine(instance.FadeOutThenChangeScene(sceneName, updatedCoords));
    }

    private IEnumerator FadeOutThenChangeScene(string sceneName, UnityEngine.Vector3 updatedCoords)
    {
        SceneFadeManager.instance.StartFadeOut();
        while (SceneFadeManager.instance._isFadingOut)
        {
            yield return null;
        }
        _updatedCoords = updatedCoords;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {

        _playerController = FindObjectOfType<PlayerController>();

        SceneFadeManager.instance.StartFadeIn();


        if (_playerController == null)
        {
            Debug.LogWarning("PlayerController not found in the loaded scene!");
        }
        else
        {
            Debug.Log("PlayerController found, updating position to: " + _updatedCoords);
            _playerController.transform.position = _updatedCoords;
        }



    }
    
    public void LoadData(GameData data)
    {
        
        Debug.Log("Loading player position from GameData: " + data._playerPosition);
        _updatedCoords = data._playerPosition;
        
        
        
    }

    public void SaveData(GameData data)
    {
        data._playerPosition = _updatedCoords;
        Debug.Log("Saving player position to GameData: " + data._playerPosition);
        if (SceneManager.GetActiveScene().name != "Menu")
            data._currentScene = SceneManager.GetActiveScene().name; // Save the current scene name
        

        
    }
}
