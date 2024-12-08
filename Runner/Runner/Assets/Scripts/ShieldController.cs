using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{

    public Transform ground;
    public PlayerController playerController;

    Vector3 offset;
    void Start()
    {
        offset = ground.position - transform.position;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ground.position - offset;
    }
}

