using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{    public GameObject ExploadObj;
    //public GameObject ExploadPos;
    // 弾のスピード
    public int speed = 10;

    void Start()
    {
        
    }



    // 弾が何らかのトリガーに当たった時に呼び出される
    void OnTriggerEnter(Collider  other)
    {

        // 弾の削除
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Stage")
        {
            Destroy( Instantiate(ExploadObj, this.transform.position, Quaternion.identity),3.0f);
            Destroy(gameObject);
        }
    }
}