using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    [SerializeField] private float speed = 3f;
    private Vector2 lastPosition;

    [SerializeField] private GameObject explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    private void FixedUpdate()
    {
        float moveY = Input.GetAxisRaw("Vertical");
        lastPosition = transform.position;

        if (moveY != 0 && Input.GetButton("Vertical"))
        {
            if (CheckBoundaries(moveY))
            {
                rigidBody2D.velocity = new Vector2(0, moveY * speed);
            } else
            {
                rigidBody2D.velocity = Vector2.zero;
            }
        }

        else
        {
            rigidBody2D.velocity = Vector2.zero;
        }
    }


    private bool CheckBoundaries(float y)
    {
        if(y < -0.01f)
        {
            if(lastPosition.y > -4.35)
            {
                return true;
            }

        } else if(y > 0.01f)
        {
            if (lastPosition.y < 4.14)
            {
                return true;
            }

        }
        
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);

            
        }
    }
}
