using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FallingArrow : MonoBehaviour{
    // Start is called before the first frame update
    public float beatTempo;
    public bool hasStarted;
    void Start(){
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update(){
        if (!hasStarted){

        }

        else {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
}