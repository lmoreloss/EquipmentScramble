using UnityEngine;

public class MenuControls : MonoBehaviour
{

    [SerializeField]
    GameObject menuUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Time.timeScale = 0;
    }

    public void PlayButton(){
        menuUI.SetActive(false);
        Time.timeScale = 1;
    }

    
}
