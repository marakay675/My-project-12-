using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private bool _canSpawn = true;
    [SerializeField] private Transform[] _targetsForMyEnemies;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private EnemyMover[] _enemyTypes;

    private void Start()
    {
        StartCoroutine(CoroutineSpawn());
    }

    private IEnumerator CoroutineSpawn()
    {

        while (_canSpawn == true)
        {
        int randomIndex = Random.Range(0, _spawnPoints.Length);

            Transform selectedSpawnPoint = _spawnPoints[randomIndex];
            Transform selectedTarget = _targetsForMyEnemies[randomIndex];
            EnemyMover selectedEnemyType = _enemyTypes[randomIndex];

            GameObject newEnemy = Instantiate(selectedEnemyType.gameObject, selectedSpawnPoint.position, Quaternion.LookRotation(Vector3.right));
            EnemyMover controller = newEnemy.AddComponent<EnemyMover>();

            controller.InitializeTarget(selectedTarget);

            yield return new WaitForSeconds(2);
        }
    }
}
