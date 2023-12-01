using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShadowMonsterMove : MonoBehaviour
{
    private NavMeshAgent agent; // the shadow monster's navmesh
    private Transform playerPos; // the position of the player, given to it by the collider that triggers it

    private SkinnedMeshRenderer[] meshes; // the meshes that make up this ShadowMonster

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        meshes = GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    public void ReceivePlayerPos(Transform player) // just a write only accessor to playerPos for ShadowSpawn to give the player position to
    {
        playerPos = player;
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
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        // YOU DIED!
    }

    public void Illuminated() // this monster is illuminated, and so it dies
    {
        foreach (SkinnedMeshRenderer mesh in meshes)
        {
            mesh.material.color = Color.red; // temp code
        }
    }
}
