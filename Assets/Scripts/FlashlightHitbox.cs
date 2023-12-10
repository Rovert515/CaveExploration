using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A trigger hitbox attached to the flashlight, so that any shadow monster that "steps into the light" (collides
// with the hitbox) has its Illuminated() triggered, disintegrating it
public class FlashlightHitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ShadowMonMove monster = other.gameObject.GetComponent<ShadowMonMove>();
        if (monster != null ) // if it has collided with a ShadowMonster, Illuminate it
        {
            monster.Illuminated();
        }
    }
}
