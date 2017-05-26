using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockGate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (GameDataClass.dockGate && other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            GameDataClass.dockGate = false;
            GameDataClass.bunkerGate = true;
            roundManager.round += 1;
        }

    }
}
