using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cellphone_DiaryApp_GallerySystem : MonoBehaviour, IDataPersistence
{
    [SerializeField] private Cellphone_DiaryApp_GalleryUI _galleryUI; //Reference to the UI component that displays the gallery page
    [SerializeField] private List<Cellphone_CameraApp_PhotoEntry> _galleryPhotoEntries; //List of gallery pages to be displayed
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _previousButton;
    [SerializeField] private AudioSource _audioSource; //Audio source for playing sounds
    [SerializeField] private AudioClip _flipPageSound; //Sound to play when navigating pages
    private int _currentPageIndex = 0; //Index of the current page being displayed

    private HashSet<string> _unlockedPhotos = new HashSet<string>();
    private Cellphone_CameraApp_PhotoEntry _currentEntry;
    private void Start()
    {
        _currentEntry = _galleryPhotoEntries[_currentPageIndex]; //Get the first page entry
        _galleryUI.UpdateGalleryUI(_currentEntry); //Initialize the gallery UI with the first page
        _nextButton.onClick.AddListener(NextPage); //Add listener for next button
        _previousButton.onClick.AddListener(PreviousPage); //Add listener for previous button
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //Debug key to unlock photo
        {
            UnlockPhoto("03");
        }
        if (Input.GetKeyDown(KeyCode.O)) //Debug key to unlock photo
        {
            UnlockPhoto("02");
        }
        
    }

    public void NextPage()
    {
        if (_currentPageIndex < _galleryPhotoEntries.Count - 1)
        {
            PlaySFXPageFlipping(1.2f, 1.4f);
            _audioSource.PlayOneShot(_flipPageSound); //Play the flip page sound
            _currentPageIndex++;
            _currentEntry = _galleryPhotoEntries[_currentPageIndex];
            _galleryUI.UpdateGalleryUI(_currentEntry); //Update the UI with the next page
        }
    }

    public void PreviousPage()
    {
        if (_currentPageIndex > 0)
        {
            PlaySFXPageFlipping(1.1f, 1.3f);
            _audioSource.PlayOneShot(_flipPageSound); //Play the flip page sound
            _currentPageIndex--;
            _currentEntry = _galleryPhotoEntries[_currentPageIndex];
            _galleryUI.UpdateGalleryUI(_currentEntry); //Update the UI with the previous page
        }
    }

    private void PlaySFXPageFlipping(float _lowerPitch, float _higherPitch){
        _audioSource.volume = 0.5f;
        _audioSource.pitch = Random.Range(_lowerPitch, _higherPitch); //Randomizes the pitch of the audio to create variability
        _audioSource.PlayOneShot(_flipPageSound); //Play the page flip sound
    }


    public void UnlockPhoto(string photoId)
    {
        Debug.Log("Unlocking photo with ID: " + photoId);
        foreach (var photo in _galleryPhotoEntries)
        {
            Debug.Log("Checking photo ID: " + photo._photoId);
            if (photo._photoId == photoId)
            {
                _unlockedPhotos.Add(photoId);
                _galleryUI.UpdateGalleryUI(photo); // Update the UI with the newly unlocked photo
                return;
            }
        }
        
        Debug.LogWarning("Photo ID not found in gallery entries: " + photoId);
    }
    
    public bool HasUnlockedPhoto(string photoId)
    {
        return _unlockedPhotos.Contains(photoId);
    }
    
    public void LoadData(GameData data)
    {
        bool isUnlocked;
        foreach (var photo in _galleryPhotoEntries)
        {
            data._allPhotos.TryGetValue(photo._photoId, out isUnlocked);
            if (isUnlocked)
            {
                _unlockedPhotos.Add(photo._photoId);
                
            }
        }
    }

    public void SaveData(GameData data) 
    {
        foreach (var photo in _galleryPhotoEntries)
        {
            Debug.Log("TEST PHOTO: " + photo._photoId);
            if (data._allPhotos.ContainsKey(photo._photoId))
            {
                data._allPhotos.Remove(photo._photoId);
            }
            
            if (_unlockedPhotos.Contains(photo._photoId))
            {
                data._allPhotos.Add(photo._photoId, true);
            }
            else
            {
                data._allPhotos.Add(photo._photoId, false);
            }
            
        }
    }
}
