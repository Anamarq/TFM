using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBasket : MonoBehaviour
{
    public static ChangeBasket instance;
    public GameObject[] baskets;
    public int nbasket = 0;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        nbasket = 0;
        for (int i = 1; i < baskets.Length; i++)
        {
            baskets[i].SetActive(false);
        }
        baskets[0].SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void NewBasket()
    {
        AudioManager.instance.PlaySFX(4);
        DeleteBasket();
        ++nbasket;
        ChangeCanvas.instance.changeCanvasRelative(nbasket.ToString(), 4);
        if (nbasket >= baskets.Length)
        {
            GameManager.instance.Finish();
        }
        else
        {
            baskets[nbasket].SetActive(true);
        }
    }
    public void DeleteBasket()
    {
        if (nbasket >= 1)
            baskets[nbasket - 1].SetActive(false);
    }

}

