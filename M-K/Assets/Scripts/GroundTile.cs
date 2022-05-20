using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();    
        SpawnObstacle();
        SpawnCoins();
        SpawnBananas();
    }

    private void OnTriggerExit (Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);    
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2,5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public GameObject coinPrefab;

    void SpawnCoins()
    {
        int coinsToSpawn = 2;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }
    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if(point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }

    public GameObject bananaPrefab;

    void SpawnBananas()
    {
        int bananasToSpawn = 1;
        for (int i = 0; i < bananasToSpawn; i++)
        {
            GameObject temp = Instantiate(bananaPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }
}
