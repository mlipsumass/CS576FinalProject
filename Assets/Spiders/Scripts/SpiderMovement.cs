using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderMovement : MonoBehaviour
{

    public NavMeshAgent agent;
    public GameObject player;
    public Animator spiderAnimator;
    private float movementSpeed = 15.0f;
    public float angularSpeed = 150f;
    private string isWalking = "isWalking";
    private float proximityDistance = 35f;
    private string isAttacking = "isAttacking";
    private string isDead = "isDead";
    private float attackDamage = 0.0001f;
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth Script not found !");
        }

        agent.speed = movementSpeed;
        agent.angularSpeed = angularSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 playerposition = player.transform.position;

            if(Vector3.Distance(transform.position, playerposition) < proximityDistance)
            {
                LookAtPlayer(playerposition);

                Ray movePosition = Camera.main.ScreenPointToRay(playerposition);
                if (Physics.Raycast(movePosition, out var hitInfo))
                {
                    agent.SetDestination(hitInfo.point);

                    float distanceToPlayer = Vector3.Distance(transform.position, playerposition);
                    if (distanceToPlayer <= 10f)
                    {
                        AttackPlayer();
                    }
                    else
                    {
                        spiderAnimator.SetBool(isWalking, true);
                        spiderAnimator.SetBool(isAttacking, false);
                    }
                }
                else
                {
                    agent.ResetPath();
                    spiderAnimator.SetBool(isWalking, false);
                }
            }

        }
        else{
            Debug.Log("Player not found");

        }
    }

    void LookAtPlayer(Vector3 playerPosition)
    {
        Vector3 lookDirection = transform.position - playerPosition ;
        lookDirection.y = 0; 
        Quaternion rotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime*2f);
    }

    void AttackPlayer()
    {
        spiderAnimator.SetBool(isWalking, false);
        spiderAnimator.SetBool(isAttacking, true);
        
        playerHealth.TakeDamage(attackDamage);

        Invoke("HandleDeath", 2f);
    }

    void HandleDeath()
    {
        spiderAnimator.SetBool(isDead, true);
        Invoke("DestroyObject", 2f);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
