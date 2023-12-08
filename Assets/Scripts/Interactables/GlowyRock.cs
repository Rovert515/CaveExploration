using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowyRock : Interactable
{
    public enum StoneColor
    {
        Red, Green, Blue
    }

    private struct TotalStones // one static variable version of this is used to keep track of how many rocks are shining in each color at a
        // time. This is so that a hidden message can be r
    {
        public TotalStones(int green, int red, int blue) // really this should always start with 0, but that's not supported for structs apparently
        {
            greenStones = green;
            redStones = red;
            blueStones = blue;
        }

        public int greenStones;
        public int redStones;
        public int blueStones;

        public void AddColor(StoneColor stoneColor) // increase the number of a specific colored stone by 1
        {
            switch (stoneColor)
            {
                case StoneColor.Green:
                    greenStones += 1;
                    break;
                case StoneColor.Red:
                    redStones += 1;
                    break;
                case StoneColor.Blue:
                    blueStones += 1;
                    break;
            }
        }
        public void SubColor(StoneColor stoneColor) // reduce the number of a specific colored stone by 1
        {
            switch (stoneColor)
            {
                case StoneColor.Green:
                    greenStones -= 1;
                    break;
                case StoneColor.Red:
                    redStones -= 1;
                    break;
                case StoneColor.Blue:
                    blueStones -= 1;
                    break;
            }
        }
    }

    private static TotalStones totalStones = new TotalStones(0, 0, 0); // counts how many active rocks of each color there are, starting at 0 for all

    MeshRenderer greenRock;
    MeshRenderer blueRock;
    MeshRenderer redRock;

    [SerializeField] private GameObject hiddenMessage; // a hidden message that is only revealed when all three stones are green

    public StoneColor currentColor = StoneColor.Green;

    private void Start()
    {
        promptText = "Click to touch the crystals";

        foreach (Transform child in transform)
        {
            if (child.tag == "Green")
            {
                greenRock = child.GetComponent<MeshRenderer>();
            }
            if (child.tag == "Red")
            {
                redRock = child.GetComponent<MeshRenderer>();
            }
            if (child.tag == "Blue")
            {
                blueRock = child.GetComponent<MeshRenderer>();
            }
        }
        ChangeColor(currentColor); // sets the currentColor to itself, but in the proces makes sure that the right color is actually visible
        totalStones.AddColor(currentColor);
        hiddenMessage.SetActive(false); // hides the hidden message at the start
    }

    private void ChangeColor(StoneColor targetColor)
    {
        switch (targetColor)
        {
            case StoneColor.Green:
                greenRock.enabled = true;
                redRock.enabled = false;
                blueRock.enabled = false;
                break;
            case StoneColor.Red:
                greenRock.enabled = false;
                redRock.enabled = true;
                blueRock.enabled = false;
                break;
            case StoneColor.Blue:
                greenRock.enabled = false;
                redRock.enabled = false;
                blueRock.enabled = true;
                break;
        }
        totalStones.SubColor(currentColor); // the current color is changing so reduce the total number of stones of its color
        currentColor = targetColor; // we want to record which color we're currently displaying
        totalStones.AddColor(currentColor); // increase the number of stones of the new current color
        if (totalStones.greenStones >= 3)
        {
            hiddenMessage.SetActive(true); // reveal the hidden message
        }
        return;
    }

    override public void Interact(CharacterMotor charMotor)
    {
        switch (currentColor) // switches to the next color down the list (if green go red, if red go blue, if blue go green)
        {
            case StoneColor.Green:
                ChangeColor(StoneColor.Red);
                break;
            case StoneColor.Red:
                ChangeColor(StoneColor.Blue);
                break;
            case StoneColor.Blue:
                ChangeColor(StoneColor.Green);
                break;
        }
    }
}
