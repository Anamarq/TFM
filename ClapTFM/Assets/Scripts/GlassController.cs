using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassController : MonoBehaviour
{
    private bool isInit;
    private bool isEnd;

    // Start is called before the firsts frame update
    void Start()
    {
        isInit = false;
        isEnd = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("InitLimit"))
        {
            if (isEnd == false)
                isInit = true;

        }

        if (other.tag.Equals("EndLimit"))
        {
            if (isInit == true)
            {
                isEnd = true;
                //ChangeGlass.instance.DeleteGlass();
            }

        }

        if (other.tag.Equals("EndSurface"))
        {
            if (isEnd == true)
            {
                ChangeGlass.instance.NewGlass();
                GetComponentInChildren<FadeOut>().StartFading();

            }
            isInit = false;
            isEnd = false;
        }
        if (other.tag.Equals("floor"))
        {
            ChangeGlass.instance.Reset();
            isInit = false;
            isEnd = false;
        }

    }
    //private void OnTriggerEnter(Collider other)
    //{
        
    //    if (other.tag.Equals("EndSurface"))
    //    {
    //        ChangeGlass.instance.NewGlass();
    //        GetComponentInChildren<FadeOut>().StartFading();

    //    }
    //    if (other.tag.Equals("floor"))
    //    {
    //        ChangeGlass.instance.Reset();
    //    }

    //}
}
