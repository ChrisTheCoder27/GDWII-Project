using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health;
    private float healthOld;
    // Start is called before the first frame update
    void Start()
    {
        healthOld = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        healthOld = health;
    }
}
