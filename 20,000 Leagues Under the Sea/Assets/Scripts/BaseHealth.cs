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
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }        
    }

    public void takeDamage(int damage){
        currentHealth -= damage;
        if (healthBar != null)
        {
            healthBar.setHealth(currentHealth);
        }        
    }

    public void restoreHealth(int restore){
        currentHealth = (currentHealth + restore > maxHealth) ? maxHealth : currentHealth + restore;        
        if (healthBar != null)
        {
            healthBar.setHealth(currentHealth);
        }     
    }
}
