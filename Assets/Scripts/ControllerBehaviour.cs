using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerBehaviour : MonoBehaviour
{
    //Initialisation des variables speed, MaxSpeed, Ground & JumpForce à reusiner
    [SerializeField] private float speed = 7; //notre variable de vitesse sans ça, le personnage ne peut pas se déplacer
    [SerializeField] private float maxSpeed = 50; //notre variable de limite de vitesse sinon la vitesse se cumulera à l'infini
    [SerializeField] private LayerMask Ground; //notre variable de calque de sol, pour identifier le sol
    [SerializeField] private float JumpForce = 3.5f; //notre variable de force de saut

    private Controls controls;
    private Vector2 direction;
    private Rigidbody2D myRB;

    private Animator MyAnim;
    private SpriteRenderer myRenderer;


    public bool IsOnGround = false;

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
        myRenderer = GetComponent<SpriteRenderer>();
        MyAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        var playerDirection = new Vector2(direction.x, 0);
        direction.y = 0;
        if (myRB.velocity.sqrMagnitude < maxSpeed)
            myRB.AddForce(direction * speed);
        var isRunning = direction.x != 0;
        var isJumping = myRB.velocity.y != 0;
        MyAnim.SetBool("IsRunning", isRunning);
        MyAnim.SetBool("IsJumping", isJumping);
        
        if(direction.x < 0)
        {
            myRenderer.flipX = true;
        }
        else if (direction.x > 0)
        {
            myRenderer.flipX = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
    }
}
