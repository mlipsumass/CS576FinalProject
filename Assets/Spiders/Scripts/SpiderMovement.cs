using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderMovement : MonoBehaviour
{

    public NavMeshAgent agent;
    public GameObject player;
    public float proximityDistance = 25f;
    public Animator spiderAnimator;
    public string isWalking = "isWalking";
    public string isAttacking = "isAttacking";
    public String isDead = "isDead";


    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 playerposition = player.transform.position;

            if(Vector3.Distance(transform.position, playerposition) < proximityDistance)
            {
                Ray movePosition = Camera.main.ScreenPointToRay(playerposition);
                if (Physics.Raycast(movePosition, out var hitInfo))
                {
                    agent.SetDestination(hitInfo.point);

                    LookAtPlayer(playerposition);

                    float distanceToPlayer = Vector3.Distance(transform.position, playerposition);
                    if (distanceToPlayer <= 10f)
                    {
                        spiderAnimator.SetBool(isWalking, false);
                        spiderAnimator.SetBool(isAttacking, true);
                    }
                    else
                    {
                        spiderAnimator.SetBool(isAttacking, false);
                        spiderAnimator.SetBool(isWalking, true);
                    }
                }
                else
                {
                    agent.ResetPath();
                    spiderAnimator.SetBool(isWalking, false);
                    spiderAnimator.SetBool(isAttacking, false);
                }
            }

        }
        else{
            Debug.Log("Player not found");

        }
    }

    void LookAtPlayer(Vector3 playerPosition)
    {
        Vector3 lookDirection = playerPosition - transform.position;
        lookDirection.y = 0; 
        Quaternion rotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2f);
    }
}
