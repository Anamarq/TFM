using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagramController : MonoBehaviour
{
    public GameObject diagram;
    public static DiagramController instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        LoadDiagrams();
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadDiagrams()
    {
        GameObject actualDiagram;
      //  int total = int.Parse(GameManager.instance.totalTries);
        int total = 2;
        for (int i = 0; i < total; ++i)
        {
            actualDiagram = Instantiate(diagram);
            actualDiagram.GetComponent<ShowDiagram>().Show(i.ToString()); 
        }
    }
}
