using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinTemplate;

    private float _waitingTime = 1f;
    private int _spawnDistance = 40;

    private void Start()
    {
        StartCoroutine(SpawnCoin());
    }

    private IEnumerator SpawnCoin()
    {
        var WaitForOwnSeconds = new WaitForSeconds(_waitingTime);
        while (true) 
        { 
            Instantiate(_coinTemplate, new Vector3(Random.Range(gameObject.transform.position.x - _spawnDistance, gameObject.transform.position.x + _spawnDistance), gameObject.transform.position.y, 0), transform.rotation);
            yield return WaitForOwnSeconds;
        }
    }
}
