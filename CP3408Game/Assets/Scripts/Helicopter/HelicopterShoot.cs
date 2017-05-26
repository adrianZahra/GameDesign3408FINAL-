using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterShoot : MonoBehaviour
{
    public Rigidbody projectile;
    private float speed = 20;
    private float timeBetweenShots = 1f; // Duplicate time variable because timeBetweenShots changes over time 
    private float time;
    private PlayerHealth playerHealth;
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        time = timeBetweenShots;
    }
    
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0 && playerHealth.currentHealth > 0)
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;

            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
            
            projectile.transform.rotation = transform.rotation;

            time = timeBetweenShots;
        }
    }

    public void setAttackTime(float timeValue)
    {
        timeBetweenShots = timeValue;
    }
}
