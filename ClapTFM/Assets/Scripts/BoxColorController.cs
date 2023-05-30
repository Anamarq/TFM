using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxColorController : MonoBehaviour
{
    private bool set = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!set)
        {
            if (other.tag.Equals("shelfBlue") && gameObject.name == "BlueBox")
            {
                ++ColorsShelfPoints.instance.pointsSet;
                //GetComponentInChildren<FadeOut>().StartFading();
                set = true;
            }
            //else if (other.tag.Equals("shelfGreen") && gameObject.name == "GreenBox")
            //{
            //    ++ColorsShelfPoints.instance.pointsSet;
            //    set = true;
            //}
            else if (other.tag.Equals("shelfRed") && gameObject.name == "RedBox")
            {
                ++ColorsShelfPoints.instance.pointsSet;
                //GetComponentInChildren<FadeOut>().StartFading();
                set = true;
            }
            //else if (other.tag.Equals("shelfYellow") && gameObject.name == "YellowBox")
            //{
            //    ++ColorsShelfPoints.instance.pointsSet;
            //    set = true;
            //}
            if (ColorsShelfPoints.instance.pointsSet >= 2)
            {
               
                ColorsShelfPoints.instance.pointsSet = 0;
                ColorsShelfPoints.instance.NewGlasses();
            }
        }
        if(other.tag.Equals("floor"))
        {
            ColorsShelfPoints.instance.pointsSet = 0;
            ColorsShelfPoints.instance.Reset();
        }
    }
}
