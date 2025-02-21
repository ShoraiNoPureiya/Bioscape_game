using UnityEngine;
using System.Collections.Generic;

public class UniqueObject : MonoBehaviour
{
    // Static list to track which objects already exist
    private static HashSet<string> existingObjects = new HashSet<string>();

    // Unique identifier for each object (can be the name or something customized)
    public string uniqueID;

    void Awake()
    {
        // If uniqueID is not set, use the GameObject name as the identifier
        if (string.IsNullOrEmpty(uniqueID))
        {
            uniqueID = gameObject.name;
        }

        // Checks if the identifier is already in the list of existing objects
        if (existingObjects.Contains(uniqueID))
        {
            Destroy(gameObject); // Destroys the object if it already exists
        }
        else
        {
            // Marks the object as existing and keeps it when switching scenes
            existingObjects.Add(uniqueID);
        }
    }
}
