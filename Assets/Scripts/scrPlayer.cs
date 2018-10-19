using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayer : MonoBehaviour {

    public float movSpeed = 34.4f;
    public float rotSpeed = 67.5f;
    public float jumpForce = 7f;
    public float boostForce = 13.2f;
    public float boostWait = 0.91f;
    public float boostAmt = 100f;
    public float boostDec = 1.02f;
    public float boostInc = 50f;
    public float tankHeight, tankFront;
    public float laserForce;

    public Transform trans;
    public Rigidbody rb;
    public Rigidbody _rbLaserPrefab;
    public Transform _transBarelEnd;
    public Transform _transGreenSphere;

    public bool amGrounded = false;
    public bool canBoost = true;
    public bool amBoosting = false;

    private void Awake()
    {
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        _transGreenSphere = GameObject.Find("Green Sphere").GetComponent<Transform>();
    }

    void Start () {
        canBoost = true;
        tankHeight = 1.13f;
        tankFront = 2.47f;
        laserForce = 4000f;
	}
	
	void Update ()
    {
        moveAlarms();
        _transGreenSphere.position = trans.position + (trans.forward*tankFront) + (trans.up*tankHeight);

        // POSITION /////////////////////////////////////////////////////////////////////
        Vector3 moveVect = Vector3.zero;

        /*
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))         
            moveVect.z += 1f;        
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))        
            moveVect.z -= 1f;        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))        
            moveVect.x -= 1f;        
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))        
            moveVect.x += 1f;*/

        moveVect.x = Input.GetAxis("Horizontal");
        moveVect.z = Input.GetAxis("Vertical");
        
        trans.Translate(moveVect * (movSpeed * Time.deltaTime));

        // ROTATION //////////////////////////////////////////////////////////////////////////////
        /*
        if (Input.GetKey(KeyCode.Q))        
            trans.Rotate(Vector3.up, -rotSpeed * Time.deltaTime);        
        else if (Input.GetKey(KeyCode.E))        
            trans.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
        */

        trans.Rotate(Vector3.up, Input.GetAxis("Rotate") * rotSpeed * Time.deltaTime);

        // JUMPING //////////////////////////////////////////////////////////////////////////////
        if (amGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button4)))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            canBoost = false;

            Invoke("setCanBoostTrue", boostWait);
        }

        //SHOOTING ////////////////////////////////////////////////////////////////////////////////
        //if (Input.GetAxis("Fire1") > 0f) //GetAxis return a float
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            print("Shoot!");
            //Instantiate(_rbLaserPrefab, trans);
            //Quaternion prefabRot = _rbLaserPrefab.gameObject.transform.rotation;
            Rigidbody laserInstance = Instantiate(_rbLaserPrefab, trans.position + (trans.forward * tankFront) + (trans.up * tankHeight), trans.rotation) as Rigidbody;
            laserInstance.AddForce(trans.forward * laserForce);
        }
    }

    private void FixedUpdate()
    {
        // BOOSTING /////////////////////////////////////////////////////////////////////////////
        if (canBoost && boostAmt > 0 && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button4)))
        {
            rb.AddForce(Vector3.up * boostForce, ForceMode.Acceleration);
            boostAmt -= boostDec;
            if (boostAmt < 0)
                boostAmt = 0;

            amBoosting = true;
        }
        else
            amBoosting = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            //print("enter");
            foreach (ContactPoint cp in collision.contacts)
            {
                //print(cp.normal);
                if (cp.normal.y > 0.5f)
                {
                    amGrounded = true;
                }
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        //if (collision.gameObject.layer == 9)
        //    amGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.layer == 9)
        //    amGrounded = false;
        if (collision.gameObject.layer == 9 && collision.gameObject.transform.position.y < trans.position.y)
        {
            amGrounded = false;
        }
    }
    //USER METHODS
    void moveAlarms()
    {
        if(!amBoosting && boostAmt < 100)
        {
            boostAmt += boostInc * Time.deltaTime;
            if (boostAmt > 100)
                boostAmt = 100;
        }
    }

    void setCanBoostTrue()
    {
        canBoost = true;
    }
}
