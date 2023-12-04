using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{
    private void Start()
    {
        promptText = "push lever with rock";
    }

    override public void Interact(CharacterMotor charMotor)
    {

    }
}
