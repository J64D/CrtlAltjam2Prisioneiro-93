using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, MoveControls.IMoveMapActions
{
    public Vector2 MovementValue { get; private set; }

    // public event Action MoveEvent;

    private MoveControls controls;

    void Start()
    {
        controls = new MoveControls();
        controls.MoveMap.SetCallbacks(this);
        controls.MoveMap.Enable();
    }

    private void OnDestroy() 
    {
        controls.MoveMap.Disable();
    }

    public void OnMoveAction(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }
}
