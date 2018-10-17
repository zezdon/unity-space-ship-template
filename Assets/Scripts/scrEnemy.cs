using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrEnemy : MonoBehaviour {

    public float movSpeed = 3f;

    public PlayerShip _plrScript;

    public float dt;

	void Start () {
		
	}
	
	void Update () {

        dt = Time.deltaTime;

        transform.Translate(0, 0, movSpeed * dt);
		
	}
}
