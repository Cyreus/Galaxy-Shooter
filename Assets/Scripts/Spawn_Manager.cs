using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawning = false;
    [SerializeField]
    private GameObject[] Powerups;
    [SerializeField]
    private GameObject _asteroidsPrefab;
    [SerializeField]
    private GameObject _asteroidsContainer;
    void Start()
    {
       
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
        StartCoroutine(spawnAsteroids());
    }
    
 
    
    IEnumerator spawnAsteroids()
    {
        while(_stopSpawning ==false)
        {
            
            Vector3 SpawnPos = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newAsteroids = Instantiate(_asteroidsPrefab, SpawnPos, Quaternion.identity);
            newAsteroids.transform.parent = _asteroidsContainer.transform;

            yield return new WaitForSeconds(8.0f);
        }
    }

    IEnumerator SpawnRoutine()
    {
        while(_stopSpawning == false)
        {
           
            Vector3 SpawnPos = new Vector3(Random.Range(-8f,8f),7,0);
            GameObject newEnemy =  Instantiate(_enemyPrefab,SpawnPos,Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;

            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        while(_stopSpawning==false)
        {
            Vector3 SpawnPos = new Vector3(Random.Range(-8f, 8f), 7, 0);
            int randomPowerUps = Random.Range(0,3);
            Instantiate(Powerups[randomPowerUps],SpawnPos,Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(6,10));

        }

       


    }

    public void PlayerDeath()
    {
        _stopSpawning = true;
    }
}
