using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{

    //the particular enemy you want to spawn here
    public GameObject enemyPrefab;
    public List<GameObject> spawnEnemies = new List<GameObject>();
    public float spawnRadiusScalar = 15.0f;
    public int maxSpawn = 5;
    public float spawnTimeInterval = 1.0f;
    float _pvtSpawnTimeInterval = 1.0f;
    public bool usePool = true;
    float radius = 0.0f;
    void Start()
    {
        if (usePool)
            CreatePool();
        radius = gameObject.GetComponent<SphereCollider>().radius;

    }

    void Update()
    {
        _pvtSpawnTimeInterval -= Time.deltaTime;
        if (_pvtSpawnTimeInterval <= 0.0f)
        {
            if (usePool)
                SpawnEnemy();
            else
                SpawnEnemyUnoptimized();
        }

        if (!usePool)
            for (int i = 0; i < spawnEnemies.Count; i++)
            {
                if (!spawnEnemies[i].activeSelf)
                {
                    Destroy(spawnEnemies[i]);
                    spawnEnemies.RemoveAt(i);
                }
            }

    }
    void CreatePool()
    {
        enemyPrefab.transform.position = gameObject.transform.position;
        for (int i = 0; i < maxSpawn; i++)
        {
            spawnEnemies.Add(GameObject.Instantiate(enemyPrefab));
            spawnEnemies[i].SetActive(false);
        }
    }

    void SpawnEnemy()
    {
        int spawnIndex = -1;

        for (int i = 0; i < spawnEnemies.Count; i++)
        {
            if (!spawnEnemies[i].activeSelf)
                spawnIndex = i;
        }
        if (spawnIndex == -1)
            return;//no availible enemy spawns


        spawnEnemies[spawnIndex].transform.position = gameObject.transform.position + new Vector3(Random.Range(-radius, radius), 0.0f, Random.Range(-radius, radius)) * spawnRadiusScalar;
        spawnEnemies[spawnIndex].SetActive(true);
        _pvtSpawnTimeInterval = spawnTimeInterval;
    }

    void SpawnEnemyUnoptimized()
    {
        if (spawnEnemies.Count == maxSpawn)
            return;

        var temp = GameObject.Instantiate(enemyPrefab);
        temp.SetActive(true);
        temp.transform.position = gameObject.transform.position + new Vector3(Random.Range(-radius, radius), 0.0f, Random.Range(-radius, radius)) * spawnRadiusScalar;
        _pvtSpawnTimeInterval = spawnTimeInterval;
        spawnEnemies.Add(temp);

    }

}
