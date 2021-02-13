using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _boostList;

    void Start()
    {
        StartCoroutine(SpawnBoost());
    }

    IEnumerator SpawnBoost() {
        while (true) {
            int spawnDelay = Random.Range(10, 16);

            yield return new WaitForSeconds(spawnDelay);

            int randIndex = Random.Range(0, _boostList.Length);

            Instantiate(
                _boostList[randIndex],
                new Vector3(
                    transform.position.x + 15,
                    transform.position.y + Random.Range(-1.0f, 1.0f),
                    transform.position.z
                ),
                Quaternion.identity
            );
        }
    }
}
