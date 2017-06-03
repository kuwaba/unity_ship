using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    public GameObject shellPrefab;
    public float shotSpeed;
    public AudioClip shotSound;

    public GameObject skellPrefab;
    GameObject[] skells;
    void Start()
    {
        skells = new GameObject[10];
        for(int i = 0; i < 10; i++)
        {
            skells[i] = (GameObject)Instantiate(skellPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            skells[i].SetActive(true);
            skells[i].transform.parent = transform;
        }
    }
    void Update()
    {

        //TrajectoryCalculate.Force(transform.position, force, shellPrefab.rigidbody.mass, Physics.gravity, 1, time);
        // もしも「Fire1」というボタンが押されたら（条件）
        if (Input.GetButtonDown("Fire1"))
        {

            // ①Shotという名前の関数（命令ブロック）を実行する。
            Shot1();

            // ②効果音を再生する。
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
        }

        orbit_estimation();

    }


    public void Shot1()
    {

        // プレファブから砲弾(Shell)オブジェクトを作成し、それをshellという名前の箱に入れる。
        GameObject shell = (GameObject)Instantiate(shellPrefab, transform.position, Quaternion.identity);

        // Rigidbodyの情報を取得し、それをshellRigidbodyという名前の箱に入れる。
        Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();

        // shellRigidbodyにz軸方向の力を加える。
        shellRigidbody.AddForce(transform.forward * shotSpeed);

    }

    public void orbit_estimation()
    {
        var force = transform.forward * shotSpeed;
        
        // Rigidbodyの情報を取得し、それをshellRigidbodyという名前の箱に入れる。
        Rigidbody shellRigidbody = shellPrefab.GetComponent<Rigidbody>();

 
        
        for (int i = 0; i < 10; i++)
        {
            var pos = TrajectoryCalculate.Force(transform.position, force, shellRigidbody.mass, Physics.gravity, 1, 0.2f*i);
            skells[i].transform.position = pos;
        }
    }
}
