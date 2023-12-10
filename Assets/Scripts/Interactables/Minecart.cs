using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A minecart that the player can click on to push. Only pushes in one direction, the positive x direction,
// and only if the player is behind it on the x. Allows the player to push the minecart to reveal a hint under
// it without the minecart running into the player
public class Minecart : Interactable
{
    private BoxCollider boxCollider;
    private Rigidbody rigidBody;

    void Start()
    {
        promptText = "Click to push minecart (must be behind it)";

        boxCollider = GetComponent<BoxCollider>();
        rigidBody = GetComponent<Rigidbody>();
    }

    public override void Interact(CharacterMotor charMotor)
    {
        if (charMotor.transform.position.x < transform.position.x - (boxCollider.size.x / 2)) // if the character's center is behind
            // the box collider
        {
            rigidBody.AddForce(new Vector3(5, 0, 0));
        }
    }
}
