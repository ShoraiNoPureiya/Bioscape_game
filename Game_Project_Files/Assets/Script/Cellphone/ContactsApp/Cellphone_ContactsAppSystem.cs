using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cellphone_ContactsAppSystem : MonoBehaviour, IDataPersistence
{
    [Header("Data & Prefabs")]
    [Tooltip("All available news contacts (ScriptableObjects)")]
    [SerializeField] private List<Cellphone_ContactsApp_Contact> _allContacts;
    [SerializeField] private GameObject _entryPrefab;

    [Header("UI References")]
    [SerializeField] private Transform _listContainer;
    [SerializeField] private GameObject _noContactsPanel;
    [SerializeField] private GameObject _callScreen;
    [SerializeField] private TextMeshProUGUI _contactName;
    [SerializeField] private Image _contactImage;
    [SerializeField] private Button _closeContactButton;
    [SerializeField] private Button _callContactButton;
    private Contacts_DialogChoiceManager _dialogChoiceManager;
    public GameObject _dialogUI;
    private HashSet<string> _unlockedDialogs = new HashSet<string>();

    private int currentMissionIndex => GameProgress.Instance.CurrentNewsIndex;
    private Cellphone_ContactsApp_Contact _currentContact;

    private void Awake()
    {
        _dialogChoiceManager = _dialogUI.GetComponent<Contacts_DialogChoiceManager>();
        _dialogUI.SetActive(false);

    }



    private void Update()
    {
        /*
        --------------------
            DEBUG KEYS
        --------------------

        if (Input.GetKeyDown(KeyCode.H)) //Debug key to unlock Miltinho
        {
            // GameProgress.Instance.TriggerDialog("Miltinho");
            // GameProgress.Instance.TriggerDialog("Fazendeiro");
            // UnlockContactDialog("Miltinho");
            UnlockContactDialog("Fazendeiro");

            RefreshList();

            // Debug.Log("Unlocked Miltinho? " + GameProgress.Instance.HasTriggeredDialog("Miltinho"));
            Debug.Log("Unlocked Fazendeiro? ");
        }
        */
    }

    private void OnEnable()
    {
        RefreshList();
        _closeContactButton.onClick.AddListener(CloseContact);
        _callContactButton.onClick.RemoveAllListeners();
        _callContactButton.onClick.AddListener(OnCallButtonClicked);
    }


    public void RefreshList()
    {
        // Clear existing entries
        foreach (Transform child in _listContainer)
            Destroy(child.gameObject);

        // Filter unlocked
        // var unlockedContacts = _allContacts.Where(c => GameProgress.Instance.HasTriggeredDialog(c._dialogNpcId)).ToList();
        // var unlockedContacts = _allContacts.Where(c => c._isUnlocked == true).ToList();
        var unlockedContacts = _allContacts.Where(c => _unlockedDialogs.Contains(c._dialogNpcId)).ToList();

        // If no unlocked contacts, show the no contacts panel
        if (unlockedContacts.Count == 0)
        {
            _noContactsPanel.SetActive(true);
            _callScreen.SetActive(false);
            return;
        }

        _noContactsPanel.SetActive(false);

        // Populate list
        foreach (var contact in unlockedContacts)
        {
            var entryGO = Instantiate(_entryPrefab, _listContainer);
            var entryUI = entryGO.GetComponent<Cellphone_ContactsApp_ContactEntryUI>();
            entryUI.Initialize(contact, this);
        }
    }


    public void ShowContact(Cellphone_ContactsApp_Contact contact)
    {
        _currentContact = contact;

        _contactName.text = contact._contactName;

        _contactImage.sprite = contact._profileImage;

        _callScreen.SetActive(true);
    }

    private void OnContactTitleChanged(string value)
    {
        _contactName.text = value;
    }

    private void CloseContact()
    {
        _callScreen.SetActive(false);

    }

    private void OnCallButtonClicked()
    {
        if (_currentContact == null) return;
        CallContact(_currentContact);
    }

    public void CallContact(Cellphone_ContactsApp_Contact contact)
    {
        if (contact._startingDialogNode == null)
        {
            Debug.LogWarning($"Contact {contact._contactName} has no dialog assigned");
            return;
        }
        _dialogUI.SetActive(true);
        _dialogChoiceManager.BeginConversation(contact._startingDialogNode);

    }
    
    public void UnlockContactDialog(string dialogNpcId)
    {
        foreach (var contactId in _allContacts.Select(c => c._dialogNpcId)) {
            if (contactId == dialogNpcId)
            {
                _unlockedDialogs.Add(dialogNpcId);
                return;
            }
        }
        Debug.LogWarning($"Dialog NPC ID {dialogNpcId} not found in contacts.");
    }

    public void LoadData(GameData data)
    {
        bool isUnlocked;
        foreach (var contact in _allContacts)
        {
            data._allDialogs.TryGetValue(contact._dialogNpcId, out isUnlocked);
            if (isUnlocked)
            {
                _unlockedDialogs.Add(contact._dialogNpcId);
            }
        }
    }

    public void SaveData(GameData data) 
    {
        foreach (var contact in _allContacts)
        {
            if (data._allDialogs.ContainsKey(contact._dialogNpcId))
            {
                data._allDialogs.Remove(contact._dialogNpcId);
            }
            
            if (_unlockedDialogs.Contains(contact._dialogNpcId))
            {
                data._allDialogs.Add(contact._dialogNpcId, true);
            }
            else
            {
                data._allDialogs.Add(contact._dialogNpcId, false);
            }
            
        }
    }
    
}
