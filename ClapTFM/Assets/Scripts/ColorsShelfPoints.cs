using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsShelfPoints : MonoBehaviour
{
    public static ColorsShelfPoints instance;
    public int pointsSet;
    public int nGlasses;
    public int points;
    public GameObject[] glasses;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        nGlasses = 0;
        pointsSet = 0;
        points = 0;
        for (int i = 1; i < glasses.Length; i++)
        {
            glasses[i].SetActive(false);
        }
        glasses[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NewGlasses()
    {
        AudioManager.instance.PlaySFX(4);
        //Fade out each box
        glasses[nGlasses].transform.GetChild(0).GetComponentInChildren<FadeOut>().StartFading();
        glasses[nGlasses].transform.GetChild(1).GetComponentInChildren<FadeOut>().StartFading();
        if (nGlasses >= 1)
            glasses[nGlasses - 1].SetActive(false);
        ++nGlasses;
        ++points;
        ChangeCanvas.instance.changeCanvasRelative(points.ToString(), 5);
        if (nGlasses < glasses.Length - 1)
        {
            glasses[nGlasses].SetActive(true);
        }
    }
    public void Reset()
    {
        ++nGlasses;
        if (nGlasses < glasses.Length - 1)
        {
            glasses[nGlasses - 1].SetActive(false);
            glasses[nGlasses].SetActive(true);
        }
    }
}
