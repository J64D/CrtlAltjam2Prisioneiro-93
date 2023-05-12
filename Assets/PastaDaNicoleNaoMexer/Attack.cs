using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] LayerMask _groundMask;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] GameObject _projectile;
    [SerializeField] Transform _attackPoint;
    [SerializeField] float _attackVelocity = 500f;
    [SerializeField] float _fireRate = 1f;

    private Rigidbody _myRigidbody;

    private CombatControls _myInputs;
    public GameObject _holdObject;
    private void Awake()
    {
        _myInputs = new CombatControls();
        _myInputs.Enable();    
        _myInputs.CombatMap.Attack.performed += ctx => Launch();
    }

    void Start()
    {
        _mainCamera = Camera.main;
        _myRigidbody = GetComponent<Rigidbody>();
        
        
    }

    void Update()
    {
        Aim();
        _holdObject = GetComponent<Interact>().holdObject;
    }

    private void Aim()
    {
       var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(ray, out rayLength))
        {
            Vector3 pointToLook = ray.GetPoint(rayLength);
            Debug.DrawLine(transform.position, pointToLook, Color.red);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    private void Launch()
    {
        
        // Vector3 v = new Vector3(_attackPoint.position.x, _attackPoint.position.y, _attackPoint.position.z);
        // GameObject newProjectile = Instantiate(_projectile, v, transform.rotation);
        // newProjectile.GetComponent<Rigidbody>().AddRelativeForce(
        //                                 new Vector3(0, 0, _attackVelocity)
        // );

        if (_holdObject != null)
        {
            _holdObject.transform.SetParent(null);
             _holdObject.GetComponent<Rigidbody>().AddRelativeForce(
                                new Vector3(0, 0, _attackVelocity)
            );
            _holdObject = null;
        Debug.Log("arremesar");
        }
    }
}
