using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] LayerMask layerInteract;
    [SerializeField] Transform interactPos;
    [SerializeField] float radius = 2f;
    [SerializeField] Material ArrmessavelSelectedMaterial;
    [SerializeField] Material CreatureSelectedMaterial;
    [SerializeField] Material InteractSelectedMaterial;
    [SerializeField] Material DefaultMaterial;
    public GameObject holdObject;
    public SkinnedMeshRenderer newForm;
    private Collider interactiveObject;
    private Collider interactiveCreature;
    private CombatControls _myInput;

    public SkinnedMeshRenderer _renderer;
    private void Awake()
    {
        _myInput = new CombatControls();
        _myInput.Enable();
        _myInput.CombatMap.Interact.performed += ctx => ToInteract();
    }

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponentInChildren<SkinnedMeshRenderer>();
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
            if (interactiveObject.CompareTag("Creatura"))
            {
                //newForm = new MeshRenderer();
                newForm = interactiveObject.gameObject.GetComponent<SkinnedMeshRenderer>();
                Destroy(interactiveObject.gameObject, 2f);
                _renderer = newForm;
                //interactiveObject.transform.SetParent(transform);
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
                ArremessavelSeletion(selection);
            }
            if (selection.CompareTag("Creatura"))
            {
                CreaturaSeletion(selection);
            }
            if (selection.CompareTag("Interativo"))
            {
                InterativoSeletion(selection);
            }
        }
    }

    private void ArremessavelSeletion(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            DefaultMaterial = selectionRenderer.material;
            selectionRenderer.material = ArrmessavelSelectedMaterial;
        }
        interactiveObject = selection.GetComponent<Collider>();
    }

    private void CreaturaSeletion(Transform selection)
    {
        //absorver
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            DefaultMaterial = selectionRenderer.material;
            selectionRenderer.material = CreatureSelectedMaterial;
        }
        interactiveObject = selection.GetComponent<Collider>();
    }

    private void InterativoSeletion(Transform selection)
    {
        //interagir
    }


    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawSphere(interactPos.position, radius);
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other != null)
    //     {
    //        interactiveObject = other;      
    //     }
    // }
}
