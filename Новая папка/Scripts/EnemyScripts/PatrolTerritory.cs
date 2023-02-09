using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PatrolTerritory : MonoBehaviour
{
    [SerializeField] private float speedEnemy;

    //[SerializeField] private Transform[] moveSpots;
    private Vector3 nextSpot,prevSpot;

    private Transform playerPos;
    [SerializeField] private float distanceToFollow = 5.0f;
    
    [SerializeField] private float waitTime; //Here we can change from inspector how many time enemy will stay in the same position
    private float timerWaitTime; //code will check this field to change nextPosition

    public UnityEvent OnMoveStart;
    public UnityEvent OnMoveEnd;

    public bool IsMoving { get; private set; }
    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timerWaitTime = waitTime;
        prevSpot = nextSpot;
        nextSpot = new Vector3( transform.position.x + Random.Range(-5f,5f),transform.position.y + Random.Range(-6f,6f),transform.position.z);
    }

    private void Update()
    {
        var lastMoving = IsMoving;
        
        if(Vector2.Distance(transform.position, playerPos.position) < distanceToFollow)
        {
            IsMoving = true;
            transform.position = Vector2.MoveTowards(transform.position , playerPos.position , speedEnemy*Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,nextSpot,speedEnemy*Time.deltaTime);
            if(Vector2.Distance(transform.position, nextSpot) < 0.2f)
            {
                if(timerWaitTime <= 0.0f)
                {
                    prevSpot = nextSpot;
                    nextSpot = new Vector3( transform.position.x + Random.Range(-5f,5f),transform.position.y + Random.Range(-6f,6f),transform.position.z);
                    timerWaitTime = waitTime;
                    IsMoving = true;
                }
                else
                {
                    IsMoving = false;
                    timerWaitTime -= Time.deltaTime;
                }
            }
        }

        if(IsMoving && lastMoving != IsMoving) OnMoveStart?.Invoke();
        if(!IsMoving && lastMoving != IsMoving) OnMoveEnd?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            nextSpot = prevSpot;
        }
    }
}
