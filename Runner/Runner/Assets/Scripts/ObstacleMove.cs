using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public Transform ground;
    public PlayerController playerController;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        ground = GameObject.Find("Episode1").GetComponent<Transform>();
        offset = ground.position - transform.position;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ground.position - offset;

        if (transform.position.z < -3)
        {
            playerController.AddPoint();
            Destroy(gameObject);
        }
    }

}
