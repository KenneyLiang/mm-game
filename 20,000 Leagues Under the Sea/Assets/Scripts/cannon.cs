using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{ 
    public Transform firePoint;
    public GameObject bulletPrefab;

    private int _basicTimer = 0;
    private int[] _timers = { 0, 0, 0 };

    void FixedUpdate()
    {
        Vector2 cannonPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - cannonPosition;
        transform.right = direction;

        if (Input.GetMouseButton(1)) {
            Shoot();
        }

        decrementTimers();
    }

    void decrementTimers() {
        _basicTimer--;

        for (int i = 0; i < _timers.Length; i++) {
            _timers[i]--;
        }
    }

    void Shoot()
    {
        BasicShot();
    }

    void BasicShot() {
        if (_basicTimer < 0) {
            Vector3 newPos =  firePoint.position + (firePoint.rotation * (new Vector3(1, 0, 0)));
            Instantiate(bulletPrefab, newPos, firePoint.rotation);

            _basicTimer = 15;
        }
    }

    void MachinegunShot() {
        
    }

    void ShotgunShot() {

    }
}
