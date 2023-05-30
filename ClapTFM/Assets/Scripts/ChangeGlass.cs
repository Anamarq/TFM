using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGlass : MonoBehaviour
{
    public static ChangeGlass instance;
    public GameObject[] glasses;
    public int nglass = 0;
    public int pointGlass = 0;
    // private Vector3 glassPos;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        // glassPos = transform.position;
        nglass = 0;
        pointGlass = 0;
        //ChangeCanvas.instance.changeCanvas(nglass.ToString());
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
    public void NewGlass()
    {
        AudioManager.instance.PlaySFX(4);
        DeleteGlass();
        ++nglass;
        ++pointGlass;
        ChangeCanvas.instance.changeCanvasRelative( pointGlass.ToString(), 0);
        if (nglass >= glasses.Length)
        {
            GameManager.instance.Finish();
        }
        else
        {
            glasses[nglass].SetActive(true);
        }
    }
    public void Reset()
    {
        glasses[nglass].SetActive(false);
        ++nglass;
        glasses[nglass].SetActive(true);
    }
    public void DeleteGlass()
    {
        if(nglass >= 1)
            glasses[nglass - 1].SetActive(false);
    }
    //public void ResetPos()
    //{
    //    transform.position = glassPos;
    //    nglass = 0;
    //    for (int i = 0; i < glasses.Length; i++)
    //    {
    //        glasses[i].SetActive(false);
    //        glasses[i].transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    //    }
    //    glasses[0].SetActive(true);
    //    ++nglass;
    //}
}

