using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private int bulletCounter = 7;
    [SerializeField] private float reloadTime = 2f;
    private bool reloading = false;

    [SerializeField] private Image bulletImagePrefab;
    [SerializeField] private GameObject bulletUI;

    private void Start()
    {
        BulletUI();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!reloading)
            {
                Shoot();
            }

        }

        if(bulletCounter == 0)
        {
            Reload();
        }
    }

    private void Shoot()
    {
        
        if(bulletCounter != 0)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bulletCounter--;
            BulletUI();
        } 
        
        else
        {
            reloading = true;
        }
    }

    private void Reload()
    {
        reloadTime -= Time.deltaTime * 1.5f;

        if (reloadTime <= 0)
        {
            reloading = false;
            
            bulletCounter = 7;
            reloadTime = 2f;
            BulletUI();
        }
    }

    private void BulletUI()
    {
        float posX = -385;
        float posY = 200;

        int childCount = bulletUI.transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            Destroy(bulletUI.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < bulletCounter; i++)
        {
            Image bulletImage = Instantiate(bulletImagePrefab, bulletUI.transform);
            bulletImage.rectTransform.localPosition = new Vector3(posX + i * 30, posY, 0);
        }
    }
}
