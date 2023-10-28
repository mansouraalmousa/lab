using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;


public class Move : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float rotationSpeed = 500f;

    CameraC Cameracontroller;
    UnityEngine.Quaternion targetRotation;
    CharacterController characterController;
    Animator animator;
    bool isGround = true;
    public bool jumpinput = false;
   public float jumpCooldwon = 1.0f;

    private float gravity = -9.81f;
    private float gravityMultiplier;
    private float _volicity;




    private void Awake()
    {
        Cameracontroller = Camera.main.GetComponent<CameraC>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

    }


    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");



        float moveAmount = Mathf.Clamp01(Mathf.Abs(h) + Mathf.Abs(v));

        var moveInput = (new UnityEngine.Vector3(h, 0, v)).normalized;

        var moveDir = Cameracontroller.PlanarRotation * moveInput;
        if (moveAmount > 0)
        {
            characterController.Move(moveSpeed * Time.deltaTime * moveDir);

            targetRotation = UnityEngine.Quaternion.LookRotation(moveDir);

        }
        transform.rotation = UnityEngine.Quaternion.RotateTowards(transform.rotation, targetRotation,
        rotationSpeed * Time.deltaTime);

        animator.SetFloat("moveAmount", moveAmount);

        if (!characterController.isGrounded)
        {
            characterController.Move(UnityEngine.Vector3.down);

        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpinput)
            {
                jumpinput = true;
                animator.SetTrigger("jump");
            }
        }


    }


    //IEnumerator resetjumpCooldwon()
    //{
    //    yield return new WaitForSeconds(jumpCooldwon);
    //    jumpinput = true;

    //}
    //
}