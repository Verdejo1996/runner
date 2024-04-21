using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect;
    private Rigidbody rb;
    public static float powerUpVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.AddForce(new Vector3(-powerUpVelocity, 0, 0), ForceMode.Force);
        OutOfBounds();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp(other);
        }
    }

    void PickUp(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);


        Controller_Instantiator.respawningTimer = 30f;

        
        Destroy(gameObject);
    }

    public void OutOfBounds()
    {
        if (this.transform.position.x <= -15)
        {
            Destroy(this.gameObject);
        }
    }
}
