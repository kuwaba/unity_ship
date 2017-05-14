using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expload : MonoBehaviour {
    public GameObject ExploadObj;
    public GameObject ExploadPos;
    // Update is called once per frame
    void Update()
    {
        //スペースキーを押したら
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(ExploadObj, ExploadPos.transform.position, Quaternion.identity);
        }
    }
}
