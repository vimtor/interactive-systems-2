using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public bool canSpawn = true; // 1
    
    public GameObject sheepPrefab; // 2
    
    public List<Transform> sheepSpawnPositions = new List<Transform>(); // 3
    
    public float timeBetweenSpawns;
    
    public float minimumSpawnTime;
    
    public float decreaseSpawnTime;
    
    private List<GameObject> sheepList = new List<GameObject>(); // 5
    
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        
        EventManager.GameFinished.AddListener(HandleGameFinish);
    }

    void Update()
    {
        if (timeBetweenSpawns > minimumSpawnTime)
        {
            timeBetweenSpawns -= decreaseSpawnTime;
        }
    }

    private void HandleGameFinish(int score)
    {
        canSpawn = false;
    }
    
    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPositions [Random.Range(0, sheepSpawnPositions.Count)].position;
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation); 
        sheepList.Add(sheep);
        sheep.GetComponent<Sheep>().SetSpawner(this);
    }
    
    private IEnumerator SpawnRoutine() // 1
    {
        while (canSpawn) // 2
        {
            SpawnSheep(); // 3
            yield return new WaitForSeconds(timeBetweenSpawns); // 4
        }
    }
    
    public void RemoveSheepFromList (GameObject sheep)
    {
        sheepList.Remove(sheep);
    }


}
