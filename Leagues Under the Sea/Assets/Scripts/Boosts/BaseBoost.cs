using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBoost : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp();

            Destroy(gameObject);
        }
    }

    public virtual void PickUp()
    {
        Debug.Log("Pickup Get!");
    }
}
