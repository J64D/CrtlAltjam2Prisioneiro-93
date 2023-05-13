using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTravelling : MonoBehaviour
{
    [SerializeField] private Transform tp;

    [SerializeField] private GameObject player;

    Vector3 newLocation;
    bool teleport = false;

    private void Update()
    {
        if (teleport)
        {
            player.transform.localPosition = newLocation;
            teleport = false;
            print("chego aqui tbm");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        print("colidiu");
        if(other.gameObject.tag == "Player")
        {
            print("Chegou Aqui");
            print(player.transform.position);
            newLocation = new Vector3(tp.transform.position.x, tp.transform.position.y, tp.transform.position.z);
            print(player.transform.position);
            teleport = true;

            
        }
    }


}
