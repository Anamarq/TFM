using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;


public class ChangeCanvas : MonoBehaviour
{
   // public UIManager[] canvas;
    public static ChangeCanvas instance;
    public UIManager[] canvasRelative;
    
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        canvasRelative[0].numActions.text = "0";
        for (int i = 1; i < canvasRelative.Length; i++)
        {
            canvasRelative[i].numActions.text = "0";
            canvasRelative[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void changeCanvas(string valor)
    //{
    //    for (int i = 0; i < canvas.Length; i++)
    //    {
    //        canvas[i].numActions.text = valor;
    //    }
    //}

    //public void changeCanvasTime(string time)
    //{
    //    for (int i = 0; i < canvas.Length; i++)
    //    {
    //        canvas[i].timer.text = time;
    //    }
       
    //}
    public void changeCanvas(int nlev)
    {
        if (nlev >= 1)
            canvasRelative[nlev - 1].gameObject.SetActive(false);
        canvasRelative[nlev].gameObject.SetActive(true);
    }


    public void changeCanvasRelative(string valor, int nCanvas)
    {
        canvasRelative[nCanvas].numActions.text = valor;
    }
    public void changeTimeRelative(string time, int nCanvas, float fillAmount)
    {
        canvasRelative[nCanvas].timer.text = time;
        canvasRelative[nCanvas].fill.fillAmount = fillAmount;
    }
}
