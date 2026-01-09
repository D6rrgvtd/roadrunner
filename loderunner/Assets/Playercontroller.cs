using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Scripting.APIUpdating;

public class Playercontroller : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    public Animation move;
    public Animation stop;
    private float speed;
    void Start()
    {
    rigidbody2D = GetComponent<Rigidbody2D>();    
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            speed = -5.0f;
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speed = 5.0f;
          
        }
        else
        {
            speed = 0.0f;
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rigidbody2D.linearVelocity;
        velocity.x = speed;

        rigidbody2D.linearVelocity = velocity;
    }
}
