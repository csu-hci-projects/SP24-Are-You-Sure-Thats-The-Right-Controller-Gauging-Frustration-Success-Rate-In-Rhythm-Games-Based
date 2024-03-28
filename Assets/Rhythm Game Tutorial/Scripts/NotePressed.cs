using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePressed : MonoBehaviour{
    public bool canBePress;
    public KeyCode KeyToPress;

    private bool obtained = false;

    
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyToPress)){
            if (canBePress){

                GameManager.instance.NoteHit();
                obtained = true;
                gameObject.SetActive(false);
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

            }
        }
    }
}