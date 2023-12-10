using UnityEngine;

public class ShadowMonDetection : MonoBehaviour
{
    public GameObject shadowMonsterDetectionUI;

    // Reference to the current Shadow Monster object
    private GameObject currentShadowMonster;

    void Start()
    {
        shadowMonsterDetectionUI = GameObject.FindWithTag("ShadowMonsterDetection");
        shadowMonsterDetectionUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShadowMonster"))
        {
            // Set the current Shadow Monster object
            currentShadowMonster = other.gameObject;

            // Activate the shadowmonsterdetection GameObject
            shadowMonsterDetectionUI.SetActive(true);
        }
    }

    private void Update()
    {
        // Check if the current Shadow Monster object is null (destroyed)
        if (currentShadowMonster == null)
        {
            // Deactivate the UI
            shadowMonsterDetectionUI.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ShadowMonster"))
        {
            // Reset the current Shadow Monster object
            if (other.gameObject == currentShadowMonster)
            {
                currentShadowMonster = null;
            }

            // If no Shadow Monsters are present, deactivate the UI
            if (currentShadowMonster == null)
            {
                shadowMonsterDetectionUI.SetActive(false);
            }
        }
    }
}
