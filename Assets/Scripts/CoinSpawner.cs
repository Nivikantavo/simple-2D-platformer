using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;

    private void Start()
    {
        StartCoroutine(SpawnCoin());
    }
    private IEnumerator SpawnCoin()
    {
        var WaitForOwnSeconds = new WaitForSeconds(1f);
        while (true) 
        { 
            Instantiate(_coin, new Vector3(Random.Range(gameObject.transform.position.x - 40, gameObject.transform.position.x + 40), gameObject.transform.position.y, 0), transform.rotation);
            yield return WaitForOwnSeconds;
        }
    }
}
