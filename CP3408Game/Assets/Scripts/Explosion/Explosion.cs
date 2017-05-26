using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float explosionTime = 1f;
    private float colliderTime;
    private GameObject player;
    PlayerHealth playerHealth;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        colliderTime = explosionTime - 0.1f;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        explosionTime -= Time.deltaTime;
        if (explosionTime <= 0)
        {
            DestroyImmediate(gameObject);
        }

    }

    void OnTriggerEnter(Collider other) // Because "IsTrigger" is enabled on the sphere collider, this method can be used.
    {
        if (other.gameObject == player)
        {
            // Player is able to walk through ongoing explosion if colliderTime threshold is passed
            // Explosion is able to do damage for 0.1 seconds
            if (explosionTime >= colliderTime) {
                playerHealth.TakeDamage(20);
            }
        }
    }
}
