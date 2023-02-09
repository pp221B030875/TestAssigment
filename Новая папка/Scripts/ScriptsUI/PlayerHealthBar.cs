using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBarUI;
    
    private Health playerHealth;
    
    private void Start()
    {
        playerHealth = GetComponent<Health>();
    }
    private void Update()
    {
        SetHealthValue(playerHealth.GetCurHealth(),playerHealth.GetMaxHealth());
    }
    public void SetHealthValue(float curHealth,float maxHealth)
    {
        healthBarUI.value = curHealth;
        healthBarUI.maxValue = maxHealth;
    }
}
