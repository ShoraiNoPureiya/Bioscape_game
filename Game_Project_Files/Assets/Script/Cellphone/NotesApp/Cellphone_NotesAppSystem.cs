using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Cellphone_NotesAppSystem : MonoBehaviour, IDataPersistence
{
    [SerializeField] private Cellphone_NotesApp_NotePage[] _allPages;
    [SerializeField] private GameObject _missionListScreen;
    [SerializeField] private Transform _missionListContent;
    [SerializeField] private GameObject _taskListScreen;
    [SerializeField] private Transform _taskListContent;
    [SerializeField] private Button _backButton;
    [SerializeField] private GameObject _missionButtonPrefab;
    [SerializeField] private GameObject _taskEntryPrefab;
    private HashSet<string> _completedTasks = new HashSet<string>();
    private void Awake()
    {
        _backButton.onClick.AddListener(ShowMissionList);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            CompleteTask(0, "M1_CleanBathroom");
            PopulateMissions();
            print("Task Completed!");
        }

    }

    private void OnEnable()
    {
        ShowMissionList();
    }

    void ShowMissionList()
    {
        _taskListScreen.SetActive(false);
        _missionListScreen.SetActive(true);
        PopulateMissions();
    }

    void PopulateMissions()
    {
        // clear
        foreach (Transform t in _missionListContent) Destroy(t.gameObject);

        // instantiate one per page
        foreach (var page in _allPages.OrderBy(p => p._missionIndex))
        {
            var go = Instantiate(_missionButtonPrefab, _missionListContent);
            var missionUI = go.GetComponent<Cellphone_NotesApp_MissionEntryUI>();
            missionUI.Initialize(page, OnMissionSelected);

            PopulateTasks(page);
        }
    }

    void OnMissionSelected(Cellphone_NotesApp_NotePage page)
    {
        _missionListScreen.SetActive(false);
        _taskListScreen.SetActive(true);
        PopulateTasks(page);
    }

    void PopulateTasks(Cellphone_NotesApp_NotePage page)
    {
        foreach (Transform t in _taskListContent) Destroy(t.gameObject);
        int i = 0;
        foreach (var task in page._tasks)
        {
            i++;
            var go = Instantiate(_taskEntryPrefab, _taskListContent);
            var taskUI = go.GetComponent<Cellphone_NotesApp_TaskEntryUI>();
            bool done = HasCompletedTask(page._missionIndex, task._taskId);
            taskUI.Initialize(i, task._taskDescription, done);
        }
    }

    // public bool HasUnlockedMission(int missionIndex)
    // {
    //     return _completedTasksByMission.TryGetValue(missionIndex, out var set)
    //         && set.Count > 0;
    // }

    public bool HasCompletedTask(int missionIndex, string taskId)
    {
        return _completedTasks.Contains(taskId);
    }

    public void CompleteTask(int missionIndex, string taskId)
    {
        foreach (var page in _allPages)
        {
            foreach (var task in page._tasks)
            {
                if (task._taskId == taskId)
                {
                    _completedTasks.Add(taskId);


                    return;
                }
            }

        }
    }

    public void LoadData(GameData data)
    {
        bool isUnlocked;
        foreach (var page in _allPages)
        {
            foreach (var task in page._tasks)
            {
                data._allTasks.TryGetValue(task._taskId, out isUnlocked);
                if (isUnlocked)
                {
                    _completedTasks.Add(task._taskId);
                }
            }
        }
    }

    public void SaveData(GameData data) 
    {
        foreach (var page in _allPages)
        {
            foreach (var task in page._tasks)
            {
                if (data._allTasks.ContainsKey(task._taskId))
                {
                    data._allTasks.Remove(task._taskId);
                }

                if (_completedTasks.Contains(task._taskId))
                {
                    data._allTasks.Add(task._taskId, true);
                }
                else
                {
                    data._allTasks.Add(task._taskId, false);
                }
            }
        }
    }

}