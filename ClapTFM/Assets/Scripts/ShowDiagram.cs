
using Newtonsoft.Json;
using Oculus.Platform.Samples.VrHoops;

using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ShowDiagram : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private int[] points;
    Renderer renderer;

    void Start()
    {

        //Show(0.ToString());
        
    }

    public void Show(string totalTries)
    {
        renderer = GetComponent<Renderer>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 8;  // Establece el número de puntos para el diagrama
        points = new int[8];

        string filePath = Application.persistentDataPath + "/ana0.json";
       // string filePath = Application.persistentDataPath + "/" + GameManager.instance.nameUser + totalTries + ".json";

        // Si el archivo ya existe, leemos su contenido y lo deserializamos
        UserData data = new UserData();
        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<UserData>(jsonContent);
        }

        for (int i=0; i<data.TotalMovs.Count; ++i)
        {
            points[i] = int.Parse(data.TotalMovs[i]);
            
        }
        //// Define las posiciones de los puntos del diagrama
        //Vector3[] positions = new Vector3[]
        //{
        //    new Vector3(0f, points[0], 0f),
        //    new Vector3(1f, points[1], 0f),
        //    new Vector3(2f, points[2], 0f),
        //    new Vector3(3f, points[3], 0f),
        //    new Vector3(4f, points[4], 0f),
        //    new Vector3(5f, points[5], 0f),
        //    new Vector3(6f, points[6], 0f),
        //    new Vector3(7f, points[7], 0f)
        //};

        Vector3[] positions = new Vector3[]
        {
                    new Vector3(-1f, 2.2f, 0.7f),
                    new Vector3(-0.8f, 2.4f, 0.7f),
                    new Vector3(-0.6f, 2.6f, 0.7f),
                    new Vector3(-0.4f,2.2f, 0.7f),
                    new Vector3(-0.2f, 2.2f, 0.7f),
                    new Vector3(0f, 2.4f, 0.7f),
                    new Vector3(0.2f, 2.2f, 0.7f),
                    new Vector3(0.4f, 2.6f, 0.7f)
        };
        Vector3[] positions2 = new Vector3[]
      {
                    new Vector3(-1f, 2.0f, 0.7f),
                    new Vector3(-0.8f, 2.4f, 0.7f),
                    new Vector3(-0.6f, 2.2f, 0.7f),
                    new Vector3(-0.4f,2.2f, 0.7f),
                    new Vector3(-0.2f, 2.6f, 0.7f),
                    new Vector3(0f, 2.2f, 0.7f),
                    new Vector3(0.2f, 2.8f, 0.7f),
                    new Vector3(0.4f, 2.8f, 0.7f)
      };

        // Establece las posiciones en el Line Renderer
        if(totalTries =="0")
        lineRenderer.SetPositions(positions);
        else
            lineRenderer.SetPositions(positions2);
        Color randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        renderer.material.color = randomColor;


    }
}
