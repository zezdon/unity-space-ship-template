using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour {

    public float normalSpeed = 0.7f;

    public GameObject playerObj = null;
    public Transform playerTrans = null;
    PlayerShip playerScript = null;
    BoxCollider playerCollider = null;

	// Use this for initialization
	void Start () {
        //print(GameObject.Find("PlayerShip").name);

        playerObj = GameObject.Find("PlayerShip");
        //print(playerObj.name);

        playerTrans = GameObject.Find("PlayerShip").transform;
        //print(playerTrans.position);

        playerScript = GameObject.Find("PlayerShip").GetComponent<PlayerShip>();
        //print(playerScript.rotSpeed);

        playerCollider = GameObject.Find("PlayerShip").GetComponent<BoxCollider>();
        //print(playerCollider.center);

    }

    // Update is called once per frame
    void Update () {

        transform.Rotate(Vector3.up, normalSpeed);
	}
}
