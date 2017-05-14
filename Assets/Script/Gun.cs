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
        targetRote = new Quaternion(0, 0, 0, targetObj.transform.rotation.w);
    }

    // Update is called once per frame
    void Update () {
        //transform.rotation =   targetRote;
        //transform.rotation = Quaternion.FromToRotation(targetObj.transform.up, transform.transform.up);
        var diff = (targetObj.transform.position - transform.position).normalized;
        var diffy = targetObj.transform.eulerAngles.y - transform.eulerAngles.y;

        //transform.Rotate(new Vector3(transform.eulerAngles.x, targetObj.transform.eulerAngles.y, transform.eulerAngles.z));
        //transform.rotation = Quaternion.FromToRotation(Vector3.back, diff);
        transform.Rotate(new Vector3(0,1,0), diffy);

    }
}
