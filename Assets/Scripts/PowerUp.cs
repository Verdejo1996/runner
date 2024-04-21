using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Rigidbody rb;
    public static float powerUpVelocity;
    public GameObject pickUpEffect;

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
        Instantiate(pickUpEffect, transform.position, transform.rotation);


        Controller_Instantiator.respawningTimer = UnityEngine.Random.Range(19, 20); ;

        Destroy(this.gameObject);
    }

    public void OutOfBounds()
    {
        if (this.transform.position.x <= -15)
        {
            Destroy(this.gameObject);
        }
    }

}
