using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCamera : MonoBehaviour {
    //http://tech.pjin.jp/blog/2016/11/04/unity_skill_5/
    GameObject targetObj;
    Vector3 targetPos;
    //Vector3 targetRote;

    // Use this for initialization
    void Start () {
        targetObj = GameObject.Find("Boat");
        targetPos = targetObj.transform.position;
        //targetRote = targetObj.transform.Rotate;
    }
	
	// Update is called once per frame
	void Update () {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        // マウスの右クリックを押している間
        //if (Input.GetMouseButton(1))
        //{
            // マウスの移動量
            float mouseInputX = Input.GetAxis("Mouse X");
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);
        //}
    }
}
