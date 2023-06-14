using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Timer : MonoBehaviour
{
    public static Timer instance;
   // public UIManager[] canvas;
    private float totalTime = 10;
    public float timeRemaining;
    public bool timerIsRunning = false;
    private int nlev;

    private void Awake()
    {
        instance = this;   
    }
    private void Start()
    {
        nlev = 0;
        timeRemaining = totalTime; 
        ChangeCanvas.instance.changeTimeRelative(timeRemaining.ToString("0"), nlev, 1);
        timeRemaining += SceneData.instance.extraTime;
        timerIsRunning = false;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                if ((timeRemaining <= totalTime + Time.deltaTime) && (timeRemaining >= totalTime - Time.deltaTime))
                {
                    AudioManager.instance.StopVideo(GameManager.instance.nlev);
                    AudioManager.instance.PlaySFX(0);
                }
                if (timeRemaining <= totalTime)
                {
                    ChangeCanvas.instance.changeTimeRelative(timeRemaining.ToString("0"), nlev, (timeRemaining / totalTime));
                }
                if((GameManager.instance.totalTries == "0") && (timeRemaining <= totalTime + Time.deltaTime + 10) && (timeRemaining >= totalTime - Time.deltaTime + 10))
                {
                    AudioManager.instance.PlayVideo(GameManager.instance.nlev);
                }
            }
            else
            {
                AudioManager.instance.PlaySFX(3);
                timeRemaining = 0;
                ChangeCanvas.instance.changeTimeRelative(timeRemaining.ToString("0"), nlev, (timeRemaining / totalTime));
                ++nlev;
                timerIsRunning = false;
                GameManager.instance.Finish();
            }
        }
    }
    public void Restart()
    {
        timerIsRunning = true;
        if(GameManager.instance.totalTries == "0")
        timeRemaining = totalTime + 20;
            else
        timeRemaining = totalTime + 10;
    }
    //void changeCanvas(string time)
    //{
    //    for (int i = 0; i < canvas.Length; i++)
    //    {
    //        canvas[i].timer.text = time;
    //    }
    //}
}