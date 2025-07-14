using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEditor.Localization.Plugins.XLIFF.V20;

public class Cellphone_CloudApp_NewsAppSystem : MonoBehaviour, IDataPersistence
{
    [Header("Data & Prefabs")]
    [Tooltip("All available news reports (ScriptableObjects)")]
    [SerializeField] private List<Cellphone_CloudApp_NewsReport> _allReports;
    [SerializeField] private GameObject entryPrefab;

    [Header("UI References")]
    [SerializeField] private Transform _listContainer;
    [SerializeField] private GameObject _noSignalPanel;
    [SerializeField] private GameObject _reportPanel;
    [SerializeField] private TextMeshProUGUI _reportTitle;
    [SerializeField] private TextMeshProUGUI _reportContent;
    [SerializeField] private Image _reportImage;
    [SerializeField] private Button _closeReportButton;
    HashSet<string> _unlockedReports = new HashSet<string>();

    // private int _currentMissionIndex => GameProgress.Instance.CurrentNewsIndex;
    private int _currentMissionIndex;
    private Cellphone_CloudApp_NewsReport _currentReport;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            // GameProgress.Instance.IncrementMission();
            _currentMissionIndex++;
            UnlockReport("01");
            RefreshList();
            // Debug.Log("Mission Index: " );
            Debug.Log("Mission Index: " + _currentMissionIndex);
        }
    }

    private void OnEnable()
    {
        RefreshList();
        _closeReportButton.onClick.AddListener(CloseReport);
    }


    // Rebuilds the news list UI based on unlocked reports.
    public void RefreshList()
    {
        // Clear existing entries
        foreach (Transform child in _listContainer)
            Destroy(child.gameObject);

        // Filter unlocked
        var unlocked = _allReports.FindAll(r => _currentMissionIndex >= r._unlockAfterMission);

        if (unlocked.Count == 0)
        {
            _noSignalPanel.SetActive(true);
            _reportPanel.SetActive(false);
            return;
        }

        _noSignalPanel.SetActive(false);

        // Populate list
        foreach (var report in unlocked)
        {
            var entryGO = Instantiate(entryPrefab, _listContainer);
            var entryUI = entryGO.GetComponent<Cellphone_CloudApp_NewsEntryUI>();
            entryUI.Initialize(report, this);
        }
    }


    // Shows a full report page for the given report.
    public void ShowReport(Cellphone_CloudApp_NewsReport report)
    {
        _currentReport = report;
        // Title
        report._title.StringChanged += OnReportTitleChanged;
        report._title.RefreshString();

        // Body
        report._contentText.StringChanged += OnReportContentChanged;
        report._contentText.RefreshString();

        // Image
        _reportImage.sprite = report._contentImage;

        _reportPanel.SetActive(true);
    }

    private void OnReportTitleChanged(string value)
    {
        _reportTitle.text = value;
    }

    private void OnReportContentChanged(string value)
    {
        _reportContent.text = value;
    }

    private void CloseReport()
    {
        _reportPanel.SetActive(false);

        if (_currentReport != null)
        {
            _currentReport._title.StringChanged -= OnReportTitleChanged;
            _currentReport._contentText.StringChanged -= OnReportContentChanged;
            _currentReport = null;
        }
    }

    public void UnlockReport(string reportId)
    {
        if(_allReports == null || _allReports.Count == 0)
        {
            Debug.LogWarning("No reports available to unlock.");
            return;
        }
        foreach (var rep in _allReports)
        {
            Debug.Log("ID " + rep._id + " != " + reportId);
            if (rep._id == reportId)
            {
                _unlockedReports.Add(reportId);
                return;
            }
        }
        Debug.LogWarning($"Report with ID {reportId} not found in the list of all reports.");
    }


    public void LoadData(GameData data)
    {
        bool isUnlocked;
        foreach (var report in _allReports)
        {            
            data._allReports.TryGetValue(report._id, out isUnlocked);
            if (isUnlocked)
            {
                _unlockedReports.Add(report._id);
            }
        }
        _currentMissionIndex = data._currentNewsIndex;
    }

    public void SaveData(GameData data)
    {
        foreach (var report in _allReports)
        {
            if (data._allReports.ContainsKey(report._id))
            {
                data._allReports.Remove(report._id);
            }

            if (_unlockedReports.Contains(report._id))
            {
                data._allReports.Add(report._id, true);
            }
            else
            {
                data._allReports.Add(report._id, false);
            }

        }
        data._currentNewsIndex = _currentMissionIndex;
    }
    
}
