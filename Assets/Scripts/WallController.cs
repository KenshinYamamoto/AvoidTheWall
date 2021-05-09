using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    //X方向に動く速度
    private float xSpeed = -7.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //左に動かす
        transform.Translate(xSpeed * Time.deltaTime, 0.0f, 0.0f);

        //x座標が-10より小さくなったら
        if(transform.position.x <= -10.0f)
        {
            //消す
            Destroy(gameObject);
        }
    }
}
