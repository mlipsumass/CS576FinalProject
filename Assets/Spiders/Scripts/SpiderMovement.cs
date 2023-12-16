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
    public float proximityDistance = 50f;
    public float attackDamage = 0.0001f;
    private float movementSpeed = 15.0f;
    private float angularSpeed = 150f;
    private string isWalking = "isWalking";
    private string isAttacking = "isAttacking";
    private string isDead = "isDead";
    private PlayerHealth playerHealth;

    private bool isWalkSoundPlayed = false;
    private bool isAttackSoundPlayed = false;

    void Start()
    {
        isAttackSoundPlayed = false;
        isWalkSoundPlayed = false;
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
                        if (!isWalkSoundPlayed)
                        {
                            FindObjectOfType<AudioManager>().Play("enemy_walk");
                            isWalkSoundPlayed = true;
                        }
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
        if (!isAttackSoundPlayed)
        {
            FindObjectOfType<AudioManager>().Play("enemy_attack");
            isAttackSoundPlayed = true;
        }
        
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
