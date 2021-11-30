using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RecapEvents : MonoBehaviour
{
    public static RecapEvents current;

    private void Awake() {
        current = this;   
    }


    public event Action onTargetHit;
    public void TargetHit() {
        if(onTargetHit != null) {
            onTargetHit();
        }
    }



 
 

}