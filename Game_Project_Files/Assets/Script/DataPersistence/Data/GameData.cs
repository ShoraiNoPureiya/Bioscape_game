using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public int deathCount;
    public int _currentNewsIndex;
    public string _currentScene;
    public Vector3 _playerPosition;
    public SerializableDictionary<string, bool> coinsCollected;
    public SerializableDictionary<string, bool> _allDialogs;
    public SerializableDictionary<string, bool> _allReports;
    public SerializableDictionary<string, bool> _allPhotos;
    public SerializableDictionary<string, bool> _allTasks;
    // public List<MissionProgress> _allMissions;
    public SerializableDictionary<int, List<string>> completedTasksByMission;
    public int _currentMissionIndex;


    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData()
    {
        this.deathCount = 0;
        this._currentNewsIndex = 0;
        this._currentScene = "SampleScene";
        _playerPosition = new Vector3(2.5f, -2f, 0f);
        coinsCollected = new SerializableDictionary<string, bool>();
        _allDialogs = new SerializableDictionary<string, bool>();
        _allReports = new SerializableDictionary<string, bool>();
        _allPhotos = new SerializableDictionary<string, bool>();
        _allTasks = new SerializableDictionary<string, bool>();
        // _allMissions = new List<MissionProgress>();
        completedTasksByMission = new SerializableDictionary<int, List<string>>();
        _currentMissionIndex = 0;


    }

    public int GetPercentageComplete()
    {
        // figure out how many coins we've collected
        int totalCollected = 0;
        foreach (bool collected in coinsCollected.Values)
        {
            if (collected)
            {
                totalCollected++;
            }
        }

        // ensure we don't divide by 0 when calculating the percentage
        int percentageCompleted = -1;
        if (coinsCollected.Count != 0)
        {
            percentageCompleted = (totalCollected * 100 / coinsCollected.Count);
        }
        return percentageCompleted;
    }

    public void IncrementMission()
    {
        _currentNewsIndex++;
    }

    public void TriggerDialog(string dialogId)
    {
        _allDialogs[dialogId] = true;
    }

    public void CapturePhoto(string photoId)
    {
        _allPhotos[photoId] = true;
    }

    

}