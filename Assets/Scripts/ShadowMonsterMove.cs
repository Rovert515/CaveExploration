using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShadowMonsterMove : MonoBehaviour
{
    private NavMeshAgent agent; // the shadow monster's navmesh
    private Transform playerPos; // the position of the player, given to it by the collider that triggers it

    private SkinnedMeshRenderer[] meshes; // the meshes that make up this ShadowMonster
    private Material dissolveMaterial;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        meshes = GetComponentsInChildren<SkinnedMeshRenderer>();
        dissolveMaterial = GetComponentInChildren<SkinnedMeshRenderer>().material;
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

        // Trigger dissolve animation (modify "_DissolveAmount" based on your shader property)
        StartCoroutine(DissolveAnimation());

        // Optionally, you can add a delay before destroying the object
        float delay = 1.0f; // Adjust the delay time as needed
        Destroy(gameObject, delay);
    }

    IEnumerator DissolveAnimation()
    {
        float duration = 1.0f; // Adjust the duration of the dissolve effect
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float dissolveAmount = Mathf.Lerp(0f, 1f, (Time.time - startTime) / duration);
            dissolveMaterial.SetFloat("_DissolveAmount", dissolveAmount);

            yield return null;
        }

        // Ensure the dissolve is complete
        dissolveMaterial.SetFloat("_DissolveAmount", 1f);
    }
}
