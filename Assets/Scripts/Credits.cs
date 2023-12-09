using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject creditTitle;
    public GameObject creditBody;
    public float scrollSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        creditTitle.transform.position += new Vector3(0, scrollSpeed * Time.deltaTime);
        creditBody.transform.position += new Vector3(0, scrollSpeed * Time.deltaTime);
        if (creditBody.transform.position.y >= 800)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScreen");
        }
    }
}
