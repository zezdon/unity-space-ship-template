using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCamera : MonoBehaviour {

    // STATS
    public float moveSpeed = 14.33f;
    public float lookSpeed = 15f;
    public float followDist = 12.91f;
    public float aboveDist = 7.1f;
    public float lookAboveAwt = 2.42f;

    // REFERENCE
    public Transform trans;
    public Transform _plrTrans;

    // OTHER
    /// <summary>Position the camera moves toward.</summary>
    Vector3 targetPos;
    /// <summary>Position the camera looks toward.</summary>
    Vector3 lookAtPos;

    public float distToPlr;

    void Awake()
    {
        trans = GetComponent<Transform>();
        _plrTrans = GameObject.Find("PlayerShip").GetComponent<Transform>();
    }

    void Start ()
    {
        targetPos = _plrTrans.position + (-_plrTrans.forward * followDist) + (_plrTrans.up * aboveDist);
        trans.position = targetPos;

        lookAtPos = _plrTrans.position + (_plrTrans.up * lookAboveAwt);
        trans.LookAt(lookAtPos);
	}
	
	void Update () {
		
	}

    private void LateUpdate()
    {
        targetPos = _plrTrans.position + (-_plrTrans.forward * followDist) + (_plrTrans.up * aboveDist);
        trans.position = Vector3.Lerp(trans.position, targetPos, moveSpeed * Time.deltaTime);
        distToPlr = Vector3.Distance(trans.position, _plrTrans.position);

        lookAtPos = _plrTrans.position + (_plrTrans.up * lookAboveAwt);
        trans.LookAt(Vector3.Lerp(trans.position + (trans.forward * distToPlr),lookAtPos, lookSpeed * Time.deltaTime));
    }
}
