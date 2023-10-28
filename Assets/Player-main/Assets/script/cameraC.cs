using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class CameraC : MonoBehaviour
{

    [SerializeField] Transform FollowTarget;
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] float distance = 5;
    float rotationY;
    float rotationX;
    [SerializeField] float minVerticalAngle = -45;
    [SerializeField] float maxVerticalAngle = 45;
    [SerializeField] Vector2 framingOffset;
    [SerializeField] bool invertX;
    [SerializeField] bool invertY;

    float invertXVal;
    float invertYVal;
    private void Start()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        invertXVal = (invertX) ? -1 : 1;
        invertYVal = (invertY) ? -1 : 1;
        rotationX += Input.GetAxis("Mouse Y") * invertXVal * rotationSpeed; ;
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);

        rotationY += Input.GetAxis("Mouse X") * invertYVal * rotationSpeed; ;
        var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);

        var focusPostion = FollowTarget.position + new Vector3(framingOffset.x, framingOffset.y);
        transform.position = focusPostion - targetRotation * new Vector3(0, 0, distance);
        transform.rotation = targetRotation;

    }
    public Quaternion PlanarRotation => Quaternion.Euler(0, rotationY, 0);


}
