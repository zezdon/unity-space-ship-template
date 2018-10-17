using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrGreenSphere : MonoBehaviour {

    //Transform trans, _plrTrans, _redTrans;

    //public float vectMult = 2f;

	void Start ()
    {
        //trans = GetComponent<Transform>();
        //_plrTrans = GameObject.Find("PlayerShip").GetComponent<Transform>();
        //_redTrans = GameObject.Find("redSphere").GetComponent<Transform>();
	}
		
	void Update ()
    {
        //trans.position = _plrTrans.position + (_plrTrans.forward * vectMult);
        //Vector3 nuVect = (_redTrans.position - _plrTrans.position).normalized;

        //trans.position = _plrTrans.position + (nuVect*vectMult);
    }
}
