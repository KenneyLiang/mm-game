using UnityEngine;

public class BaseHealth : MonoBehaviour {

    //Public vars 
    public float maxHealth;

    //Private vars
    private float curHealth; 


    private void Start() {
        curHealth = maxHealth;
        
    }

}