using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class UpdateTextOnLanguageChanged : MonoBehaviour
{
    [SerializeField] private LocalizedString _localizedString;
    [SerializeField] private TMP_Text _Text;

    private void OnEnable()
    {
        _localizedString.StringChanged += UpdateText;
    }

    private void OnDisable()
    {
        _localizedString.StringChanged -= UpdateText;
    }

    private void UpdateText(string value)
    {
        _Text.text = value;
    }
}
