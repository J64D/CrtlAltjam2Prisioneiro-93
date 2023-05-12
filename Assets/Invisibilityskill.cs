using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibilityskill : MonoBehaviour
{
 public Renderer rend
    void Start()
    {
        
        
    }

    void Update()
    {
     if(input.GetKeyDown('E')){
        invisible();
     }  
     if(Input.GetKeyUp("E")){
        StopInvisible()
     }
    }
    void invisible(){
        rend= GetComponent<renderer>();
        rend.enabled=false;
    }
     }
    void invisible(){
        rend= GetComponent<renderer>();
        rend.enabled=true;
    }
}
