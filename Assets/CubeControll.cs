using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControll : MonoBehaviour {

    //キューブの移動速度
    private float speed = -0.2f;

    //消滅位置
    private float deadLine = -10;

    //地面の位置
    private float groundLevel = -3.0f;

    //音を鳴らすためのコンポーネントを入れる
    private AudioSource sound;

    // Use this for initialization
    void Start () {

        //音を鳴らすためのコンポーネントを取得する
        this.sound= GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {

        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        //画面外に出たら破棄する
        if (transform.position.x < this.deadLine) {
            Destroy(gameObject);
        }

        //地面に接触していないときはボリュームを0にする
        GetComponent<AudioSource>().volume = (transform.position.y > groundLevel) ? 1 : 0;

        //地面とCubeに接触したとき音を鳴らす
        if (transform.position.y<=groundLevel ) {
            GetComponent<AudioSource>().volume = 1;

        }

        //ユニティちゃんと接触したときはボリュームを0にする
        //void OnCollisionEnter2D (Collision other) {
            //GetComponent<AudioSource>().volume = 0;
        

    }
}
