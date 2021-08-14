using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    int health = 100;
    private Rigidbody2D myBody;
    public Transform mouth;
    private Animator anim;
    [SerializeField]
    private bool isInfected = false;
    [SerializeField]
    GameObject coughObject;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        speed = 5;
        anim = GetComponent<Animator>();
    }

    public void bulletHit(int damage)
    {
        
        health -= damage;
        if (health < 0)
        {
            anim.SetTrigger("dead");
            Destroy(gameObject,0.5f);
        }
        else
            transform.Rotate(0f, 180f, 0f);
    }
    public void infected()
    {
        
        if (!isInfected)
        {
            isInfected = true;
            Instantiate(coughObject, mouth.position, mouth.rotation);
            StartCoroutine(Cough());
        }
    }
    void Start()
    {
        if(isInfected)
        StartCoroutine(Cough());
    }

    public IEnumerator Cough()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(coughObject, mouth.position, mouth.rotation);
        
        yield return StartCoroutine(Cough());
    }
    // Update is called once per frame
    void Update()
    {
        myBody.velocity = new Vector2(transform.right.x * speed, myBody.velocity.y); ;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rotator"))
        {
            myBody.transform.Rotate(0f, 180f, 0f);
        }
     }
    
    
}
