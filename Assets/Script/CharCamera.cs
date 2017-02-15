using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharCamera : MonoBehaviour {
    //http://tech.pjin.jp/blog/2016/11/04/unity_skill_5/
    GameObject targetObj;
    Vector3 targetPos;
    //Vector3 targetRote;
    public Text Speedtext;
    // Use this for initialization
    private float speeduptime;
    void Start () {
        targetObj = GameObject.Find("Boat");
        targetPos = targetObj.transform.position;
        //targetRote = targetObj.transform.Rotate;
        Speedtext.text = "Speed 0.0 km/s";
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
        speeduptime += Time.deltaTime;
        if (speeduptime >1)
        {
            speeduptime = 0;
            SpeedUpdate();
        }
    }

    void SpeedUpdate()
    {
        Rigidbody rig = targetObj.GetComponent<Rigidbody>();
        Speedtext.text = (rig.velocity.magnitude *10).ToString() + "km/s";
    }
}
