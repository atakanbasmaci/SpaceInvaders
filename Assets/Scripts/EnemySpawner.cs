using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float duration = 3f;
    private float counter = 0f;
    
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if(counter < duration)
            counter += Time.deltaTime;
        
        else
            SpawnEnemy();

        if(duration > 1f)
        {
            duration -= Time.deltaTime / 100;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = new Vector3(transform.position.x, Random.Range(-3.61f, 3.61f), transform.position.z);

        Instantiate(enemy, position, Quaternion.identity);
        
        counter = 0;
    }
}
