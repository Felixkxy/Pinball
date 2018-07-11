using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        Touch[] myTouches = Input.touches;
        for (int i = 0; i < Input.touchCount; i++)
        {
            //画面左の処理
            if (myTouches[i].position.x <= Screen.width / 2)
            {
                //左画面に触れた時左フリッパーを動かす
                if (myTouches[i].phase != TouchPhase.Ended && myTouches[i].phase != TouchPhase.Canceled && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
                //左画面から離れた時に左フリッパーを戻す
                if (myTouches[i].phase != TouchPhase.Began && myTouches[i].phase != TouchPhase.Moved && myTouches[i].phase != TouchPhase.Stationary && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
            }
            //画面右の処理
            if (myTouches[i].position.x >= Screen.width / 2)
            {
                //右画面に触れた時左フリッパーを動かす
                if (myTouches[i].phase != TouchPhase.Ended && myTouches[i].phase != TouchPhase.Canceled && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);                    
                }
                //右画面から離れた時に右フリッパーを戻す
                if (myTouches[i].phase != TouchPhase.Began && myTouches[i].phase != TouchPhase.Moved && myTouches[i].phase != TouchPhase.Stationary && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
            }
        } 
                                                                                                 
        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}