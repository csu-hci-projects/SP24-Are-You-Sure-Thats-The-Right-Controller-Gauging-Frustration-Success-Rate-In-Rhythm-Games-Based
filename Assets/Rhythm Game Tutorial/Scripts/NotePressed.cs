using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class NotePressed : MonoBehaviour{
    public bool canBePress;
    public KeyCode KeyToPress;

    public KeyCode xboxButtonToPress;

    public KeyCode playstationButtons;

    private bool obtained = false;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyToPress) || Input.GetKeyDown(xboxButtonToPress) || Input.GetKeyDown(playstationButtons)){
            if (canBePress){

                // GameManager.instance.NoteHit();
                obtained = true;
                gameObject.SetActive(false);

                if(Mathf.Abs(transform.position.y) > 0.25){
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }

                else if(Mathf.Abs(transform.position.y) > 0.05f){
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }

                else{
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
            }

        }
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Activator"){
            canBePress = true;

        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Activator"){
            canBePress = false;
            if(!obtained){
                GameManager.instance.NoteMissed();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            }
        }
    }
}