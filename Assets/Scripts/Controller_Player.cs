﻿using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    private Rigidbody rb;
    public static float jumpForce = 10;
    private float initialSize;
    private int i = 0;
    private bool floored;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialSize = rb.transform.localScale.y;
    }

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        Jump();
        DoubleJump();
        Duck();
    }

    private void Jump()
    {
        if (floored)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    //Metodo que agrega un doble salto cuando estemos en el aire al presionar la tecla espacio.
    private void DoubleJump()
    {
        if (!floored)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    private void Duck()
    {
        if (floored)
        {
            if (Input.GetKey(KeyCode.S))
            {
                if (i == 0)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, rb.transform.localScale.y / 2, rb.transform.localScale.z);
                    i++;
                }
            }
            else
            {
                if (rb.transform.localScale.y != initialSize)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, initialSize, rb.transform.localScale.z);
                    i = 0;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.AddForce(new Vector3(0, -jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Controller_Hud.gameOver = true;
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = false;
        }
    }
}
