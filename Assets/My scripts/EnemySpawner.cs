using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    //[SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private bool _canSpawn = true;
    [SerializeField] private Transform _targetForMyEnemies;

    private void Start()
    {
        StartCoroutine(CoroutineSpawn());
    }

    private IEnumerator CoroutineSpawn()
    {
        //int minSpawnIndex = 0;

        while (_canSpawn == true)
        {
            //int randomIndex = Random.Range(minSpawnIndex, _spawnPoints.Length);

            //Vector3 spawnPosition = _spawnPoints[randomIndex].position;

           GameObject newEnemy = Instantiate(_prefab, transform.position, Quaternion.LookRotation(Vector3.right));
            EnemyController controller = newEnemy.GetComponent<EnemyController>();

            controller.InitializeTarget(_targetForMyEnemies);

            yield return new WaitForSeconds(2);
        }
    }
}
