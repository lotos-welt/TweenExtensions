/*!
 * TweenExtensions用呼び出しサンプル.
 * 
 * @file	Sample.cs
 * @author	Lotos
 * @date	2015-11-26 02:19
 */

using UnityEngine;
using System.Collections;

public class Sample : MonoBehaviour {

    /// <summary>
    /// サンプルゲームオブジェクト.
    /// </summary>
    public GameObject sampleObject;

    /// <summary>
    /// Tween終了イベント.
    /// </summary>
    private EventDelegate tweenOnFinishedEvent = null;

    void Start() {
        // イベントの登録.
        tweenOnFinishedEvent = new EventDelegate(this, "TweenOnFinished");

        // 移動する距離.
        Vector3 pos = sampleObject.transform.localPosition;
        pos.x += -850.0f;

        // TweenPositionで移動する.
        TweenExtensions.Position(sampleObject, 1.0f, pos, 1, 2, tweenOnFinishedEvent);
    }

    /// <summary>
    /// Tweenアニメーション終了後に呼び出される.
    /// </summary>
    private void TweenOnFinished() {
        Debug.Log("Finished!");
    }
}
