using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class point : MonoBehaviour
{
    void Start()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突相手のGameObjectを取得
        GameObject otherObj = collision.gameObject;

        // 衝突相手からpointgetplayerコンポーネントを取得してみる
        pointgetplayer playerScript = otherObj.GetComponent<pointgetplayer>();

        if (playerScript != null)
        {
            // pointgetplayer内のメソッドを呼び出す
            playerScript.AddPointAndLog();

            // pointオブジェクト（自身）を破壊する
            Destroy(gameObject);
        }
        // else のエラー処理は省略
    }

}
