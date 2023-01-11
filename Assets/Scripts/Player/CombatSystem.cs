using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public int health = 10000;
    public int HP = 10000;

    void Die()
    {

    }

    void HealthChange(int value)
    {
        health += value;
        health = Mathf.Max(health, HP);
        health = Mathf.Min(health, 0);
        if (health == 0) Die();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
