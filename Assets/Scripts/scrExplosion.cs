using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrExplosion : MonoBehaviour {

    // STATS
    public float size, duration;
    float growthRate;

    //REFERENCE
    public Transform modelTrans;
    SphereCollider col;

    private void Awake()
    {
        modelTrans = GetComponent<Transform>().Find("ExplosionModel");
        col = GetComponent<SphereCollider>();
    }

    void Start ()
    {
        growthRate = size / duration;
        col.radius = size / 2;

        Destroy(gameObject, duration);
	}
	
	void Update ()
    {
        modelTrans.localScale = Vector3.Lerp(modelTrans.localScale, Vector3.one * size, growthRate * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Hit Player");
        }
        else if (other.gameObject.tag == "Enemy")
        {
            print("Hit Enemy");
        }
    }
}
