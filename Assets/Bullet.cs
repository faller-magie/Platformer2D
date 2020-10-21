using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D myRB;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        var playerGameObject = GameObject.FindWithTag("Player");
        var playerController = playerGameObject.GetComponent<ControllerBehaviour>();

        
    }

    private void FixedUpdate()
    {
        myRB.velocity = new Vector2
        {
            x = speed * Time.fixedDeltaTime,
            y = 0; 
        }
    }
 }
