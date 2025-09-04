using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Cellphone : MonoBehaviour
{
    public static Cellphone Instance { get; private set; }
    public GameObject _CellContent;
    public GameObject _ApksChild;
    public GameObject _NotificationUI;
    public PlayerController _Player;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        _CellContent.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && _Player._InDialog)
        {
            if (_CellContent.activeSelf)
                HideCell();
            else
                ShowCell();
        }
    }

    public void DisableAllChildren()
    {
        foreach (Transform child in _ApksChild.transform)
            child.gameObject.SetActive(false);
    }

    public void ShowCell()
    {
        _CellContent.SetActive(true);
    }

    public void HideCell()
    {
        _CellContent.SetActive(false);
    }

    public void ShowNotification()
    {
        StopAllCoroutines();
        StartCoroutine(ShowNotificationWhenCellOpen());
    }

    private IEnumerator ShowNotificationWhenCellOpen()
    {
        // Espera até o celular estar aberto
        yield return new WaitUntil(() => _CellContent.activeSelf);

        _NotificationUI.SetActive(true);

        yield return new WaitForSeconds(3f);

        if (_CellContent.activeSelf)
            _NotificationUI.SetActive(false);
    }
}
