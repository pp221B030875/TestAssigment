using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int pointsForEnemy;
    private Health health;
    
    private PlayerController player;

    [SerializeField] private float startTimerBeforeNextAttack = 1.0f;
    private float timerBeforeNextAttack;
    [SerializeField] private float damage = 10.0f;
    
    private void Start()
    {
        timerBeforeNextAttack = startTimerBeforeNextAttack;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        health = GetComponent<Health>();
        healthBar.SetHealthValue(health.GetCurHealth(),health.GetMaxHealth());
    }
    private void Update()
    {
        if(timerBeforeNextAttack > 0)
        {
            timerBeforeNextAttack-= Time.deltaTime;
        }
    }
    public void Death()
    {
        player.IncreaseScore(pointsForEnemy);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ArrowController arrow = other.gameObject.GetComponent<ArrowController>();
        if (arrow != null)
        {
            health.TakeDamage(arrow.Damage);
            healthBar.SetHealthValue(health.GetCurHealth(),health.GetMaxHealth());
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Player"))
        {
            if(timerBeforeNextAttack<=0)
            {
                other.gameObject.GetComponent<Health>().TakeDamage(damage);
                timerBeforeNextAttack = startTimerBeforeNextAttack;
            }
        }
    }
}
