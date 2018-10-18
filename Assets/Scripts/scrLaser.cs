using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrLaser : MonoBehaviour {

    // STATS
    float laserLifeSpan = 2f;

	void Start ()
    {
        Destroy(gameObject, laserLifeSpan);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
    }
}
