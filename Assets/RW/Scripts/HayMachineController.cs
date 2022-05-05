using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HayMachineController : MonoBehaviour
{
    public int movementSpeed = 10;
    
    public int horizontalBoundary = 22;
    
    public GameObject hayBalePrefab;
    
    public Transform haySpawnPoint;
    
    public float shootInterval;
    
    private float shootTimer;

    private bool speedUp;

    void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }

    private void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        int extraSpeed = speedUp ? 2 : 1;

        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary)
        {
            transform.Translate(transform.right * (-movementSpeed * extraSpeed * Time.deltaTime));
        }
        else if(horizontalInput > 0 && transform.position.x < horizontalBoundary)
        {
            transform.Translate(transform.right * (movementSpeed * extraSpeed * Time.deltaTime));
        }
    }
    
    private void UpdateShooting() {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space)) {
            shootTimer = shootInterval;
            ShootHay();
        }

        speedUp = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    }


    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnPoint.position, Quaternion.identity);
    }
}
