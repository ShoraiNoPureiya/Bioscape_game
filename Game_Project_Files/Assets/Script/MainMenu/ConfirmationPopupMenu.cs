using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine.Localization;

public class ConfirmationPopupMenu : Menu
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private Button confirmButton;
    [SerializeField] private Button cancelButton;

    public void ActivateMenu(LocalizedString displayText, UnityAction confirmAction, UnityAction cancelAction)
    {
        this.gameObject.SetActive(true);

        displayText.StringChanged += UpdateText;

        // remove any existing listeners just to make sure there aren't any previous ones hanging around
        // note - this only removes listeners added through code
        confirmButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();

        // assign the onClick listeners
        confirmButton.onClick.AddListener(() =>
        {
            DeactivateMenu(displayText);
            confirmAction();
        });
        cancelButton.onClick.AddListener(() =>
        {
            DeactivateMenu(displayText);
            cancelAction();
        });
    }

    private void DeactivateMenu(LocalizedString displayText)
    {
        displayText.StringChanged -= UpdateText;
        
        this.gameObject.SetActive(false);
    }
    
    private void UpdateText(string value)
    {
        // set the display text
        this.displayText.text = value;
    }
}
