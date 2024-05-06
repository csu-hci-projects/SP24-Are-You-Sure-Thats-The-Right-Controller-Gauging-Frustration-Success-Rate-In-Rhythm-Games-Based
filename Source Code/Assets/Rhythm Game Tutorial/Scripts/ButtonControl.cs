using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour {
    // Start is called before the first frame update
    private SpriteRenderer spriteRender;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;

    public KeyCode xboxButtonToPress;
    
    public KeyCode playstationButtons;
    
    public KeyCode wiiController;


    void Start(){
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(keyToPress) || Input.GetKeyDown(xboxButtonToPress) || Input.GetKeyDown(playstationButtons) || Input.GetKeyDown(wiiController)){
            spriteRender.sprite = pressedImage;
        }

        if (Input.GetKeyUp(keyToPress) || Input.GetKeyUp(xboxButtonToPress) || Input.GetKeyUp(playstationButtons)){
            spriteRender.sprite = defaultImage;
        }

        
    }
}