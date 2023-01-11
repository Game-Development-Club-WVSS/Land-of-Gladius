using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public int health = 10000;
    public int HP = 10000;

    public void Die()
    {

    }

    public void HealthChange(int value)
    {
        print(value);
        health += value;
        health = Mathf.Min(health, HP);
        health = Mathf.Max(health, 0);
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
