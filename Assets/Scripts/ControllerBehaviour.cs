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
    private Rigidbody2D myRB;


    public bool IsOnGround = false;
    public float JumpForce;
    public GameObject player;

    private void OnEnable()
    {
        controls = new Controls();
        controls.Enable();
        controls.Main.Move.performed += OnMovePerfomed;
        controls.Main.Move.canceled += OnMoveCanceled;
        controls.Main.Jump.performed += OnJumpPerformed;
    }

    private void OnJumpPerformed(InputAction.CallbackContext obj)
    {
        if(IsOnGround)
        {
            myRB.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            IsOnGround = false;
        }
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

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        var playerDirection = new Vector2(direction.x, 0);
        direction.y = 0;
        if (myRB.velocity.sqrMagnitude < maxSpeed)
            myRB.AddForce(direction * speed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(player.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
    }
}
