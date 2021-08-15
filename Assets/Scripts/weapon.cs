using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    private Animator anim;
    // Update is called once per frame
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }   
    }
    void shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        SoundManagerScript.instance.PlaySound("fire");
    }
}
