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
        MachinegunShot();
        ShotgunShot();
    }

    void BasicShot() {
        if (_basicTimer < 0) {
            Vector3 newPos =  firePoint.position + (firePoint.rotation * (new Vector3(1, 0, 0)));
            Instantiate(bulletPrefab, newPos, firePoint.rotation);

            _basicTimer = 15;
        }
    }

    void MachinegunShot() {
        if (_timers[0] < 0) {
            Player p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

            int charges = p.GetGunTimer(0);

            for (int i = 0; i < charges; i++) {
                float newRotation = (firePoint.rotation.z * Mathf.Rad2Deg) + Random.Range(-10f, 10f);

                Vector3 newPos =  firePoint.position + (firePoint.rotation * (new Vector3(1, 0, 0)));
                Instantiate(bulletPrefab, newPos, Quaternion.Euler(0, 0, newRotation));
            }

            _timers[0] = 3;
        }
    }

    void ShotgunShot() {
        if (_timers[1] < 0) {
            Player p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

            int charges = p.GetGunTimer(1);

            for (int i = 0; i < charges; i++) {
                for (int j = 0; j < 7; j++) {
                    float newRotation = (firePoint.rotation.z * Mathf.Rad2Deg) + Random.Range(-20f, 20f);

                    Vector3 newPos =  firePoint.position + (firePoint.rotation * (new Vector3(1, 0, 0)));
                    Instantiate(bulletPrefab, newPos, Quaternion.Euler(0, 0, newRotation));
                }
            }

            _timers[1] = 30;
        }
    }
}
