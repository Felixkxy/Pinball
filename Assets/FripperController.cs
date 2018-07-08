using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

	// Use this for initialization
	void Start () {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
		
        //左矢印キーを押した時左フリッパーを動かす
        if(Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if(Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }


        //タッチする際の処理
        if (Input.touchCount > 0)
        {
            //タッチ情報を取得
            Touch touch = Input.GetTouch(0);
            //左画面に触れた時左フリッパーを動かす
            if (touch.phase == TouchPhase.Began && touch.position.x <= Screen.width / 2 && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            //左画面に止まった時左フリッパーを動かす
            if (touch.phase == TouchPhase.Stationary && touch.position.x <= Screen.width / 2 && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            //右画面に触れた時右フリッパーを動かす
            if (touch.phase == TouchPhase.Began && touch.position.x >= Screen.width / 2 && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            //右画面に止まった時右フリッパーを動かす
            if (touch.phase == TouchPhase.Stationary && touch.position.x >= Screen.width / 2 && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            //画面から離れた時フリッパーを戻す
            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                SetAngle(this.defaultAngle);
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle (float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
