using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class nada : MonoBehaviour
{
    public GameObject button;
    public void empieza()
    {
        Timer.instance.timerIsRunning = true;
        button.SetActive(false);
    }
}
