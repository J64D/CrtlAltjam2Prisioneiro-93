using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTravelling : MonoBehaviour
{
    [SerializeField] private Transform tp;

    [SerializeField] private GameObject player;


    private void OnTriggerEnter(Collider other)
    {
        print("colidiu");
        if(other.gameObject == player)
        {
            print("Chegou Aqui");
            player.transform.position = tp.position;
        }
    }


}
    