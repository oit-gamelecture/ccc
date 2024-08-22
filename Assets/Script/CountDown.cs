using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    private float step_time; // 経過時間カウント用
    public Text CountText;
    int count;

    // Use this for initialization
    void Start()
    {
        step_time = 4.0f;       // 経過時間初期化
    }

    // Update is called once per frame
    void Update()
    {
        // 経過時間をカウント
        step_time -= Time.deltaTime;

        count = (int)step_time;

        if (count > 0)
        {

            CountText.text = count.ToString();

        }
        else
        {
            CountText.text = ("start");
        }
        
        // 3秒後に画面遷移（scene2へ移動）
        if (step_time <= 0.0f)
        {
            SceneManager.LoadScene("main");
        }
    }
}
