using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour {

    private int health = 1;
    public GameObject balst;
    private GameObject parentTarget;

    private Transform iniTransform;

    // Use this for initialization
    void Start () {
        parentTarget = GameObject.Find("/ARCamera/ImageTarget");
        iniTransform = gameObject.transform;

    }
	
	// Update is called once per frame
	void Update () {
        if (iniTransform != gameObject.transform) {
            
            GetComponent<Rigidbody>().useGravity = true;
        }
        
    }

     

    void reduceHealth() {
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
