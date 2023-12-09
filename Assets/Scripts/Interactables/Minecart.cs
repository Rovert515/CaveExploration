using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
