using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{



    public float speed = 5f;

    public Rigidbody rb;

    public float hMoveScale = 1f;

    void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + forwardMove);
        rb.MovePosition(rb.position + horizontalMove * hMoveScale);
    }


}
