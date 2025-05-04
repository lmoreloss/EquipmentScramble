using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreditsScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI creditsTextArea;
    [SerializeField]
    GameObject credits;
    bool isPlayerInside = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            isPlayerInside = true;
            creditsTextArea.enabled = true;
            creditsTextArea.GetComponentInParent<Image>().enabled = true;
        }

    }

    void Update()
    {

            if (Input.GetKeyDown(KeyCode.E) && isPlayerInside)
            {
                credits.SetActive(true);
            }
            else if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
            {
                credits.SetActive(false);
            }
        

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            isPlayerInside = false;
            creditsTextArea.enabled = false;
            creditsTextArea.GetComponentInParent<Image>().enabled = false;
        }

    }
}
