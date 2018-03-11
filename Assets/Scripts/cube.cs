using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Building block for the enemy infrastructure
public class cube : MonoBehaviour {

    private int health = 1;
    public GameObject balst;
    private GameObject parentTarget;

    private Transform iniTransform;

    // Use this for initialization
    void Start () {
        //get the AR parent
        parentTarget = GameObject.Find("/ARCamera/ImageTarget");
        //Save a local copy of the initial transformation 
        //Which will come handy to destroy the object
        iniTransform = gameObject.transform;

    }
	
	// Update is called once per frame
	void Update () {
        if (iniTransform != gameObject.transform) {
            //If the initial transformation ! eq to final
            //Switch on the gravity
            GetComponent<Rigidbody>().useGravity = true;
        }
        
    }

     

    void reduceHealth() {
        //Method for reducing the helth of the cube
        //Called from the bullet script when hit detected
        health-=1;
        //Debug.Log("Health-----------------------" + health);
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        Destroy(gameObject,5);
        if (health==0)
        {

            GameObject blastInst = Instantiate(balst, gameObject.transform) as GameObject;
            blastInst.transform.parent = parentTarget.transform;
            GetComponent<AudioSource>().Play();
            Destroy(blastInst, 3);
            Destroy(gameObject);
        }
        
       
    }
}
