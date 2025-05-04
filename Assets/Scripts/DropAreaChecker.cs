using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropAreaChecker : MonoBehaviour
{
    [SerializeField]
    int maxCameras = 0;
    int maxGreenSrcs = 0;
    int maxGenerators = 0;
    int maxLights = 0;
    int requiredCameras = 0;
    int requiredGreenSrcs = 0;
    int requiredGenerators = 0;
    int requiredLights = 0;
    PlayerInventory inventory;
    bool showWinMessage = true;
    [SerializeField]
    TextMeshProUGUI collectibleText;
    [SerializeField]
    CollectibleSpawner collectibleSpawner;
    [SerializeField]
    Animator NextDayOverlayAnimator;
    bool isInside = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetCollectibleRequirements();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        collectibleText.enabled = true;
        collectibleText.GetComponentInParent<Image>().enabled = true;
        if (col.name == "Player")
        {
            isInside = true;
        }
        if (inventory.cameras >= requiredCameras && inventory.greenscrs >= requiredGreenSrcs && inventory.generators >= requiredGenerators && inventory.lights >= requiredLights && showWinMessage && col.name == "Player")
        {
            Debug.Log("<color=green> You won!</color>");
            collectibleText.text = "<color=green>Thanks! We can continue filming!</color><br>You can press <color=yellow>\"E\"</color> to advance to the next day!";
            showWinMessage = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && showWinMessage == false && isInside == true)
        {
            StartCoroutine(waitForFrames());
            showWinMessage = true;
        }
    }

    IEnumerator waitForFrames()
    {
        collectibleSpawner.spawnObjects();
        inventory.SetToZero();
        NextDayOverlayAnimator.SetBool("newDay", true);
        yield return new WaitForSeconds(.4166f);
        NextDayOverlayAnimator.SetBool("newDay", false);
        inventory.ResetPosition();
        SetCollectibleRequirements();
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            isInside = false;
        }
        collectibleText.enabled = false;
        collectibleText.GetComponentInParent<Image>().enabled = false;
    }

    void SetCollectibleRequirements()
    {
        maxCameras = GameObject.FindGameObjectsWithTag("camera").Length;
        maxGreenSrcs = GameObject.FindGameObjectsWithTag("greenscr").Length;
        maxGenerators = GameObject.FindGameObjectsWithTag("generator").Length;
        maxLights = GameObject.FindGameObjectsWithTag("light").Length;
        requiredCameras = UnityEngine.Random.Range(0, maxCameras + 1);
        requiredGreenSrcs = UnityEngine.Random.Range(0, maxGreenSrcs + 1);
        requiredGenerators = UnityEngine.Random.Range(0, maxGenerators + 1);
        requiredLights = UnityEngine.Random.Range(0, maxLights + 1);
        inventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        string textCameras = "";
        string textGreenScrs = "";
        string textGenerators = "";
        string textLights = "";
        string finalText = "";
        if (requiredCameras == 0)
        {
            textCameras = "Hi!. Today we don't need any Cameras, ";
        }
        else
        {
            textCameras = "Hi!. Today we need <color=yellow>" + requiredCameras + "</color> Cameras, ";
        }
        if (requiredGreenSrcs == 0)
        {
            textGreenScrs = "don't need any Green Screens, ";
        }
        else
        {
            textGreenScrs = "<color=yellow>" + requiredGreenSrcs + "</color> Green Screens, ";
        }
        if (requiredGenerators == 0)
        {
            textGenerators = "don't need any Generators and ";
        }
        else
        {
            textGenerators = "<color=yellow>" + requiredGenerators + "</color> Generators and ";
        }
        if (requiredLights == 0)
        {
            textLights = "don't need any Lights! Bring them here!";
        }
        else
        {
            textLights = "<color=yellow>" + requiredLights + "</color> Lights! Bring them here!";
        }
        if (requiredCameras == 0 && requiredGenerators == 0 && requiredGreenSrcs == 0 && requiredLights == 0)
        {
            finalText = "Hi there!... For today we don't need anything! You can deliver whatever you want!";
        }
        else
        {
            finalText = textCameras + textGreenScrs + textGenerators + textLights;
        }
        collectibleText.text = finalText;
        Debug.Log("You need " + requiredCameras + " cameras, " + requiredGreenSrcs + " greenscrs, " + requiredGenerators + " generators, and" + requiredLights + " lights");

    }
}
