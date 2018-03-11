using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARcamera : MonoBehaviour {
    public GameObject SceneManager;
    public Button fireButton;
    public GameObject bulletIn;
    public GameObject parentTarget;
    public GameObject crossair;
    public GameObject demoTarget;
    // Use this for initialization
    void Start () {
        fireButton.onClick.AddListener(OnButtonDown);
    }


    void OnButtonDown()
    {

        GameObject bullet = Instantiate(bulletIn, crossair.transform ) as GameObject;
        bullet.transform.parent = parentTarget.transform;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        //bullet.transform.rotation = Camera.main.transform.rotation;
        //bullet.transform.position = Camera.main.transform.position;
        Vector3 direction = gameObject.transform.position - demoTarget.transform.position;
        //rb.AddForce(direction*Time.deltaTime,ForceMode.Impulse);
        rb.AddForce(gameObject.transform.forward * 500f);
        Destroy(bullet, 10);

        GetComponent<AudioSource>().Play();
        

    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    { 
        SceneManager.SendMessage("deductHealth");
    }
}
