using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Scripting.APIUpdating;

public class Playercontroller : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    private TilemapDestroyer tilemapDestroyer;

   
    private float lastDirectionX = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tilemapDestroyer = FindObjectOfType<TilemapDestroyer>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found.");
        }
        if (tilemapDestroyer == null)
        {
            Debug.LogWarning("TilemapDestroyer not found.");
        }
    }

    void Update()
    {
        Move();
        HandleTileDestruction();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            speed = -5.0f;
            lastDirectionX = -1.0f; 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speed = 5.0f;
            lastDirectionX = 1.0f; 
        }
        else
        {
            speed = 0.0f;
        }
    }

    private void HandleTileDestruction()
    {
        
        Vector3 basePosition = transform.position + new Vector3(0, -0.5f, 0);
        Vector3 destroyPosition = basePosition;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            
            destroyPosition += new Vector3(-1.0f, -0.5f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            
            destroyPosition += new Vector3(1.0f, -0.5f, 0);
        }
        else
        {
           
            return;
        }

        
        if (tilemapDestroyer != null)
        {
            tilemapDestroyer.DestroyTileAt(destroyPosition);
        }
    }

    private void FixedUpdate()
    {
        if (rb == null) return;

        Vector2 velocity = rb.linearVelocity;
        velocity.x = speed;
        rb.linearVelocity = velocity;
    }
}
