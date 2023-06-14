using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiagramController : MonoBehaviour
{
    public GameObject diagram;
    public static DiagramController instance;
    public TMP_Text[] difPoints;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //LoadDiagrams();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadDiagrams()
    {
        GameObject actualDiagram;
        // int total = 3;
        int total;
       // SaveJson.instance.SetData("kana", "/participants.json");
        if (SceneData.instance.totalTries  == 0)
            total = 1;
        else
            total = 3;
        for (int i = 0; i < total; ++i)
        {
            actualDiagram = Instantiate(diagram);
            actualDiagram.GetComponent<ShowDiagram>().Show(i);
        }
    }
    public void differencePoints(float[] maxPoints, float[] actPoints)
    {
        for (int i = 0; i < 8; ++i)
        {
            difPoints[i].gameObject.SetActive(true);
            difPoints[i].text = (actPoints[i] - maxPoints[i]).ToString();
        }
    }
}
