using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    public Rigidbody explosion;
    public float explosionTime = 2f;
    private bool active = true;
    
    // Update is called once per frame
    void Update()
    {
        /*explosionTime -= Time.deltaTime;
        if (explosionTime <= 0)
        {
            DestroyImmediate(explosion, true);
        }*/

    }

    void OnTriggerEnter(Collider other) // Because "IsTrigger" is enabled on the sphere collider, this method can be used.
    {
        // If statement prevents explosion from occuring more than one time
        // Also prevents collision between projectiles
        // Debug.Log("YES MADE IT HERE");
        if (active && other.gameObject != GameObject.FindGameObjectWithTag("Projectile"))
        {
            Rigidbody instantiatedProjectile = Instantiate(explosion, transform.position, transform.rotation) as Rigidbody;
            active = false;
            // Destroy the missile as soon as it touches anything with a collider
        }
        Destroy(gameObject, 0);
    }
}

