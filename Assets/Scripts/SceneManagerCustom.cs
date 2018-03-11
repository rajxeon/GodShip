using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManagerCustom : MonoBehaviour {


    public GameObject GameOverMenu;
    public GameObject DamageIndicator;
    public GameObject TargetImage;
    public GameObject WinnerHolder;
    public Text Healthcount;
    public int health = 10;

    // Use this for initialization
    void Start() {
        //Set the DamageIndicator visibility to false
        DamageIndicator.SetActive(false);

    }

    // Update is called once per frame
    void Update() {
        //Update the health HUD
        Healthcount.text = health.ToString();
        //Debug.Log("Cube count:"+ GameObject.FindGameObjectsWithTag("Cube").Length);
        if (GameObject.FindGameObjectsWithTag("Cube").Length < 40  && GameObject.FindGameObjectsWithTag("targetImage").Length>0) {
            showWinnerMenu();
        }
    }

    //Deduct the health when get hit by enemy bullet
    void deductHealth() {
        DamageIndicator.SetActive(true);
        Invoke("hideDamageIndicator", 0.1f);
        //Play hit sound
        GetComponent<AudioSource>().Play();
        health--;
       // Debug.Log("Health deducted " + health);
        if (health == 0) {
            GameOverMenu.SetActive(true);
            TargetImage.SetActive(false);
        }
    }

    void showWinnerMenu() {
        //Method for showing the winner menu
        WinnerHolder.SetActive(true);
        TargetImage.SetActive(false);
    }

    void hideDamageIndicator() {
        //Method for hiding the red overlay damage indicator
        DamageIndicator.SetActive(false);

    }

    
}
