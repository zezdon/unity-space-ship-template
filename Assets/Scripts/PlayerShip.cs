using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {

    public float speed = 0.4f;
    public float rotSpeed = 1f;
    public float jumpForce = 3f;

    //public Quaternion myQuaternion;

    public Transform trans;
    public Rigidbody rb;

    private void Awake()
    {
        trans = GetComponent<Transform>();
        rb.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        getInput();
    }

    public void getInput()
    {
        Vector3 moveVect = Vector3.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            //transform.Translate(0, 0, speed);
            //transform.Translate(Vector3.forward * speed);
            moveVect.z += 1f;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.RightArrow))
        {
            //transform.Translate(0, 0, -speed);
            //transform.Translate(Vector3.back * speed);
            moveVect.z -= 1f;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.Translate(speed, 0, 0);
            //transform.Translate(Vector3.left * speed);
            moveVect.x -= 1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.DownArrow))
        {
            //transform.Translate(-speed, 0, 0);
            //transform.Translate(Vector3.right * speed);
            moveVect.x += 1f;
        }

        trans.Translate(moveVect * (speed * Time.deltaTime));
        //myQuaternion = transform.rotation;

        if (Input.GetKey(KeyCode.Q))
        {
            //transform.Rotate(0, rotSpeed, 0);
            //transform.rotation = Quaternion.Euler(0, 90, 0);
            //myQuaternion = Quaternion.LookRotation(Vector3.right);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, myQuaternion, rotSpeed);
            transform.Rotate(Vector3.up, (-rotSpeed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.E))
        {
            //transform.Rotate(0, -rotSpeed, 0);
            transform.Rotate(Vector3.up, (rotSpeed * Time.deltaTime));
        }
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            rb.velocity = Vector3.up * jumpForce;
        }
    }
}

//Vector3 myVector = new Vector3(0, 0, 1);

//Transform bEnemy;

//public float normalSpeed = 0.48f;
//public float rotSpeed = 0.30f;

// Use this for initialization
//void Start () {
//bEnemy = GameObject.Find("Invader1").transform;
//transform.rotation = Quaternion.Euler(0, 90, 0);

//print(GameObject.FindGameObjectsWithTag("enemy").Length);
//print(GameObject.FindWithTag("Player").tag);

//}

// Update is called once per frame
//void Update () {
//transform.position = myVector;

//transform.Translate(myVector * normalSpeed * Time.deltaTime, Space.World);
//transform.Translate(myVector * normalSpeed * Time.deltaTime, bEnemy);

//transform.Rotate(Vector3.up, rotSpeed);
//}
