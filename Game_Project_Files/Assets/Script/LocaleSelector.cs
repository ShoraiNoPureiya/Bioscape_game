using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _Active = false;
    public void ChangeLocale(int _IdLocale)
    {
        if (_Active)
            return;
            StartCoroutine(SetLocale(_IdLocale));

        
    }
        IEnumerator SetLocale(int _Id)
    {
        _Active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_Id];
        _Active = false;
    }
}
