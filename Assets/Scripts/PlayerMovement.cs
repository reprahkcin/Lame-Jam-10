using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

    bool alive = true;



    public Rigidbody rb;

    public float hMoveScale = 1f;

    void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * GameManager.instance.playerSpeed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * Input.GetAxis("Horizontal") * GameManager.instance.playerSpeed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + forwardMove);
        rb.MovePosition(rb.position + horizontalMove * hMoveScale);

        // Vertical input affects GameManager.instance.playerSpeed
        GameManager.instance.playerSpeed += Input.GetAxis("Vertical") * Time.fixedDeltaTime;

    }


    void Update()
    {
        // If player falls below -10, they die
        if (transform.position.y < -10)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
