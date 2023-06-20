using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public CharacterController characterController;
    public float moveSpeed;
    public float jumpForce;
    public float gravity;
    private Vector3 moveDir;

    void Update()
    {
        moveDir = new Vector3(Input.GetAxis("Horizontal") * moveSpeed,moveDir.y, Input.GetAxis("Vertical") * moveSpeed);
        
        if (Input.GetButtonDown("Jump"))
            moveDir.y = jumpForce ;

        moveDir.y -= gravity * Time.deltaTime;

        if (moveDir.x != 0 || moveDir.z != 0)
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(new Vector3(moveDir.x, 0, moveDir.z)), 0.15f);

        characterController.Move(moveDir * Time.deltaTime);
    }
}
