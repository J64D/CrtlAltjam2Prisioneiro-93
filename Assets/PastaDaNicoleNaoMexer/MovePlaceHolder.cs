using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlaceHolder : MonoBehaviour
{
    [SerializeField] private float _speed = 250;
    public Vector2 _playerDirection;
    private MoveControls _myInput;

    private Rigidbody _myRigidbody;
    private void Awake()
    {
        _myInput = new MoveControls();
        _myInput.Enable();
        _myInput.MoveMap.MoveAction.performed += movingCtx => 
        {
            _playerDirection = movingCtx.ReadValue<Vector2>();
        };
        _myInput.MoveMap.MoveAction.canceled += movingCtx => 
        {
            _playerDirection = Vector2.zero;
        };
    }
    
    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(_playerDirection.x, 0f, _playerDirection.y);
        _myRigidbody.velocity = move * Time.deltaTime * _speed;
        //transform.Translate(move * Time.deltaTime * _speed);
    }
}
