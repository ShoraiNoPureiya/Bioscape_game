using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Xml.Linq;

public class DataBase : MonoBehaviour
{
    private string connect;
    // Start is called before the first frame update
    void Start()
    {
        connect = "URI=file:" + Application.dataPath + "/au.sqlite";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DeleteData(int id)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connect))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("DELETE FROM Cliente WHERE ID = \"{0}\"",id);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();



            }
        }
    }
    private void insertData(string Name)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connect))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("INSERT INTO Cliente(Nome) VALUES (\"{0}\");",Name);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();

     

            }
        }
    }

    private void GetData()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connect))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM Cliente";
                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read()) { Debug.Log(reader.GetString(1)); }

                  dbConnection.Close();
                    reader.Close();
                }
                     
            }
        }
    }
}
