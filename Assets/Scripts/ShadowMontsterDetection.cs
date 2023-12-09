using UnityEngine;
using UnityEngine.AI;

public class ShadowMonsterDetection : MonoBehaviour
{
    public GameObject shadowMonsterDetectionUI;

    void Start()
    {
        shadowMonsterDetectionUI = GameObject.FindWithTag("ShadowMonsterDetection");
        shadowMonsterDetectionUI.SetActive(false);


     }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ShadowMonster") // OnTriggerEnter is used for triggers
        {
            // Activate the shadowmonsterdetection GameObject
          
            shadowMonsterDetectionUI.SetActive(true);
  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ShadowMonster") // OnTriggerEnter is used for triggers
        {
            // Activate the shadowmonsterdetection GameObject

            shadowMonsterDetectionUI.SetActive(false);

        }
    }

}
