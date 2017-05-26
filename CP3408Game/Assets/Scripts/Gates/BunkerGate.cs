using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerGate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (GameDataClass.bunkerGate && other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            GameDataClass.bunkerGate = false;
            GameDataClass.dockGate = true;
            GameDataClass.round += 1;
            roundManager.round += 1;
        }

    }
}
