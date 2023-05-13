using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    private CharacterController controller;
    private Animator anim;

    public float speed, gravity, rotationSpeed;

    private float rotation = 94.654f;

    private Vector3 moveDirection;

    private bool LockMouse = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        if (!LockMouse)
        {
            return;
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection = Vector3.forward * speed;
                anim.SetInteger("transition", 1);
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
                moveDirection = Vector3.zero;
                anim.SetInteger("transition", 0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                moveDirection = Vector3.back * speed;
                anim.SetInteger("transition", 1);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                moveDirection = Vector3.zero;
                anim.SetInteger("transition", 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                moveDirection = Vector3.right * speed;
                anim.SetInteger("transition", 1);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                moveDirection = Vector3.zero;
                anim.SetInteger("transition", 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = Vector3.left * speed;
                anim.SetInteger("transition", 1);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                moveDirection = Vector3.zero;
                anim.SetInteger("transition", 0);
            }
        }

        rotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotation, 0);

        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * Time.deltaTime);
        
    }

    
}
