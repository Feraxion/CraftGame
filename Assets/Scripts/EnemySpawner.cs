using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Vector3 enemyPosition;
    public int enemyCount;
    public int startWait;

    int randEnemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawner());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator spawner()
    {
        yield return new WaitForSeconds(startWait);

        while(enemyCount <= 10)
        {
            randEnemy = Random.Range(0, 2);
            Vector3 spawnPosition = transform.position;
            Instantiate(enemies[randEnemy], spawnPosition, transform.rotation);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
        
    }
}
