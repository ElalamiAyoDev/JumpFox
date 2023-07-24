using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravity;
    private CharacterController characterController;
    private Vector3 moveDir;
    private Animator animator;
    private bool isWalking;

    public void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveDir = new Vector3(Input.GetAxis("Horizontal") * moveSpeed,moveDir.y, Input.GetAxis("Vertical") * moveSpeed);
        
        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
            moveDir.y = jumpForce ;

        moveDir.y -= gravity * Time.deltaTime;

        if (moveDir.x != 0 || moveDir.z != 0)
        {
            isWalking = true;
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(new Vector3(moveDir.x, 0, moveDir.z)), 0.15f);
        }else
            isWalking = false;

        animator.SetBool("isWalking", isWalking);

        characterController.Move(moveDir * Time.deltaTime);
    }
}
