using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("trash"))
        {
            ++CapPoints.instance.pointsSet;
            if(CapPoints.instance.pointsSet >= 3)
            {
                CapPoints.instance.pointsSet = 0;
                CapPoints.instance.NewCaps();
            }
        }
        if(other.tag.Equals("floor"))
        {
            CapPoints.instance.pointsSet = 0;
            CapPoints.instance.Reset();
        }
    }
}
