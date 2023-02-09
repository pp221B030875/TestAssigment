using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBarUI;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        healthBarUI.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
    
    public void SetHealthValue(float curHealth,float maxHealth)
    {
        healthBarUI.gameObject.SetActive( curHealth < maxHealth);
        healthBarUI.value = curHealth;
        healthBarUI.maxValue = maxHealth;
    }
}
