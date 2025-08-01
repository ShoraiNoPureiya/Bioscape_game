using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialog : MonoBehaviour
{
    private bool _IsPlaying;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision) // when the player approaches, the exclamation point is activated
    {
        _IsPlaying = true; // checks if the player is close or not
        GameObject child = transform.Find("AlertBox")?.gameObject;

        if (child != null)
        {
            // Activates the child object if it was found
            child.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision) // when the player leaves, the exclamation point is deactivated
    {
        _IsPlaying = false; // checks if the player is close or not
        GameObject child = transform.Find("AlertBox")?.gameObject;

        if (child != null)
        {
            // Deactivates the child object if it was found
            child.SetActive(false);
        }
        child = transform.Find("AlertBox/Square/ThoughtsSecondMission")?.gameObject;
        if (child != null)
        {
            // Deactivates the child object if it was found
            child.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_IsPlaying) // checks if the player is close or not
        {
            if (Input.GetKeyDown(KeyCode.E)) // "e" to interact
            {
                Check2(transform);
            }
        }
    }
    void Check2(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++) // activates all "children"
        {
            Transform child = parent.GetChild(i);

            // Checks if the child is "TextBox2" and does not activate it
            if (child.tag == "TextBox")
            {
                continue; // Skips activation and moves to the next child
            }

            // Checks if the child is "Thoughts" and applies the delay
            if (child.name == "Thoughts")
            {
                StartCoroutine(ActivateWithDelay(child.gameObject, 0.2f));

            }
            else
            {
                child.gameObject.SetActive(true); // Activates normally
            }
            // Recursion to process the child's children
            Check2(child);
        }
    }

    IEnumerator ActivateWithDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay); // Waits for the specified time
        obj.SetActive(true); // Activates the object after the delay
    }
}
