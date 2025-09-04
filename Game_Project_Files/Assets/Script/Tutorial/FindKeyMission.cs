using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class FindKeyMission : MonoBehaviour, IDataPersistence
{
    private int _taskOrder = 0; // Default task order
    [SerializeField] private List<LocalizedString> _taskDescriptions; // List of task descriptions
    [SerializeField] private TextMeshProUGUI _taskText; // UI Text to display the current task
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the task text with the first task description
        if (_taskDescriptions != null && _taskDescriptions.Count > 0)
        {
            UpdateTaskText();
        }
    }

    public void NextTask()
    {
        // Increment the task order and wrap around if necessary
        _taskOrder++;
        if (_taskOrder > _taskDescriptions.Count)
        {
            _taskOrder = 0; // Reset to the first task if count is exceeded
        }
        UpdateTaskText();
    }
    private void UpdateTaskText()
    {
        // Update the task text with the current task description
        if (_taskText != null && _taskOrder < _taskDescriptions.Count)
        {
            _taskDescriptions[_taskOrder].GetLocalizedStringAsync().Completed += handle =>
            {
                _taskText.text = handle.Result;
            };
        }
    }

    public void LoadData(GameData data)
    {
        // Load the task order from GameData
        _taskOrder = data._currentMissionIndex;
    }
    public void SaveData(GameData data)
    {
        // Save the task order to GameData
        data._currentMissionIndex = _taskOrder;
    }
}
