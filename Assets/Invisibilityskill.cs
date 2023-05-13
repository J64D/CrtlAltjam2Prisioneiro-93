using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Invisibilityskill : MonoBehaviour
{
    //[SerializeField] Material material; 
    private CombatControls _myInput;
    private bool _isInvisible = false;
    public Renderer rend;
    public GameObject rendAlpha;

    private void Awake()
    {
        _myInput = new CombatControls();
        _myInput.Enable();
        _myInput.CombatMap.Camuflagem.performed += ctx => InvisibleActive();
        
    }

    void Start()
    {
        //material = GetComponentInChildren<Material>();
        _isInvisible = false;
    }

    void Update()
    {
    //  if(Input.GetKeyDown('E')){
    //     invisible();
    //  }  
    //  if(Input.GetKeyUp("E")){
    //     StopInvisible();
    //  }
    }

    public void InvisibleActive()
    {
       // Debug.Log("hkjhkhhh");
        if (_isInvisible)
        {
            //rend= GetComponentInChilren<Renderer>();
            rend = GetComponentInChildren<Renderer>();
            rend.enabled=true;
            rendAlpha.SetActive(false);
             //Debug.Log(rend.material.color);
            _isInvisible = false;
        }
        else 
        {
            //rend= GetComponent<Renderer>();
            rend = GetComponentInChildren<Renderer>();
            rend.enabled=false;
            rendAlpha.SetActive(true);
             //Debug.Log(rend.material.color);
            _isInvisible = true;
        }
    }

    // void invisible(){
    //     rend= GetComponent<Renderer>();
    //     rend.enabled=false;
    // }
     
    // void StopInvisible(){
    //     rend= GetComponent<Renderer>();
    //     rend.enabled=true;
    // }
}
