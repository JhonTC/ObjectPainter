using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float sensitivity;

    [SerializeField]
    private Transform cameraRigJoint;

    private float lowCameraAngle = 4f;
    private float highCameraAngle = 80f;

    public void Move(Vector2 dragDirection)
    {
        transform.Rotate(Vector3.up * dragDirection.x * Time.deltaTime * sensitivity);

        if (cameraRigJoint != null)
        {
            Vector3 newChildRotation = cameraRigJoint.rotation.eulerAngles + Vector3.left * dragDirection.y * Time.deltaTime * sensitivity;
            newChildRotation.x = Mathf.Clamp(newChildRotation.x, lowCameraAngle, highCameraAngle);
            cameraRigJoint.rotation = Quaternion.Euler(newChildRotation);
        }
    }
}
