using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallGenerator : MonoBehaviour
{
    //Prefabを入れる
    public GameObject[] prefabs;

    //ステートナンバー
    private int stateNumber = 0;

    //乱数を入れる
    private int dice;

    //経過時間
    private float time = 0.0f;

    //Prefabを生成するスパン
    private float span = 0.0f;

    //タイトルに戻るまでの時間カウント
    private float backTitleCount = 0.0f;

    //タイトルに戻るための判定
    private bool isbacked = false;

    //CommonTextを入れる
    private GameObject commonText;

    //カメラを入れる
    private GameObject mainCamera;

    //難易度を判定する数字(EASY = 0),(NORMAL = 1),(HARD = 2),(MIX = 3),(ASCENDING = 4)
    private int difficultyNumber = SystemDaemon.difficultyNumber;

    // Start is called before the first frame update
    void Start()
    {
        //CommonTextを探してくる
        commonText = GameObject.Find("CommonText");

        //MainCameraを探してくる
        mainCamera = GameObject.Find("Main Camera");

        //難易度によって背景の色を変える
        switch (difficultyNumber)
        {
            //Easyだったら
            case 0:
                {
                    //水色にする
                    mainCamera.GetComponent<Camera>().backgroundColor = new Color(0.0f, 0.42f, 1.0f, 1.0f);
                }break;

            //Normalだったら
            case 1:
                {
                    //黄緑にする
                    mainCamera.GetComponent<Camera>().backgroundColor = new Color(0.15f, 0.75f, 0.18f, 1.0f);
                }
                break;

            //Hardだったら
            case 2:
                {
                    //黄色にする
                    mainCamera.GetComponent<Camera>().backgroundColor = new Color(0.89f, 0.86f, 0.06f, 1.0f);
                }
                break;

            //Mixだったら
            case 3:
                {
                    //紫色にする
                    mainCamera.GetComponent<Camera>().backgroundColor = new Color(0.38f, 0.18f, 0.72f, 1.0f);
                }
                break;

            //Ascendingだったら
            case 4:
                {
                    //赤色にする
                    mainCamera.GetComponent<Camera>().backgroundColor = new Color(0.88f, 0.21f, 0.25f, 1.0f);

                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //経過時間の更新
        time += Time.deltaTime;

        //スパンの更新
        span += Time.deltaTime;

        if (SystemDaemon.isRun)
        {
            switch (difficultyNumber)
            {
                //Easyだったら
                case 0:
                    {
                        switch (stateNumber)
                        {
                            case 0:
                                {
                                    if (time <= 30.0f)
                                    {
                                        stateNumber = 1;
                                    }
                                    else if (time >= 31.5f)
                                    {
                                        stateNumber = 2;
                                    }
                                }
                                break;

                            //Easy
                            case 1:
                                {
                                    //1秒経ったら
                                    if (span >= 1.0f)
                                    {
                                        //乱数を振る(0以上4未満)
                                        dice = Random.Range(0, 4);

                                        //spanを0で初期化する
                                        span = 0.0f;

                                        switch (dice)
                                        {
                                            case 0:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, -7.5f);
                                                }
                                                break;

                                            case 1:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, -6.0f);
                                                }
                                                break;

                                            case 2:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 6.0f);
                                                }
                                                break;

                                            case 3:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 0.0f);
                                                }
                                                break;

                                            default: break;
                                        }

                                        stateNumber = 0;

                                        //↑case0に戻る
                                    }
                                    //5秒経ってなかったら
                                    else
                                    {
                                        stateNumber = 0;

                                        //↑case0に戻る
                                    }
                                }
                                break;

                            //1回だけクリアを表示する
                            case 2:
                                {
                                    //ゲームを止める
                                    SystemDaemon.isRun = false;

                                    //色を黄色にする
                                    commonText.GetComponent<Text>().color = new Color(1.0f, 1.0f, 0.0f, 1.0f);

                                    //Clearを表示する
                                    commonText.GetComponent<Text>().text = "CLEAR!";

                                    //タイトルに戻るための判定をONにする
                                    isbacked = true;
                                }
                                break;

                            default: break;
                        }
                    }break;

                //Normalだったら
                case 1:
                    {
                        switch (stateNumber)
                        {
                            case 0:
                                {
                                    if (time <= 30.0f)
                                    {
                                        stateNumber = 1;
                                    }
                                    else if (time >= 31.5f)
                                    {
                                        stateNumber = 2;
                                    }
                                }
                                break;

                            //Normal
                            case 1:
                                {
                                    //1秒経ったら
                                    if (span >= 1.0f)
                                    {
                                        //乱数を振る(4以上8未満)
                                        dice = Random.Range(4, 8);

                                        //spanを0で初期化する
                                        span = 0.0f;

                                        switch (dice)
                                        {
                                            case 4:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 6.5f);
                                                }
                                                break;

                                            case 5:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, -5.0f);
                                                }
                                                break;

                                            case 6:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 5.0f);
                                                }
                                                break;

                                            case 7:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 0.0f);
                                                }
                                                break;

                                            default: break;
                                        }

                                        stateNumber = 0;

                                        //↑case0に戻る
                                    }
                                    //5秒経ってなかったら
                                    else
                                    {
                                        stateNumber = 0;

                                        //↑case0に戻る
                                    }
                                }
                                break;

                            //1回だけクリアを表示する
                            case 2:
                                {
                                    //ゲームを止める
                                    SystemDaemon.isRun = false;

                                    //色を黄色にする
                                    commonText.GetComponent<Text>().color = new Color(1.0f, 1.0f, 0.0f, 1.0f);

                                    //Clearを表示する
                                    commonText.GetComponent<Text>().text = "CLEAR!";

                                    //タイトルに戻るための判定をONにする
                                    isbacked = true;
                                }
                                break;

                            default: break;
                        }
                    }
                    break;

                //Hardだったら
                case 2:
                    {
                        switch (stateNumber)
                        {
                            case 0:
                                {
                                    if (time <= 30.0f)
                                    {
                                        stateNumber = 1;
                                    }
                                    else if (time >= 31.5f)
                                    {
                                        stateNumber = 2;
                                    }
                                }
                                break;

                            //Normal
                            case 1:
                                {
                                    //1秒経ったら
                                    if (span >= 1.0f)
                                    {
                                        //乱数を振る(8以上12未満)
                                        dice = Random.Range(8, 12);

                                        //spanを0で初期化する
                                        span = 0.0f;

                                        switch (dice)
                                        {


                                            case 8:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 5.5f);
                                                }
                                                break;

                                            case 9:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, -4.0f);
                                                }
                                                break;

                                            case 10:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 4.0f);
                                                }
                                                break;

                                            case 11:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 0.0f);
                                                }
                                                break;

                                            default: break;
                                        }

                                        stateNumber = 0;

                                        //↑case0に戻る
                                    }
                                    //5秒経ってなかったら
                                    else
                                    {
                                        stateNumber = 0;

                                        //↑case0に戻る
                                    }
                                }
                                break;

                            //1回だけクリアを表示する
                            case 2:
                                {
                                    //ゲームを止める
                                    SystemDaemon.isRun = false;

                                    //色を黄色にする
                                    commonText.GetComponent<Text>().color = new Color(1.0f, 1.0f, 0.0f, 1.0f);

                                    //Clearを表示する
                                    commonText.GetComponent<Text>().text = "CLEAR!";

                                    //タイトルに戻るための判定をONにする
                                    isbacked = true;
                                }
                                break;

                            default: break;
                        }
                    }
                    break;

                //Mixだったら
                case 3:
                    {
                        switch (stateNumber)
                        {
                            case 0:
                                {
                                    if (time <= 30.0f)
                                    {
                                        stateNumber = 1;
                                    }
                                    else if (time >= 31.5f)
                                    {
                                        stateNumber = 2;
                                    }
                                }
                                break;

                            //Normal
                            case 1:
                                {
                                    //1秒経ったら
                                    if (span >= 1.0f)
                                    {
                                        //乱数を振る(1以上12未満)
                                        dice = Random.Range(1, 12);

                                        //spanを0で初期化する
                                        span = 0.0f;

                                        switch (dice)
                                        {
                                            case 0:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, -7.5f);
                                                }
                                                break;

                                            case 1:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, -6.0f);
                                                }
                                                break;

                                            case 2:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 6.0f);
                                                }
                                                break;

                                            case 3:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 0.0f);
                                                }
                                                break;

                                            case 4:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 6.5f);
                                                }
                                                break;

                                            case 5:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, -5.0f);
                                                }
                                                break;

                                            case 6:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 5.0f);
                                                }
                                                break;

                                            case 7:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 0.0f);
                                                }
                                                break;

                                            case 8:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 5.5f);
                                                }
                                                break;

                                            case 9:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, -4.0f);
                                                }
                                                break;

                                            case 10:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 4.0f);
                                                }
                                                break;

                                            case 11:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 0.0f);
                                                }
                                                break;

                                            default: break;
                                        }

                                        stateNumber = 0;

                                        //↑case0に戻る
                                    }
                                    //5秒経ってなかったら
                                    else
                                    {
                                        stateNumber = 0;

                                        //↑case0に戻る
                                    }
                                }
                                break;

                            //1回だけクリアを表示する
                            case 2:
                                {
                                    //ゲームを止める
                                    SystemDaemon.isRun = false;

                                    //色を黄色にする
                                    commonText.GetComponent<Text>().color = new Color(1.0f, 1.0f, 0.0f, 1.0f);

                                    //Clearを表示する
                                    commonText.GetComponent<Text>().text = "CLEAR!";

                                    //タイトルに戻るための判定をONにする
                                    isbacked = true;
                                }
                                break;

                            default: break;
                        }
                    }
                    break;

                //Ascendingだったら
                case 4:
                    {
                        switch (stateNumber)
                        {
                            case 0:
                                {
                                    if (time <= 30.0f)
                                    {
                                        stateNumber = 1;
                                    }
                                    else if (time <= 60.0f)
                                    {
                                        stateNumber = 2;
                                    }
                                    else if (time <= 90.0f)
                                    {
                                        stateNumber = 3;
                                    }
                                    else if (time <= 100.0f)
                                    {
                                        stateNumber = 2;
                                    }
                                    else if (time <= 110.0f)
                                    {
                                        stateNumber = 1;
                                    }
                                    else if (time >= 111.5f)
                                    {
                                        stateNumber = 4;
                                    }
                                }
                                break;

                            //1回目のeasyMode
                            case 1:
                                {
                                    //1秒経ったら
                                    if (span >= 1.0f)
                                    {
                                        //乱数を振る(0以上4未満)
                                        dice = Random.Range(0, 4);

                                        //spanを0で初期化する
                                        span = 0.0f;

                                        switch (dice)
                                        {
                                            case 0:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, -7.5f);
                                                }
                                                break;

                                            case 1:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, -6.0f);
                                                }
                                                break;

                                            case 2:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 6.0f);
                                                }
                                                break;

                                            case 3:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 0.0f);
                                                }
                                                break;

                                            default: break;
                                        }

                                        stateNumber = 0;

                                        //↑case0に戻る
                                    }
                                    //5秒経ってなかったら
                                    else
                                    {
                                        stateNumber = 0;

                                        //↑case0に戻る
                                    }
                                }
                                break;

                            case 2:
                                {
                                    //1秒経ったら
                                    if (span >= 1.0f)
                                    {
                                        //乱数を振る(4以上8未満)
                                        dice = Random.Range(4, 8);

                                        //spanを0で初期化する
                                        span = 0.0f;

                                        switch (dice)
                                        {
                                            case 4:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 6.5f);
                                                }
                                                break;

                                            case 5:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, -5.0f);
                                                }
                                                break;

                                            case 6:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 5.0f);
                                                }
                                                break;

                                            case 7:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 0.0f);
                                                }
                                                break;

                                            default: break;
                                        }

                                        stateNumber = 0;

                                        //↑case0に戻る
                                    }
                                    //5秒経ってなかったら
                                    else
                                    {
                                        stateNumber = 0;

                                        //↑case0に戻る
                                    }
                                }
                                break;

                            case 3:
                                {
                                    //1秒経ったら
                                    if (span >= 1.0f)
                                    {
                                        //乱数を振る(8以上12未満)
                                        dice = Random.Range(8, 12);

                                        //spanを0で初期化する
                                        span = 0.0f;

                                        switch (dice)
                                        {
                                            case 8:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 5.5f);
                                                }
                                                break;

                                            case 9:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, -4.0f);
                                                }
                                                break;

                                            case 10:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 4.0f);
                                                }
                                                break;

                                            case 11:
                                                {
                                                    //Prefabの情報をgoに入れる
                                                    GameObject go = Instantiate(prefabs[dice]);

                                                    //goする
                                                    go.transform.position = new Vector2(10.0f, 0.0f);
                                                }
                                                break;

                                            default: break;
                                        }

                                        stateNumber = 0;

                                        //↑case0に戻る
                                    }
                                    //5秒経ってなかったら
                                    else
                                    {
                                        stateNumber = 0;

                                        //↑case0に戻る
                                    }
                                }
                                break;

                            //1回だけクリアを表示する
                            case 4:
                                {
                                    //ゲームを止める
                                    SystemDaemon.isRun = false;

                                    //色を黄色にする
                                    commonText.GetComponent<Text>().color = new Color(1.0f, 1.0f, 0.0f, 1.0f);

                                    //Clearを表示する
                                    commonText.GetComponent<Text>().text = "CLEAR!";

                                    //タイトルに戻るための判定をONにする
                                    isbacked = true;
                                }
                                break;

                            default: break;
                        }
                    }
                    break;
            }
        }

        //タイトルに戻る
        if (isbacked)
        {
            //backTitleCountの更新
            backTitleCount += Time.deltaTime;

            //2秒経ったら
            if(backTitleCount >= 2.0f)
            {
                //戻る
                SystemDaemon.LoadScene("Title");
            }
        }
    }
}
