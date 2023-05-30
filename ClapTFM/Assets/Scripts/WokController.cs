using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WokController : MonoBehaviour
{
    //private bool delete;
    // Start is called before the first frame update
    void Start()
    {
        //delete = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("stove"))
        {
            // delete = true;
            ChangeWok.instance.NewWok();
            GetComponentInParent<FadeOut>().StartFading();
            Destroy(gameObject);
        }
        if(other.tag.Equals("floor"))
        {
            ChangeWok.instance.Reset();
        }
    }
}
