using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public Debris debris;
    public int totalDebris = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExplode(){
        var t = transform;

        for (int i = 0; i < totalDebris; i++){
            t.TransformPoint(0, -100, 0);
            var clone = Instantiate(debris, t.position, Quaternion.identity) as Debris;
            var body2D = clone.GetComponent<Rigidbody2D>();
            body2D.AddForce(Vector3.right * Random.Range(-100, 100));
            body2D.AddForce(Vector3.up * Random.Range(100, 500));
        }
        Destroy(gameObject);
    }
}
