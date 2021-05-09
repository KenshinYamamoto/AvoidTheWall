using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour
{
    //Rigidbody2Dを入れる
    private Rigidbody2D rb2d;

    //力を入れる
    private Vector2 force;

    //CommonTextを入れる
    private GameObject commonText;

    //カウントダウンの数字を入れる
    private float count = 3.0f;

    //ステートナンバー
    private int stateNumber = 0;

    //タイトルに戻るための判定をするカウンタ
    private float backTitleCount = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbodyのcomponentを入れる
        rb2d = GetComponent<Rigidbody2D>();

        //重力をなくす
        rb2d.gravityScale = 0.0f;
        
        //上向きの力をかける
        force = new Vector2(0.0f, 500.0f);

        //CommonTextを探してくる
        commonText = GameObject.Find("CommonText");

        //色を白色にする
        commonText.GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        //カウントダウンを表示する
        commonText.GetComponent<Text>().text = "3";
    }

    // Update is called once per frame
    void Update()
    {
        //カウントの更新
        count -= Time.deltaTime;

        //ステートマシン
        switch (stateNumber)
        {
            //待機
            case 0:
                {
                    if(count < 0.0f)
                    {
                        //ゲームを開始する
                        SystemDaemon.isRun = true;

                        //重力を元に戻す
                        rb2d.gravityScale = 2.5f;

                        //カウントダウンを消す
                        commonText.GetComponent<Text>().text = "";

                        //色を赤色にする
                        commonText.GetComponent<Text>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);

                        stateNumber = 3;
                    }
                    else if(count < 1.0f)
                    {
                        stateNumber = 1;
                    }
                    else if(count < 2.0f)
                    {
                        stateNumber = 2;
                    }
                }break;

            //2を表示する
            case 1:
                {
                    //1を表示する
                    commonText.GetComponent<Text>().text = "1";

                    //戻る
                    stateNumber = 0;
                }
                break;

            //2を表示する
            case 2:
                {
                    //2を表示する
                    commonText.GetComponent<Text>().text = "2";

                    //戻る
                    stateNumber = 0;
                }break;

            //ゲームを実行
            case 3:
                {
                    if (SystemDaemon.isRun)
                    {
                        //Spaceが押されたとき
                        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                        {
                            //力をかけて上に動かす
                            rb2d.AddForce(force);
                        }

                        if (transform.position.y <= -6.5f)
                        {
                            //ゲームを止める
                            SystemDaemon.isRun = false;

                            //GameOverを表示する
                            commonText.GetComponent<Text>().text = "GAMEOVER";

                            //タイトルに戻る
                            stateNumber = 4;

                            //消す
                            //Destroy(gameObject);
                        }
                    }
                }
                break;

            //タイトルに戻る
            case 4:
                {
                    //backTitleCountを更新
                    backTitleCount += Time.deltaTime;

                    //2秒経ったら
                    if (backTitleCount >= 2.0f)
                    {
                        //戻る
                        SystemDaemon.LoadScene("Title");
                    }
                }
                break;
        }
    }

    //UnityちゃんがWallに当たったら
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (SystemDaemon.isRun)
        {
            if (collision.gameObject.tag == "Wall")
            {
                //ゲームを止める
                SystemDaemon.isRun = false;

                //GameOverを表示する
                commonText.GetComponent<Text>().text = "GAMEOVER";

                //タイトルに戻る
                stateNumber = 4;
            }
        }
    }
}
