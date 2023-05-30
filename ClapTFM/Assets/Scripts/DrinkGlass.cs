using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkGlass : MonoBehaviour
{
   // public Transform camera;
    public Transform overCameraRig;
    public static DrinkGlass instance;
    public int nDrink;
    public GameObject[] drinks;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        nDrink = 0;
       // UIManager.instance.numGlasses.text = nwok.ToString();
        for (int i = 1; i < drinks.Length; i++)
        {
            drinks[i].SetActive(false);
        }
        drinks[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(drinks[nDrink].transform.position, overCameraRig.position);
        if (dist < 0.2)
        {
            AudioManager.instance.PlaySFX(4);
            NewGlass();
        }
    }
    public void NewGlass()
    {
        ++nDrink;
        ChangeCanvas.instance.changeCanvasRelative(nDrink.ToString(), 2);
        if (nDrink >= drinks.Length)
        {
            GameManager.instance.Finish();
        }
        else
        {
            drinks[nDrink - 1].SetActive(false);
           
            drinks[nDrink].SetActive(true);
        }
    }
}
