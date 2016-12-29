using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //public float speed = 5;
    public int power = 1000;
    public int back_power = 200;
    public float trun_speed = 0.2f; 


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        // 右・左
        //float x = Input.GetAxisRaw("Horizontal");
        //左右への回転
        float y = 0;
        y += Time.deltaTime * 10 * Input.GetAxisRaw("Horizontal");
        //transform.rotation = Quaternion.Euler(0, y, 0);


        // 上・下
        float updown = Input.GetAxisRaw("Vertical");

        // 移動する向きを求める
        //Vector2 direction = new Vector2(x, y).normalized;

        // 移動する向きとスピードを代入する
        //GetComponent<Rigidbody2D>().velocity = direction * speed;

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        transform.Rotate(new Vector3(0, 1, 0), Input.GetAxisRaw("Horizontal")* trun_speed);
        // rigidbodyのx軸（横）とz軸（奥）に力を加える
        if (updown > 0)
        {
            rigidbody.AddForce(transform.forward *  power);
        }else if(updown <0)
        {
            rigidbody.AddForce(transform.forward  * updown * back_power);
        }
        //gidbody.AddForce(transform.forward * (-1));
    }
}
