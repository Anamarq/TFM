using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenController : MonoBehaviour
{
    public GameObject prueba;
    private bool on;
    public int nOven;
    public static OvenController instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        on = false;
        nOven = 0;
    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("ovenOn"))
        {
            if (on == false)
            {
                ++nOven;
                
                prueba.GetComponent<Renderer>().material.color = Color.red;
                ChangeCanvas.instance.changeCanvasRelative(nOven.ToString(), 7);
                on = true;
                AudioManager.instance.PlaySFX(2);
            }
        }
        if (other.tag.Equals("ovenOff"))
        {
            if (on == true)
            {
                ++nOven;
                
                prueba.GetComponent<Renderer>().material.color = Color.black;
                ChangeCanvas.instance.changeCanvasRelative(nOven.ToString(), 7);
                on = false;
                AudioManager.instance.PlaySFX(2);
            }
        }
    }
}
