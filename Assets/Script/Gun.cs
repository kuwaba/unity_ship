using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    GameObject targetObj;
    //Vector3 targetPos;
    Quaternion targetRote;

    // Use this for initialization
    void Start () {
        targetObj = GameObject.Find("CharCamera");
        //targetPos = targetObj.transform.position;
        targetRote = targetObj.transform.rotation;
    }

    // Update is called once per frame
    void Update () {
        //transform.rotation =   targetRote;
        //transform.rotation = Quaternion.FromToRotation(targetObj.transform.up, transform.transform.up);
        var diff = (targetObj.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.FromToRotation(Vector3.back, diff);
    }
}
