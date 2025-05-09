using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.ResourceManagement.AsyncOperations;

public class DialogBox : MonoBehaviour
{
    private List<string> _Phrases = new List<string>();
    public static DialogBox dialogbox;

    private string _Phrase;
    private string _NewPhrase;

    public Text _Text;
    private int _Count;
    private int _Count2;

    public bool _StopPlaying;
    public bool _IsPlaying = true;

    private bool _isDialogRunning = false;
    private bool _showingLetters = false; // controla se a frase está sendo exibida letra por letra

    public string _Name;
    public AudioSource _characterVoice;
    public LocalizedString localizedString;

    void Start()
    {
        dialogbox = this;
        StartCoroutine(Dialog());
    }

    void Update()
    {

        if (_IsPlaying && PlayerPrefs.GetInt("_CanPlay") == 1 && !_isDialogRunning)
        {
            StartCoroutine(Dialog());
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_showingLetters)
            {
                // se ainda está exibindo a frase, pula para o fim
                _StopPlaying = true;
            }
            else
            {
                // se a frase já terminou, conclui o diálogo
                ConcludeDialog();
            }
        }
    }

    public IEnumerator Dialog()
    {
        _isDialogRunning = true;
        _IsPlaying = false;
        _Phrases.Clear();

        var handle = localizedString.GetLocalizedStringAsync();
        yield return handle;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            string[] textos = handle.Result.Split(';');
            _Phrases.AddRange(textos);
        }

        StringForName();
        PlayerController.playercontroller.SetCanMove(false);

        _Count2 = 0;
        _Count = 0;
        _NewPhrase = "";
        _Phrase = "";

        foreach (string phrase in _Phrases)
        {
            _Text.text = "";
            _Phrase = phrase;
            _NewPhrase = "";
            _Count = 0;
            _showingLetters = true;

            while (_Count < _Phrase.Length)
            {
                yield return new WaitForSeconds(0.08f);
                _NewPhrase += _Phrase[_Count];
                _Text.text = _NewPhrase;
                _characterVoice.Play();
                _Count++;

                if (_StopPlaying)
                {
                    _Text.text = _Phrase;
                    _StopPlaying = false;
                    break;
                }
            }

            _showingLetters = false;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        _StopPlaying = false;
        _IsPlaying = true;
        _isDialogRunning = false;
        PlayerPrefs.SetInt("_CanPlay", 0);
        PlayerController.playercontroller.SetCanMove(true);

        if (transform.parent != null)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

    public void StringForName()
    {
        for (int i = 0; i < _Phrases.Count; i++)
        {
            _Phrases[i] = _Phrases[i].Replace("{nome}", _Name);
        }
    }

    public void ConcludeDialog()
    {
        if (!_isDialogRunning)
            return;

        StopAllCoroutines();

        _Text.text = "";
        _Count2 = 0;
        _Count = 0;
        _NewPhrase = "";
        _StopPlaying = false;
        _IsPlaying = true;
        _isDialogRunning = false;
        _showingLetters = false;

        PlayerController.playercontroller?.SetCanMove(true);
        PlayerPrefs.SetInt("_CanPlay", 0);

        if (transform.parent != null)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

    public bool HeIsInDialog()
    {
        return _IsPlaying;
    }
}
