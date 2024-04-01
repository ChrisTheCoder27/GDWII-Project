using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossEnemy : MonoBehaviour
{
    GameObject player;
    public float speed;
    private float setSpeed;

    private bool playerNear;

    void Start()
    {
        setSpeed = speed;
    }

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
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