using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uav : MonoBehaviour {

    public float speed = 10f; 
    public GameObject blast; 
    public int  radius=1; 
    public GameObject bulletIn;
    public GameObject demoTarget;

    private GameObject parentTarget;
    private GameObject childObj;
    private Transform initTransform;


    private bool isAiming = false;

	// Use this for initialization
	void Start () {
        childObj = transform.Find("DT").gameObject;
        parentTarget = GameObject.Find("/ARCamera/ImageTarget");
        InvokeRepeating("aim", Random.Range(10,15),Random.Range(5,20));
        initTransform = gameObject.transform;
        

    }

    private void OnEnable()
    {
        InvokeRepeating("fireMode", 2, 2);
    }



    // Update is called once per frame
    void Update () {
        transform.RotateAround(transform.parent.position, new Vector3(0,0 , radius), speed * Time.deltaTime);
        if (isAiming) {
            //transform.LookAt(hero.transform);
        }
        
        
    }

    void fireMode() {
        if (!isAiming)
        {
            childObj.SetActive(true);
            isAiming = true;
        }
        else {
            childObj.SetActive(false);
            isAiming = false;
        }
    }

    void Kill() {
        GameObject blastInst = Instantiate(blast, gameObject.transform) as GameObject;
        blastInst.transform.parent = parentTarget.transform;
        GetComponent<AudioSource>().Play();
        Destroy(blastInst, 3);
        Destroy(gameObject);
    }

    void aim() {
        isAiming = !isAiming;
       // Debug.Log("Aim changed---------");
    }
}
