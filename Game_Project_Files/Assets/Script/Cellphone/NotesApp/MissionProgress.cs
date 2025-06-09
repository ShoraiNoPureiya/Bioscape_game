using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MissionProgress
{
    public MissionProgress(int missionIndex)
    {
        _missionIndex = missionIndex;
        // _completedTaskId = "";
        _completedTaskIds = new List<string>();
    }
    public int _missionIndex;
    // public string _completedTaskId;
    public List<string> _completedTaskIds = new List<string>();
}
