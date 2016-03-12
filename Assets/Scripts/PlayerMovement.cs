using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public int speed, jumpPower, YLimit;
    float forwardMovement, rightMovement;
    public float rotationX, rotationY;
    Rigidbody gravity;
    bool isGrounded;
    public bool shoot;
    public GameObject camera;
    public Vector3 direction = new Vector3();

    // Use this for initialization
    void Start()
    {
        gravity = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) ^ Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.W))
                forwardMovement = 1;
            else if (Input.GetKey(KeyCode.S))
                forwardMovement = -1;

        }
        else
            forwardMovement = 0;

        if (Input.GetKey(KeyCode.A) ^ Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
                rightMovement = -1;
            else if (Input.GetKey(KeyCode.D)) 
                rightMovement = 1;
        }
        else
            rightMovement = 0;

        if (Input.GetKey(KeyCode.Space) && isGrounded)
            direction.y = jumpPower;
        else if (isGrounded)
            direction.y = 0;
        else
            direction.y -= gravity.mass;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            shoot = true;
        }
        else
            shoot = false;

        rotationX += Input.GetAxis("Mouse X");
        rotationY += Input.GetAxis("Mouse Y");

        if (rotationY < -YLimit)
            rotationY = -YLimit;
        else if (rotationY > YLimit)
            rotationY = YLimit;

        transform.localEulerAngles = new Vector3(0, rotationX, 0);
        //camera.transform.localEulerAngles = new Vector3(rotationY, 0, 0);
        gravity.velocity = new Vector3(0, direction.y, 0);
        transform.Translate(Vector3.forward * forwardMovement * speed * Time.deltaTime);
        transform.Translate(Vector3.right * rightMovement * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.position.y < transform.position.y)
            isGrounded = true;
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.transform.position.y < transform.position.y)
        {
            isGrounded = false;
        }
    }
}
