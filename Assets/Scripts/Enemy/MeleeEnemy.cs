using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MeleeEnemy : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    GameObject player;
    private Transform currentPoint;
    public float speed;
    private float setSpeed;

    private bool playerNear;

    void Start()
    {
        currentPoint = pointB.transform;
        setSpeed = speed;
    }

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (currentPoint == pointB.transform && !playerNear)
        {
            speed = setSpeed;
            transform.position += Vector3.right * Time.deltaTime * speed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (currentPoint == pointA.transform && !playerNear)
        {
            speed = setSpeed;
            transform.position += Vector3.left * Time.deltaTime * speed;
            transform.rotation = Quaternion.Euler(0, 180, 0);
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
            playerNear = true;
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            Vector3 scale = transform.localScale;
            if (player.transform.position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            transform.localScale = scale;
        }
        else
        {
            playerNear = false;
        }
    }
}
