﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    private GameObject scoreText;

    private int score = 0;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("Score");
        this.scoreText.GetComponent<Text>().text = "Score:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("SmallStarTag"))
        {
            score += 10;
            this.scoreText.GetComponent<Text>().text = "Score:" + score;
        }

        if (other.gameObject.CompareTag("LargeStarTag"))
        {
            score += 20;
            this.scoreText.GetComponent<Text>().text = "Score:" + score;
        }

        if (other.gameObject.CompareTag("LargeCloudTag"))
        {
            score += 15;
            this.scoreText.GetComponent<Text>().text = "Score:" + score;
        }

        if (other.gameObject.CompareTag("SmallCloudTag"))
        {
            score += 5;
            this.scoreText.GetComponent<Text>().text = "Score:" + score;
        }
    }
}