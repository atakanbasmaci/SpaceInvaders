using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    [SerializeField] private float speed = 3f;
    private int healthBar = 3;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject hit;

    private EnemyUI enemyUIScript;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = new Vector2(-speed, 0);

        enemyUIScript = GameObject.Find("Enemy Spawner").GetComponent<EnemyUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -16f)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamageWithPosition(Vector2 collisionPosition)
    {
        healthBar--;
        Instantiate(hit, collisionPosition, Quaternion.identity);

        if (healthBar <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            enemyUIScript.UpdateEnemyUI();

            Destroy(gameObject);
        }
    }
}
