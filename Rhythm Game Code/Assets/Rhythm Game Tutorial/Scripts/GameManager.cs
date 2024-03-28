using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    public AudioSource music;

    public bool starPlaying;

    public FallingArrow beatScroller;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start(){
        instance = this;
    }

    // Update is called once per frame
    void Update(){
        if (!starPlaying){
            if (Input.anyKeyDown){
                starPlaying = true;
                beatScroller.hasStarted = true;

                music.Play();
            }
        }
    }

    public void NoteHit(){
        Debug.Log("Hit");

    }

    public void NoteMissed(){
        Debug.Log("Missed");

    }
}
