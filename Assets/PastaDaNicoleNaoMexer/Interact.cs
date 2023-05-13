using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] LayerMask layerInteract;
    [SerializeField] Transform interactPos;
    [SerializeField] float radius = 2f;
    [SerializeField] Material SelectedMaterial;
    [SerializeField] Material DefaultMaterial;
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
        Selected();
        
    }

    private void ToInteract()
    {
        if (interactiveObject != null)
        {
             if (interactiveObject.CompareTag("Arremessavel"))
            {
                holdObject = interactiveObject.gameObject;
                interactiveObject.transform.position = new Vector3(transform.position.x,
                transform.position.y, transform.position.z + 1);
                interactiveObject.transform.SetParent(transform);
            }
        }
       
    }

    private void Selected()
    {
        if(interactiveObject != null)
        {
            var selectionRenderer = interactiveObject.GetComponent<Renderer>();
            selectionRenderer.material = DefaultMaterial;
            interactiveObject = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, radius))
        {
            var selection = hit.transform;
            Debug.Log(hit);
            if (selection.CompareTag("Arremessavel"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    DefaultMaterial = selectionRenderer.material;
                    selectionRenderer.material = SelectedMaterial;
                }
                interactiveObject = selection.GetComponent<Collider>();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(interactPos.position, radius);
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other != null)
    //     {
    //        interactiveObject = other;      
    //     }
    // }
}
