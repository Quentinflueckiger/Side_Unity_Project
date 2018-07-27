using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Might use the 3D camera from standard assets.
public class CameraController : MonoBehaviour {

    public float PlayerCameraDistance { get; set; }
    public Transform cameraTarget;

    Camera playerCamera;
    float zoomSpeed = 25f;

    private void Start()
    {

        PlayerCameraDistance = 10f;
        playerCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        
        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            playerCamera.fieldOfView -= scroll * zoomSpeed;
            playerCamera.fieldOfView = Mathf.Clamp(playerCamera.fieldOfView, 15, 100);
        }

        transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y + PlayerCameraDistance, cameraTarget.position.z - PlayerCameraDistance);
    }
}
