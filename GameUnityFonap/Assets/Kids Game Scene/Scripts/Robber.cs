using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robber : MonoBehaviour
{
    public Transform tarjet;
    private NavMeshAgent agent;
    private Animator animator;

    private const float movingDistance = 10f;

    private float timer = 0f;

    private float newPositionX;
    private float newPositionY;

    private float minValue;
    private float maxValue;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        maxValue = Mathf.Max(-7, transform.position.x - movingDistance);
        minValue = Mathf.Min(26, transform.position.x + movingDistance);
        newPositionX = Random.Range(maxValue, minValue);

        maxValue = Mathf.Max(-3, transform.position.y - movingDistance);
        minValue = Mathf.Min(14, transform.position.y + movingDistance);
        newPositionY = Random.Range(maxValue, minValue);

        tarjet.position = new Vector2(newPositionX, newPositionY);
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(tarjet.position);

        if (agent.remainingDistance > agent.stoppingDistance) animator.SetBool("is_moving", true);
        else WaitState();

        if (timer >= 3) ChangeTargetPosition();

    }

    void ChangeTargetPosition()
    {
        maxValue = Mathf.Max(-7, transform.position.x - movingDistance);
        minValue = Mathf.Min(26, transform.position.x + movingDistance);
        newPositionX = Random.Range(maxValue, minValue);

        maxValue = Mathf.Max(-3, transform.position.y - movingDistance);
        minValue = Mathf.Min(14, transform.position.y + movingDistance);
        newPositionY = Random.Range(maxValue, minValue);

        tarjet.position = new Vector2(newPositionX, newPositionY);

        timer = 0f;
    }

    void WaitState()
    {
        animator.SetBool("is_moving", false);
        timer += Time.deltaTime;
    }
}
