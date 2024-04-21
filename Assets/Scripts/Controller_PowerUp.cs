using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_PowerUp : MonoBehaviour
{
    public List<GameObject> powerups;
    public GameObject instantiatePos;
    public static float respawningTimer;


    void Start()
    {
        PowerUp.powerUpVelocity = 1;
    }

    void Update()
    {
        SpawnPowerUp();
        ChangeVelocity();
    }

    private void ChangeVelocity()
    {
        PowerUp.powerUpVelocity = Mathf.SmoothStep(1f, 20f, 40f);
    }

    private void SpawnPowerUp()
    {

        respawningTimer -= Time.deltaTime;

        if (respawningTimer <= 0)
        {
            Instantiate(powerups[UnityEngine.Random.Range(0, powerups.Count)], instantiatePos.transform);
            respawningTimer = UnityEngine.Random.Range(2, 20);
        }

    }
}
