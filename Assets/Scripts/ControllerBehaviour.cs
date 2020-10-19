using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;

    private Controls controls;
    private Vector2 direction;

    private void OnEnable()
    {
        controls = new Controls();
        controls.Enable();
        controls.Main.Move.performed += OnMovePerfomed;
        controls.Main.Move.canceled += OnMoveCanceled;
    }

    private void Move_performed(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void OnMovePerfomed(InputAction.CallbackContext obj)
    {
        direction = obj.ReadValue<Vector2>();
        Debug.Log(direction);
    }

    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {
        direction = Vector2.zero;
    }

    private void FixedUpdate()
    {
        var myRigidBody = GetComponent<Rigidbody2D>();
        direction.y = 0;
        if (myRigidBody.velocity.sqrMagnitude < maxSpeed)
            myRigidBody.AddForce(direction * speed);

    }
}
