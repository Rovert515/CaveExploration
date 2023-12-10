using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A rock that glows green red or blue. Has attached crystals as children in each of the colors, as well as an
// internal light that changes colors, and a light in a nearby lantern that changes colors to match it. Also keeps
// track of how many rocks are currently glowing in each color, so that when all three GlowyRocks glow green they
// reveal the hiddenKey they are attached to
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

    [SerializeField] private Key hiddenKey; // a hiddenKey that is only revealed when all three stones are green
    //[SerializeField] private GameObject correspondingLightObject; // the gameobject for the point light, because for some reason you can't
        // have a serializable Light field
    [SerializeField] Light correspondingLight; // a light in the lantern that changes color
                                               // to match it
    [SerializeField] Light internalLight; // an internal light that changes color to match it

    [SerializeField] AudioClip puzzleSolved; // audio clip that plays when the player turns all the lights green

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
        hiddenKey.gameObject.SetActive(false); // hides the hiddenKey at the start
    }

    private void ChangeColor(StoneColor targetColor)
    {
        switch (targetColor)
        {
            case StoneColor.Green:
                greenRock.enabled = true;
                redRock.enabled = false;
                blueRock.enabled = false;
                correspondingLight.color = Color.green;
                internalLight.color = Color.green;
                break;
            case StoneColor.Red:
                greenRock.enabled = false;
                redRock.enabled = true;
                blueRock.enabled = false;
                correspondingLight.color = Color.red;
                internalLight.color = Color.red;
                break;
            case StoneColor.Blue:
                greenRock.enabled = false;
                redRock.enabled = false;
                blueRock.enabled = true;
                correspondingLight.color = Color.blue;
                internalLight.color = Color.blue;
                break;
        }
        totalStones.SubColor(currentColor); // the current color is changing so reduce the total number of stones of its color
        currentColor = targetColor; // we want to record which color we're currently displaying
        totalStones.AddColor(currentColor); // increase the number of stones of the new current color
        if (totalStones.greenStones >= 3 & !hiddenKey.pickedUp)
        {
            hiddenKey.gameObject.SetActive(true); // reveal the hiddenKey
            Camera.main.GetComponent<AudioSource>().PlayOneShot(puzzleSolved);
        } else
        {
            if (hiddenKey.gameObject.activeSelf) // if the hiddenKey was active but now not all the lights are green, hide it
            {
                hiddenKey.gameObject.SetActive(false);
            }
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
