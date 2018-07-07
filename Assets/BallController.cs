using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    //得点を表示するテキスト
    private GameObject scoreText;

    //スコア計算用変数
    private int score = 0;

    // Use this for initialization
    void Start () {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
    }
	
	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
        if(this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    //得点を計算
    void OnCollisionEnter(Collision collision)
    {
        string yourTag = collision.gameObject.tag;

        if (yourTag == "SmallStarTag")
        {
            score += 10;
        }
        else if (yourTag == "LargeStarTag")
        {
            score += 20;
        }
        else if (yourTag == "SmallCloudTag")
        {
            score += 100;
        }
        else if (yourTag == "LargeCloudTag")
        {
            score += 500;
        }
        SetScore();
    }

    void SetScore()
    {
        //得点をアップデート
        this.scoreText.GetComponent<Text>().text = "Score:" + this.score;
    }
}
