using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    //*******************ボタンの宣言**********************

    //難易度選択への遷移ボタン
    private GameObject difficultySelectionButton;

    //EasyButton
    private GameObject easyButton;

    //NormalButton
    private GameObject normalButton;

    //HardButton
    private GameObject hardButton;

    //MixButton
    private GameObject mixButton;

    //AscendingButton
    private GameObject ascendingButton;

    //BackButton
    private GameObject backButton;

    //******************************************************

    // Start is called before the first frame update
    void Start()
    {
		// シーン リセット
		SystemDaemon.SceneReset();

        //*****************************ボタンの探索********************************

        difficultySelectionButton = GameObject.Find("DifficultySelectionButton");
        easyButton = GameObject.Find("EasyButton");
        normalButton = GameObject.Find("NormalButton");
        hardButton = GameObject.Find("HardButton");
        mixButton = GameObject.Find("MixButton");
        ascendingButton = GameObject.Find("AscendingButton");
        backButton = GameObject.Find("BackButton");

        //*************************************************************************

        //***************************ボタンの非表示化******************************
        easyButton.SetActive(false);
        normalButton.SetActive(false);
        hardButton.SetActive(false);
        mixButton.SetActive(false);
        ascendingButton.SetActive(false);
        backButton.SetActive(false);
        //*************************************************************************
    }

    // Update is called once per frame
    void Update()
    {

    }

    //難易度選択ボタンが押されたら
    public void OnClickDifficultySelectionButton()
    {
        //難易度選択遷移ボタンを非表示にする
        difficultySelectionButton.SetActive(false);

        //その他のボタンを表示する
        easyButton.SetActive(true);
        normalButton.SetActive(true);
        hardButton.SetActive(true);
        mixButton.SetActive(true);
        ascendingButton.SetActive(true);
        backButton.SetActive(true);
    }

    public void OnClickEasyButton()
    {
        //SystemDaemon内の難易度番号を0にする
        SystemDaemon.difficultyNumber = 0;

        //シーンを移す
        SystemDaemon.LoadScene("GameScene");
    }

    public void OnClickNormalButton()
    {
        //SystemDaemon内の難易度番号を1にする
        SystemDaemon.difficultyNumber = 1;

        //シーンを移す
        SystemDaemon.LoadScene("GameScene");
    }

    public void OnClickHardButton()
    {
        //SystemDaemon内の難易度番号を2にする
        SystemDaemon.difficultyNumber = 2;

        //シーンを移す
        SystemDaemon.LoadScene("GameScene");
    }

    public void OnClickMixButton()
    {
        //SystemDaemon内の難易度番号を3にする
        SystemDaemon.difficultyNumber = 3;

        //シーンを移す
        SystemDaemon.LoadScene("GameScene");
    }

    public void OnClickAscendingButton()
    {
        //SystemDaemon内の難易度番号を4にする
        SystemDaemon.difficultyNumber = 4;

        //シーンを移す
        SystemDaemon.LoadScene("GameScene");
    }

    public void OnClickBackButton()
    {
        //難易度選択遷移ボタンを表示する
        difficultySelectionButton.SetActive(true);

        //その他のボタンを非表示にする
        easyButton.SetActive(false);
        normalButton.SetActive(false);
        hardButton.SetActive(false);
        mixButton.SetActive(false);
        ascendingButton.SetActive(false);
        backButton.SetActive(false);
    }
}
