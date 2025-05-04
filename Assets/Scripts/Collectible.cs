using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    PlayerInventory playerInv;
    [SerializeField]
    Vector3 scaleChange = new Vector3(0.01f, 0.01f, 0);

    void Start(){

        playerInv = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    void Update(){
        if (Time.frameCount%10==0){
            growShrink();
        }
        
    }

    void growShrink(){
        transform.localScale += scaleChange;
        if(transform.localScale.x <= 1 || transform.localScale.x >= 1.2){
            scaleChange = -scaleChange;
        }
    }


    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.name);
        if (col.name == "Player"){
            string tag = transform.tag;
            playerInv.IncreaseCollectible(tag+"s");
            Destroy(gameObject);
        }else{
            transform.Translate(UnityEngine.Random.Range(-1, 2), UnityEngine.Random.Range(-1, 2), 0);
        }
    }
    void OnTriggerStay2D(Collider2D col){
        if(col){
            transform.Translate(UnityEngine.Random.Range(-1, 2), UnityEngine.Random.Range(-1, 2), 0);
        }
    }
}
