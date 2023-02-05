using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private float width;
    [SerializeField] private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        
        width = spriteRenderer.size.x;

        rigidBody2D.velocity = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -10 * width)
        {
            transform.position = new Vector3(transform.position.x + 20 * width, transform.position.y, transform.position.z);
        }
    }
}
