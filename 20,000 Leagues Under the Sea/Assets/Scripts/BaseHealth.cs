using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "EnemyProjectile"){
            takeDamage(50);
        }
    }

    public void takeDamage(int damage){
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }
}
