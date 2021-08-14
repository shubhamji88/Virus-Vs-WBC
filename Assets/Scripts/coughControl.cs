using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coughControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Monster enemy = collision.GetComponent<Monster>();
        
        if (enemy != null)
        {
            enemy.infected();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
