using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private List<GameObject> _spawnPoints;
    [SerializeField] private float _delay;

    public void Start()
    {
        StartCoroutine(SpawnEnemies(_delay));
    }

    private IEnumerator SpawnEnemies(float _delay)
    {
        while (true) 
        {
            Instantiate(_enemy, GetRandomSpawnPoint().transform.position, Quaternion.Euler(0, GetRandomTurn(), 0));
            yield return new WaitForSeconds(_delay);
        }
    }

    private GameObject GetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }

    private float GetRandomTurn()
    {
        float minTurn = -45f;
        float maxTurn = 45f;

        return Random.Range(minTurn, maxTurn);
    }
}
