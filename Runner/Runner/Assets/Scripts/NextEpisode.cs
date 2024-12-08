using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextEpisode : MonoBehaviour
{
    public PlayerController controller;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z > transform.position.z)
        {
            controller.PlayNextEpisode();
            Destroy(gameObject);
        }
    }
}
