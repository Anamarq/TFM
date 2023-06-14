using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;
using System.IO;

public class NewToggleNames : MonoBehaviour
{
    public GameObject toggle;
    public TMP_Text textResult;
    // Start is called before the first frame update
    void Start()
    {
        string filePath = Application.persistentDataPath + "/participants.json";
        string name = "";
        // Si el archivo ya existe, leemos su contenido y lo deserializamos
        NameData data = new NameData();
        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<NameData>(jsonContent);
            for (int i = 0; i < data.ListData.Count; ++i)
            {
                    NewToggle(data.ListData[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewToggle(string name)
    {
        GameObject newToggle;
        newToggle = Instantiate(toggle);
        newToggle.transform.SetParent(transform, false);
        newToggle.GetComponent<ToggleName>().textPrueba = textResult;
        newToggle.GetComponentInChildren<TMP_Text>().text = name;
    }
}
