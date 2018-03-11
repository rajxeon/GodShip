using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dt : MonoBehaviour {

    public GameObject bulletIn;
    public GameObject demoTarget;

    private GameObject parentTarget;
    //Camera camera;
    ARcamera camera;
    // Use this for initialization
    void Start () {
        parentTarget = GameObject.Find("/ARCamera/ImageTarget");
        
        camera = GetComponent<ARcamera>();
    }

    private void OnEnable()
    {
        InvokeRepeating("fire", 2, 2);
    }
    private void OnDisable()
    {
        CancelInvoke("fire");
    }




    // Update is called once per frame
    void Update () {
		
	}

    void fire()
    {
        Debug.Log("Fired weapons....................................");
        GameObject bullet = Instantiate(bulletIn, transform.position,Quaternion.identity) as GameObject;
        //Instantiate()
        bullet.transform.parent = parentTarget.transform;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        //bullet.transform.rotation = Camera.main.transform.rotation;
        //bullet.transform.position = Camera.main.transform.position;
        Vector3 direction = gameObject.transform.position - demoTarget.transform.position;
        rb.AddForce(-direction*1f,ForceMode.Impulse);
        //rb.AddForce(direction * 50f);
        Destroy(bullet, 4);

        //GetComponent<AudioSource>().Play();
    }
}
