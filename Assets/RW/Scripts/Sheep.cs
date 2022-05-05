using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed;
    public float gotHayDestroyDelay;
    public float dropDestroyDelay = 4; // 1
    private Collider myCollider; // 2
    private Rigidbody myRigidbody;
    private bool _hitByHay;
    private SheepSpawner sheepSpawner;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = gameObject.GetComponent<Collider>();
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (runSpeed * Time.deltaTime));
    }
    
    private void HitByHay()
    {
        sheepSpawner.RemoveSheepFromList (gameObject);
        _hitByHay = true; // 1
        runSpeed = 0; // 2
        EventManager.SheepHaystacked.Invoke();
        Destroy(gameObject, gotHayDestroyDelay); // 3
    }
    
    private void HitByPlayer()
    {
        sheepSpawner.RemoveSheepFromList (gameObject);
        EventManager.PlayerHitted.Invoke();
        Destroy(gameObject, gotHayDestroyDelay); // 3
    }

    private void Drop()
    {
        sheepSpawner.RemoveSheepFromList (gameObject);
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay );
    }
    
    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }

    private void OnTriggerEnter(Collider other) // 1
    {
        if (other.CompareTag("Hay") && !_hitByHay) // 2
        {
            Destroy(other.gameObject); // 3
            HitByHay(); // 4
        }
        else if (other.CompareTag("Player"))
        {
            HitByPlayer();
        }
        else if (other.CompareTag("DropSheep"))
        {
            Drop();
        }
    }

}
