using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    public float movementSpeed;
    public float rotationLockDown, rotationLockUp;

    float forwardMovement, sideMovement;

    float horizontalRotation, verticalRotation;
    float mouseScroll;

    Transform camera;

    // Use this for initialization
    void Start()
    {
        camera = transform.FindChild("Main Camera");
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Screen.lockCursor = true;

            horizontalRotation += Input.GetAxis("Mouse X");
            verticalRotation += Input.GetAxis("Mouse Y");

            mouseScroll = Input.GetAxis("Mouse ScrollWheel");

            if (verticalRotation < -rotationLockDown)
                verticalRotation = -rotationLockDown;

            else if (verticalRotation > rotationLockUp)
                verticalRotation = rotationLockUp;
        }

        else
            Screen.lockCursor = false;

        forwardMovement = Input.GetAxis("Vertical");
        sideMovement = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.forward * forwardMovement * movementSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * sideMovement * movementSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * mouseScroll * movementSpeed * Time.deltaTime);

        Debug.Log(mouseScroll);

        camera.localEulerAngles = new Vector3(verticalRotation, 0, 0);
        transform.localEulerAngles = new Vector3(0, horizontalRotation, 0);

        
    }
}
