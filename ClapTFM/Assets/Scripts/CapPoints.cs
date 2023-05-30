using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapPoints : MonoBehaviour
{
    public static CapPoints instance;
    public int nCaps;
    public int points;
    public int pointsSet;
    public GameObject[] caps;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        nCaps = 0;
        points = 0;
        pointsSet = 0;
        for (int i = 1; i < caps.Length; i++)
        {
            caps[i].SetActive(false);
        }
        caps[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewCaps()
    {
        AudioManager.instance.PlaySFX(4);
        ++nCaps;
        ++points;
        ChangeCanvas.instance.changeCanvasRelative(points.ToString(), 3);
        if (nCaps < caps.Length - 1)
        {
            caps[nCaps - 1].SetActive(false);
            caps[nCaps].SetActive(true);
        }
    }
    public void Reset()
    {
        ++nCaps;
        if (nCaps < caps.Length - 1)
        {
            caps[nCaps - 1].SetActive(false);
            caps[nCaps].SetActive(true);
        }
    }
}
