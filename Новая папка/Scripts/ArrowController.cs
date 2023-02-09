using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    private float timerBeforeDestoy;

    public float Damage { get ; set; }

    private void Awake()
    {
        Damage = 10.0f;
        timerBeforeDestoy = 5.0f;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * (speed * Time.deltaTime));

        timerBeforeDestoy -= Time.deltaTime;
        if (timerBeforeDestoy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
