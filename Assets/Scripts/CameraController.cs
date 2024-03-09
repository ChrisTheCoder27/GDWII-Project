using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = new Vector3 (0, 1, -10);
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}