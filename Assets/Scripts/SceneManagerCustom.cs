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
        DamageIndicator.SetActive(false);

    }

    // Update is called once per frame
    void Update() {
        Healthcount.text = health.ToString();
        //Debug.Log("Cube count:"+ GameObject.FindGameObjectsWithTag("Cube").Length);
        if (GameObject.FindGameObjectsWithTag("Cube").Length < 40  && GameObject.FindGameObjectsWithTag("targetImage").Length>0) {
            showWinnerMenu();
        }
    }

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
        WinnerHolder.SetActive(true);
        TargetImage.SetActive(false);
    }

    void hideDamageIndicator() {
        DamageIndicator.SetActive(false);

    }

    
}
