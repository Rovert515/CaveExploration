using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// pretty simple script, just grabs and deactivates anything it has as children at the start (presumably a shadow monster),
// then reactivates it when the player enters its collider zone. Only activates once. For all of its shadow monster children it
// gives them the player's transform when it activates them
public class ShadowSpawn : MonoBehaviour
{
    bool triggered = false;
    ShadowMonsterMove[] shadowChildren = null;

    // Start is called before the first frame update
    void Start()
    {
        shadowChildren = GetComponentsInChildren<ShadowMonsterMove>(); // collects all the shadow monsters from the children
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
            foreach (ShadowMonsterMove shadow in shadowChildren) // gives all the child shadow monster's the player's position
            {
                shadow.ReceivePlayerPos(other.transform);
            }
            triggered = true;
        }
    }
}
