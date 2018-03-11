using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank : MonoBehaviour {

    

    private GameObject target;
    private Vector3 targetPoint;
    private Quaternion targetRotation;

    void Start()
    {
        target = GameObject.Find("/ARCamera/ImageTarget");
       
    }

    void Update()
    {
        targetRotation = new Quaternion(target.transform.position.x, 1, 0, 0);
        transform.rotation = Quaternion.Slerp(
            new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z,0),
            new Quaternion(targetRotation.x, targetRotation.y, targetRotation.z, 0), Time.deltaTime * 2.0f);
    }
}
