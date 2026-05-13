using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private bool _canSpawn = true;

    void Start()
    {
        StartCoroutine(CoroutineSpawn());
    }

    public IEnumerator CoroutineSpawn()
    {
        int minSpawnIndex = 0;

        while (_canSpawn == true)
        {
            int randomIndex = Random.Range(minSpawnIndex, _spawnPoints.Length);

            Vector3 spawnPosition = _spawnPoints[randomIndex].position;

            Instantiate(_prefab, spawnPosition, Quaternion.LookRotation(Vector3.right));
            yield return new WaitForSeconds(2);
        }
    }
}
