using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemys : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    public float detectionRange = 5f;  // プレイヤーを検出する範囲
    public Vector3 initialDirection = Vector3.forward;  // Z軸方向（前方向）に移動
    public Transform player;  // プレイヤーのTransform

    private Vector3 currentDirection;
    void Start()
    {
        // 初期移動方向を設定
        currentDirection = initialDirection;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーとの距離を計算
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // プレイヤーが範囲内にいる場合、X軸方向に移動
            if (player.position.x > transform.position.x)
            {
                // プレイヤーが右にいる場合、右（+X方向）に移動
                currentDirection = Vector3.right;
            }
            else
            {
                // プレイヤーが左にいる場合、左（-X方向）に移動
                currentDirection = Vector3.left;
            }
        }
        else
        {
            // プレイヤーが範囲外にいる場合、Z軸方向に戻る
            currentDirection = initialDirection;
        }

        // 敵を移動させる
        transform.Translate(currentDirection * speed * Time.deltaTime, Space.World);
    }
}
