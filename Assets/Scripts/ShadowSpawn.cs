using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// pretty simple script, just grabs and deactivates anything it has as children at the start (presumably a shadow monster),
// then reactivates it when the player enters its collider zone. Only activates once
public class ShadowSpawn : MonoBehaviour
{
    bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered & other.CompareTag("Player")) // if the thing that triggered it was a player and it hasn't been triggered before
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
            triggered = true;
        }
    }
}
