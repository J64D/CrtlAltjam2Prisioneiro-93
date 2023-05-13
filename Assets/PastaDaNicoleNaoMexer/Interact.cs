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
    public GameObject[] otherMesh;
    public GameObject holdObject;
    public bool newForm;
    public bool followForm;
    private Collider interactiveObject;
    private Collider interactiveCreature;
    private CombatControls _myInput;

    public Renderer _renderer;
    private void Awake()
    {
        _myInput = new CombatControls();
        _myInput.Enable();
        _myInput.CombatMap.Interact.performed += ctx => ToInteract();
    }

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
        newForm = false;
        followForm = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Selected();
        if (newForm)
        {
            SetNewForm();
        }
        if (followForm)
        {
            //interactiveObject.GetComponent<Rigidbody>().velocity = this.gameObject.GetComponent<Rigidbody>().velocity;
        }
        
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
              
                newForm = true;
                // interactiveObject.transform.localPosition = this.gameObject.transform.localPosition;
                // interactiveObject.transform.localRotation = this.gameObject.transform.localRotation;
                //newForm = interactiveObject.gameObject.GetComponent<Renderer>();
                //Destroy(interactiveObject.gameObject, 2f);
                //_renderer = newForm;
                //interactiveObject.transform.SetParent(transform);
            }
        }
       
    }

    private void SetNewForm()
    {
        followForm = true;
        _renderer.enabled = false;
        interactiveObject.transform.position = this.gameObject.transform.position;
        interactiveObject.transform.rotation = this.gameObject.transform.rotation;

        interactiveObject.transform.SetParent(transform);
        interactiveObject.GetComponent<Renderer>().material = _renderer.material;
        interactiveObject.tag = "Player";
        interactiveObject.GetComponent<MovePlaceHolder>().enabled = true;
        newForm = false;
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
