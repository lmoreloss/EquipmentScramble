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
        if (Input.anyKeyDown  && isPlayerInside == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                credits.SetActive(true);
            }
            else
            {
                credits.SetActive(false);
            }
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
