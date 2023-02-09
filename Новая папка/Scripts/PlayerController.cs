using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private float speed = 5f;

    public UnityEvent OnMoveStart;
    public UnityEvent OnMoveEnd;
    public bool IsMoving { get; private set; }

    private Score scoreUI;
    [SerializeField] private GameObject gameOverText;

    private void Start()
    {
        gameOverText.SetActive(false);
        scoreUI = GetComponent<Score>();
    }
    public void Death()
    {
        gameOverText.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 0.0f;
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var direction = new Vector3(horizontal, vertical, 0);
        if(direction.sqrMagnitude > 1f) direction.Normalize();

        var lastMoving = IsMoving;
        IsMoving = direction.sqrMagnitude > 0f;
        
        if(IsMoving && lastMoving != IsMoving) OnMoveStart?.Invoke();
        if(!IsMoving && lastMoving != IsMoving) OnMoveEnd?.Invoke();
        
        transform.Translate(direction * (speed * Time.deltaTime));
    }

    public void IncreaseScore(int plusScore)
    {
        scoreUI.score += plusScore;
    }

}
