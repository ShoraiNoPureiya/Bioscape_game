using UnityEngine;
using System.Collections.Generic;

public class UniqueObject : MonoBehaviour, IDataPersistence
{
    private static HashSet<string> existingObjects = new HashSet<string>();

    public string uniqueID;

    void Start()
    {
        if (string.IsNullOrEmpty(uniqueID))
            uniqueID = gameObject.name;

        string saved = PlayerPrefs.GetString("_SavedObjects", "");

        HashSet<string> loadedSet = new HashSet<string>();

        if (!string.IsNullOrEmpty(saved))
            loadedSet = new HashSet<string>(saved.Split(';'));

        // Junta os dois
        loadedSet.UnionWith(existingObjects);

        existingObjects = loadedSet;

        if (existingObjects.Contains(uniqueID))
        {
            // Se esse objeto já existiu antes → destrói
            Destroy(gameObject);
            return;
        }
        else
        {
            // Se é novo, adiciona
            existingObjects.Add(uniqueID);
        }

        PlayerPrefs.SetString("_SavedObjects", string.Join(";", existingObjects));
        PlayerPrefs.Save();
    }

    public void LoadData(GameData data)
    {
        // Carrega os objetos existentes do save
        existingObjects = new HashSet<string>(data.spawnedObjects);
    }

    public void SaveData(GameData data)
    {
        // Salva todos os IDs registrados
        data.spawnedObjects = new List<string>(existingObjects);
    }
}
