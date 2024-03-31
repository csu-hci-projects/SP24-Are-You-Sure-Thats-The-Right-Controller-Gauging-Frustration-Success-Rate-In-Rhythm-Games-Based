using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour {
    // Start is called before the first frame update
    private SpriteRenderer spriteRender;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;

    public KeyCode buttonToPress;

    void Start(){
        spriteRender = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(keyToPress) || Input.GetKeyDown(buttonToPress)){
            spriteRender.sprite = pressedImage;
        }

        if (Input.GetKeyUp(keyToPress) || Input.GetKeyUp(buttonToPress)){
            spriteRender.sprite = defaultImage;
        }
    }
}