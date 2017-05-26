using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMissle : MonoBehaviour {

    public Rigidbody explosion;
    private bool active = true;
    public float explosionTime = 2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider other)
    {
        if (active && other.gameObject != GameObject.FindGameObjectWithTag("Bomb"))
        {
            Rigidbody instantiatedProjectile = Instantiate(explosion, transform.position, transform.rotation) as Rigidbody;
            active = false; 
            Destroy(gameObject);
        }
    }

}
