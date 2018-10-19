using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrLaser : MonoBehaviour {

    // STATS
    public float laserLifeSpan = 2f;

    // REFERENCE
    public GameObject _explosionPrefab;

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
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
    }
}
