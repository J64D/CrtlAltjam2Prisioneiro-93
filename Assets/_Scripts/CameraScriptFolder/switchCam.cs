using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCam : MonoBehaviour
{

    public GameObject camSwitch, camExchanged;

    int flag = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(flag == 0)
            {
                camSwitch.SetActive(true);
                camExchanged.SetActive(false);
                flag++;
            }
            else
            {
                camSwitch.SetActive(false);
                camExchanged.SetActive(true);
                flag--;
            }
        }
    }
}
