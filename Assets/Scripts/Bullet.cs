using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float bulletSpeed;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    // Basic idea of how the  damage taking will occur later on down there 


    //private void OnTriggerEnter2D(Collider2D other)
    //{
        //if (other.gameObject.tag == "Enemy")
        //{
            //other.GetComponent<EnemyController>().health -= damage;
        //}
        //Destroy(gameObject);
    //}
}
