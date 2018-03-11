using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbarian : MonoBehaviour {


    public float x = 0;
    public float y = 0;
    public float z = 0;
    public float speed = .008f;

    // Use this for initialization
    void Start () {
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        z = gameObject.transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {



        gameObject.transform.position = new Vector3(
            gameObject.transform.position.x+ speed,
            y,
            z
            );
    }
}
