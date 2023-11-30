using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShadowMonsterMove : MonoBehaviour
{
    NavMeshAgent agent; // the shadow monster's navmesh
    Transform playerPos; // the position of the player, given to it by the collider that triggers it

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos != null) // if it's locked onto the player, move towards them
        {
            agent.destination = playerPos.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // if it's run into the player
        {
            Death();
        }
    }

    private void Death()
    {
        // YOU DIED!
    }
}
