using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    public UnityEvent OnDeath;
    
    private float currentHealth;
    private bool isDead = false;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            OnDeath?.Invoke();        
        }
    }
    
    public float GetCurHealth(){
        return currentHealth;
    }
    public float GetMaxHealth(){
        return maxHealth;
    }
}
