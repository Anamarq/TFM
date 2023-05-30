using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    //public static BasketController instance;
    private bool isInit;
    private bool isEnd;
    private void Awake()
    {
        //instance = this;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("LimitBasket"))
        {
            if (isEnd == false)
                isInit = true;
        }

        if (other.tag.Equals("LimitWasher"))
        {
            if (isInit == true)
            {
                isEnd = true;
                //ChangeBasket.instance.DeleteBasket();
            }
        }

        if (other.tag.Equals("EndSurface"))
        {
            if (isEnd == true)
            {
                ChangeBasket.instance.NewBasket();
                GetComponent<FadeOut>().StartFading();
            }
            isInit = false;
            isEnd = false;
        }
    }
}
