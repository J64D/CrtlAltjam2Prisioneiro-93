using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class switchCam : MonoBehaviour
{

    public CinemachineVirtualCamera currentCam;
    //public GameObject camSwitch, camExchanged;

    // int flag = 0;

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         if(flag == 0)
    //         {
    //             camSwitch.SetActive(true);
    //             camExchanged.SetActive(false);
    //             flag++;
    //         }
    //         else
    //         {
    //             camSwitch.SetActive(false);
    //             camExchanged.SetActive(true);
    //             flag--;
    //         }
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentCam.Priority = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentCam.Priority = 0;
        }    
    }
    

}
