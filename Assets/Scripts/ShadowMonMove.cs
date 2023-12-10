using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Controls the movement of a ShadowMonster, making it move towards the player across the nav mesh. If its Illuminated()
// is called (by the player's FlashlightHitbox) the ShadowMonster dies. If it collides with the player, the player
// goes to the gameover screen
public class ShadowMonMove : MonoBehaviour
{
    private NavMeshAgent agent; // the shadow monster's navmesh
    private Transform playerPos; // the position of the player, given to it by the collider that triggers it

    private SkinnedMeshRenderer[] meshes; // the meshes that make up this ShadowMonster
    // private Material dissolveMaterial;

    private GameOverManager gameOverManager;

    private GameObject flakes;
    protected float delay = 1f; // Adjust the delay time as needed

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        meshes = GetComponentsInChildren<SkinnedMeshRenderer>();
        flakes = GetComponentInChildren<ParticleSystem>(true).gameObject;
        // dissolveMaterial = GetComponentInChildren<SkinnedMeshRenderer>().material;
    }

    public void ReceivePlayerPos(Transform player) // just a write only accessor to playerPos for ShadowSpawn to give the player position to
    {
        playerPos = player;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos != null & agent.enabled) // if it's locked onto the player, move towards them
        {
            agent.destination = playerPos.position;
        }

    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // if it runs into the player
        {
            gameOverManager = collision.gameObject.GetComponentInChildren<GameOverManager>(true);
            gameOverManager.OpenMenu();
        }
    }

    public virtual void Illuminated() // this monster is illuminated, and so it dies
    {
   
         // Enable particle system "Flakes" if it exists
        if (flakes != null)
        {
            flakes.gameObject.SetActive(true);
        }
        agent.enabled = false; // make it so it stops chasing the player now that it's been spotlit

        Destroy(gameObject, delay);
    }
}
