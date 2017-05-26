using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterSpawner : MonoBehaviour {

    public Rigidbody helicopter;
    static bool active = false;
    Rigidbody helicopterInstance;


    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        if (!active && (roundManager.round % 5) == 0)
        {
            helicopterInstance = Instantiate(helicopter, transform.position, transform.rotation) as Rigidbody;
            active = true;
        }
        else if (active && (roundManager.round % 5) != 0)
        {
            active = false;
        }
    }
}
