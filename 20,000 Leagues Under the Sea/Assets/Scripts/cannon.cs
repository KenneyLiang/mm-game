using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    // Start is called before the first frame update
 
    public Transform firepPoint;
    public GameObject bulletPrefab;



    // Update is called once per frame
    void Update()
    {
        Vector2 cannonPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - cannonPosition;
        transform.right = direction;
       // float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        //this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Min(Mathf.Max(angle, -270), 90)));


        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }

        void Shoot()
        {

            Instantiate(bulletPrefab, firepPoint.position, firepPoint.rotation);

        }



    }
}
