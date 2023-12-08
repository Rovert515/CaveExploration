using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSighting : MonoBehaviour
{
    [SerializeField] private GameObject destination; // the point this moves towards
    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = destination.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        // DIALOGUE BEGINS
        Destroy(gameObject);
    }
}
