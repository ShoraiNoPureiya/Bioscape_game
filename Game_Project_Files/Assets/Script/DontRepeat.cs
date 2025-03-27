using UnityEngine;
using System.Collections.Generic;

public class UniqueObject : MonoBehaviour
{
    private static HashSet<string> existingObjects = new HashSet<string>();


    public string uniqueID;

    void Start()
    {
        // Gets the saved string from PlayerPrefs
        string _SaveObjects = PlayerPrefs.GetString("_SavedObjects", "");

        // Creates a copy to avoid modifying while iterating
        HashSet<string> copyExistingObjects = new HashSet<string>(_SaveObjects.Split(';'));

        // Adds new objects, ensuring no duplicates
        copyExistingObjects.UnionWith(existingObjects);

        // Converts to string and saves in PlayerPrefs
        PlayerPrefs.SetString("_SavedObjects", string.Join(";", copyExistingObjects));
        PlayerPrefs.Save();

        // Updates existingObjects
        existingObjects.Clear();
        existingObjects.UnionWith(copyExistingObjects);

        // If uniqueID is not set, use the GameObject name
        if (string.IsNullOrEmpty(uniqueID))
        {
            uniqueID = gameObject.name;
        }

        // **Now we check if the object already exists, without modifying the HashSet while iterating**
        if (existingObjects.Contains(uniqueID))
        {
            Destroy(gameObject);
        }
        else
        {
            existingObjects.Add(uniqueID);
        }
    }
}
