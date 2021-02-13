using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGroup : MonoBehaviour
{
    [SerializeField] private GameObject _coin;

    void Start()
    {
        int randPattern = Random.Range(0, 3);

        if (randPattern == 0) {
            BoxPattern();
        } else if (randPattern == 1) {
            LinePattern();
        } else {
            SinePattern();
        }

        Destroy(gameObject);
    }

    private void BoxPattern()
    {
        for (int i = -2; i < 3; i++) {
            for (int j = 0; j < 5; j++) {
                Instantiate(
                    _coin,
                    new Vector3(
                        transform.position.x + i,
                        transform.position.y + j,
                        transform.position.z
                    ),
                    Quaternion.identity
                );
            }
        }
    }

    private void LinePattern()
    {
        for (int i = 0; i < 10; i++) {
            Instantiate(
                    _coin,
                    new Vector3(
                        transform.position.x + i,
                        transform.position.y,
                        transform.position.z
                    ),
                    Quaternion.identity
                );
        }
    }

    private void SinePattern()
    {
        int sineOffset = Random.Range(0, 90);

        for (int i = 0; i < 20; i++) {
            Instantiate(
                    _coin,
                    new Vector3(
                        transform.position.x + (i * 0.5f),
                        transform.position.y + 2 * Mathf.Cos((i * 0.5f) + sineOffset),
                        transform.position.z
                    ),
                    Quaternion.identity
                );
        }
    }
}
