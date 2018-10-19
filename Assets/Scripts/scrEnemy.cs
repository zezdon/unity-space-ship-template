using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrEnemy : MonoBehaviour {

    // STATS
    public float movSpeed = 3f;
    public float rotSpeed = 40f;
    public float visibilityDist = 15f;
    public float aimThreshold = 10f;
    public float tankHeight, tankFront, laserForce;

    // REFERENCE
    public Transform trans, _plrTrans;
    public PlayerShip _plrScript;
    public Rigidbody _rbLaserPrefab;

    // TRUTH
    public bool plrVisible;

    // OTHER
    public float distToPlr, dirToPlr, fireWait;
    public Vector3 vToPlr;

    private void Awake()
    {
        trans = GetComponent<Transform>();
        _plrTrans = GameObject.Find("PlayerShip").GetComponent<Transform>();
    }

    void Start () {
        tankHeight = 1.13f;
        tankFront = 2.47f;
        laserForce = 100f;
    }
	
	void Update () {
        //Keep track how far the player is
        distToPlr = Vector3.Distance(trans.position, _plrTrans.position);
        vToPlr = (_plrTrans.position - trans.position).normalized;
        Vector3 rotVect = new Vector3(vToPlr.x, 0f, vToPlr.z).normalized;

        dirToPlr = Quaternion.Angle(trans.rotation, Quaternion.LookRotation(vToPlr));

        if (distToPlr < visibilityDist)
        {
            plrVisible = true;

            trans.rotation = Quaternion.RotateTowards(trans.rotation, Quaternion.LookRotation(rotVect), rotSpeed * Time.deltaTime);

            if (fireWait > 0)
            {
                fireWait -= Time.deltaTime;
                if (fireWait < 0) fireWait = 0;
            }

            if( Mathf.Abs(dirToPlr) < aimThreshold && fireWait == 0)
            {
                Rigidbody laserInstance = Instantiate(_rbLaserPrefab, trans.position + (trans.forward * tankFront) + (trans.up * tankHeight), trans.rotation) as Rigidbody;
                laserInstance.AddForce(trans.forward * laserForce, ForceMode.VelocityChange);

                fireWait = Random.Range(2f, 5f);
            }
        }
        else
        {
            plrVisible = false;
        }		
	}
}
