using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSubmarineController : MonoBehaviour
{
    public Vector2 moving = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // are we controlling x too?
        moving.x = moving.y = 0;

        if (Input.GetKey("up") || Input.GetKey("w") || Input.GetKey("space") || Input.GetMouseButton(0)){
            moving.y = 1;
        }
    }
}
