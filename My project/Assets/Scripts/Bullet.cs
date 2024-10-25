using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float xSpeed;
    
    [SerializeField] float bulletSpeed = 5f;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
        myRigidbody.transform.localScale = player.transform.localScale;
    }

    private void Update()
    {
        myRigidbody.velocity = new Vector2 (xSpeed, 0);
        // myRigidbody.transform.localScale = player.transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);            
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
