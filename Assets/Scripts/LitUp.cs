using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ShadowMonsterMove monster = other.gameObject.GetComponent<ShadowMonsterMove>();
        if (monster != null ) // if it has collided with a ShadowMonster, Illuminate it
        {
            monster.Illuminated();
        }
    }

    /* FOR TESTING get rid of later
    private void OnTriggerExit(Collider other)
    {
        foreach (SkinnedMeshRenderer mesh in other.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            mesh.material.color = Color.red;
        }
    }
    */
}
