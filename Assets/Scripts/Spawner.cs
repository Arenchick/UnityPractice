using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public int countEnemy = 3;

    private void Start()
    {
        StartCoroutine(SpawnWithTimeOut());
    }

    IEnumerator SpawnWithTimeOut()
    {
        for (int i = 0; i < countEnemy; i++)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
}
