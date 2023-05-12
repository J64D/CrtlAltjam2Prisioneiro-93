using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject holdObject;
    private Collider interactiveObject;
    private CombatControls _myInput;

    private void Awake()
    {
        _myInput = new CombatControls();
        _myInput.Enable();
        _myInput.CombatMap.Interact.performed += ctx => ToInteract();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ToInteract()
    {
        if (interactiveObject.CompareTag("Arremesaveis"))
        {
            holdObject = interactiveObject.gameObject;
            interactiveObject.transform.position = new Vector3(transform.position.x,
             transform.position.y, transform.position.z + 1);
            interactiveObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        interactiveObject = other;
    }
}
