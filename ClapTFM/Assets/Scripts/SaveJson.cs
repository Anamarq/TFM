using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveJson : MonoBehaviour
{
    public static SaveJson instance;
    private void Awake()
    {
        instance = this;
    }

    //public void SaveToJson(string id, string movs, string path)
    //{
    //    TryData data = new TryData();
    //    data.Id = id;
    //    data.TotalMovs = movs;

    //    string json = JsonUtility.ToJson(data, true);
    //    File.WriteAllText(Application.persistentDataPath + path, json);
    //}
    public void SaveToJson(string movs, string path)
    {
        string filePath = Application.persistentDataPath + path;

        // Si el archivo ya existe, leemos su contenido y lo deserializamos
        UserData data = new UserData();
        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<UserData>(jsonContent);
        }
        else
            data.TotalMovs = new List<string>();


        // Agregar nuevos datos al JSON existente
        data.TotalMovs.Add(movs);

        // Convertir el JSON actualizado a una cadena JSON
        string json = JsonUtility.ToJson(data, true);

        // Escribir la cadena JSON actualizada en el archivo
        File.WriteAllText(filePath, json);
    }
    //public void SaveNamesToJson(string name, string path)
    //{
    //    int total = 0;
    //    string filePath = Application.persistentDataPath + path;

    //    // Si el archivo ya existe, leemos su contenido y lo deserializamos
    //    NameData data = new NameData();
    //    if (File.Exists(filePath))
    //    {
    //        string jsonContent = File.ReadAllText(filePath);
    //        data = JsonUtility.FromJson<NameData>(jsonContent);
    //    }
    //    else
    //        data.ListData = new List<Tuple<string, string>>();
    //    //data.ListData = new List<NameData.Data>();
    //    //int i = 0;
    //    //while (i < data.ListData.Count)
    //    //{
    //    //    //Si existe ekl nombre..
    //    //    if (data.ListData[i].Item1 == name)
    //    //    {
    //    //        data.ListData[i].Item2++;
    //    //        break;
    //    //    }
    //    //    ++i;
    //    //}
    //    for(int i = 0; i < data.ListData.Count; i++)
    //    {
    //        //Si existe ekl nombre..
    //        if (data.ListData[i].Item1 == name)
    //            total++;
    //    }
    //    // Agregar nuevos datos al JSON existente
    //    //if (i == data.ListData.Count)    
    //        data.ListData.Add(new Tuple<string, string>(name, total.ToString("0")));

    //    // Convertir el JSON actualizado a una cadena JSON
    //    string json = JsonUtility.ToJson(data, true);

    //    // Escribir la cadena JSON actualizada en el archivo
    //    File.WriteAllText(filePath, json);
    //}
    public void SaveNamesToJson(string name, string path)
    {
        int total = 0;
        string filePath = Application.persistentDataPath + path;

        // Si el archivo ya existe, leemos su contenido y lo deserializamos
        NameData data = new NameData();
        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<NameData>(jsonContent);
        }
        else
        {
            data.ListData = new List<string>();
            data.Total = new List<string>();
        }
        for (int i = 0; i < data.ListData.Count; i++)
        {
            //Si existe ekl nombre..
            //if (data.ListData[i] == name)
            //    total++;
            if (data.ListData[i] == name)
            {
                total = (int.Parse(data.Total[i]) + 1);
                data.Total[i] = total.ToString("0");
            }
        }
        GameManager.instance.nameUser = name;
        GameManager.instance.totalTries = total.ToString("0");
        if (total == 0)
            Timer.instance.timeRemaining += 15;
        else
            Timer.instance.timeRemaining += 5;
        // Agregar nuevos datos al JSON existente
        if (total == 0)
        {
            data.ListData.Add(name);
            data.Total.Add("0");
        }

        // Convertir el JSON actualizado a una cadena JSON
        string json = JsonUtility.ToJson(data, true);

        // Escribir la cadena JSON actualizada en el archivo
        File.WriteAllText(filePath, json);
    }
    //public void LoadFromJson()
    //{
    //    string json = File.ReadAllText(Application.dataPath + "/TryDataFile.json");
    //    TryData data = JsonUtility.FromJson<TryData>(json);
    //}
}