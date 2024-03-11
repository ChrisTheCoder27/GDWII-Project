using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    GameObject player;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
        if (player.transform.position.x <= transform.position.x + 10 && player.transform.position.x >= transform.position.x - 10 && player.transform.position.y <= transform.position.y + 2 && player.transform.position.y >= transform.position.y - 2)
        {
            speed = 0;
        }
    }
}
