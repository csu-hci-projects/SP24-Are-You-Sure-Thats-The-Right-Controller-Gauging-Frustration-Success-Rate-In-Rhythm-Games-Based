using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{

    public AudioSource music;

    public bool starPlaying;

    public FallingArrow beatScroller;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGood = 125;
    public int scorePerPerfect = 150;

    public int currentMultiplier; 
    public int multiplierTracker;
    public int[] multiplierThreshold;

    public Text scoreText;
    public Text multiplierText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missHits;

    public GameObject resultScreen;
    public Text percentHitText, normalText, goodText, perfectText, missedText, finalScoreText;

    // Start is called before the first frame update
    void Start(){
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;
        totalNotes = FindObjectsOfType<NotePressed>().Length;
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

        else{
            if (!music.isPlaying && !resultScreen.activeInHierarchy){
                resultScreen.SetActive(true);
                normalText.text = normalHits.ToString();
                goodText.text = goodHits.ToString();
                perfectText.text = perfectHits.ToString();
                missedText.text = missHits.ToString();

                float totalHits = normalHits + goodHits + perfectHits;
                float percentHit = totalHits / totalNotes * 100f;

                percentHitText.text = percentHit.ToString("F1") + "%";
                SaveToFile(totalHits, percentHit);
                finalScoreText.text = currentScore.ToString();
            }
        }
    }

    //CSV FILE STUFF
    //First is conversion to a csv format
    public string ToCSV(float totalHits, float percentHit)
    {
    return $"{this.totalNotes},{this.normalHits},{this.goodHits},{this.perfectHits},{this.missHits}, {totalHits}, {percentHit}";
    }
    //Second is adding to a file that is checked to make sure it is accesible across all session
     public void SaveToFile(float totalHits, float percentHit)
    {
        string saveFilePath = "Assets/Results/Data.csv";
            // Append data to the existing file
            using (StreamWriter writer = File.AppendText(saveFilePath))
            {
                writer.WriteLine(ToCSV(totalHits, percentHit));
            }
     
    }

    public void NoteHit(){
        Debug.Log("Hit");
        if(currentMultiplier - 1 < multiplierThreshold.Length){
            multiplierTracker += 1;
            if (multiplierThreshold[currentMultiplier - 1] <= multiplierTracker){
                multiplierTracker = 0;
                currentMultiplier += 1;
            }
        multiplierText.text = "Multiplier: x" + currentMultiplier;
        scoreText.text = "Score: " + currentScore;
        }

    }

    public void NormalHit(){
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
        normalHits++;
    }

    public void GoodHit(){
        currentScore += scorePerGood * currentMultiplier;
        NoteHit();
        goodHits++;
    }

    public void PerfectHit(){
        currentScore += scorePerPerfect * currentMultiplier;
        NoteHit();
        perfectHits++;
    }

    public void NoteMissed(){
        Debug.Log("Missed");
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiplierText.text = "Multiplier: x" + currentMultiplier;
        missHits++;
    }
}
