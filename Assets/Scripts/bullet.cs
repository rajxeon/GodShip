using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public GameObject blast;
    public GameObject parentTarget;
    

    // Use this for initialization
    void Start () {
		parentTarget= GameObject.Find("/ARCamera/ImageTarget");
        //Debug.Log(parentTarget.name);
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Vector3.back * 1 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col) {
        //Debug.Log("Collision detected with -------------- "+col.gameObject.name);
        if (col.gameObject.CompareTag("Cube")) {
            col.gameObject.SendMessage("reduceHealth");
        }
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.SendMessage("Kill");
        }

        GameObject blastInst= Instantiate(blast,gameObject.transform) as GameObject;
        blastInst.transform.parent = parentTarget.transform;
        GetComponent<AudioSource>().Play();
        Destroy(blastInst, 3);
        Destroy(gameObject);

        //Debug.Log("collisionasd");
    }
}
