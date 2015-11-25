/*!
 * Tween実装クラス.
 * 
 * @file	TweenExtensions.cs
 * @author	Lotos
 * @date	2015-11-26 0:24
 */

using UnityEngine;
using System.Collections;

public class TweenExtensions : MonoBehaviour {

    /// <summary>
    /// Tweenスタイルタイプ.
    /// </summary>
    public enum TweenStyleType {
        None = 0,
        Once,  // 一回だけ.
        Loop,  // 繰り返し.
        PingPong // 跳ね返り.
    }

    private TweenStyleType styleType = TweenStyleType.None;


    /// <summary>
    /// TweenAnimationCurveタイプ.
    /// </summary>
    public enum TweenMethodType {
        None = 0,
        EaseIn,    // 始めに遅くなる.
        EaseOut,   // 最後に遅くなる.
        EaseInOut  // 始めと最後に遅くなる.
    }

    private TweenMethodType methodType = TweenMethodType.None;


    /// <summary>
    /// TweenPosition.
    /// </summary>
    /// <param name="obj">Tweenを追加するオブジェクト.</param>
    /// <param name="duration">遅延速度.</param>
    /// <param name="styleType">アニメーションスタイルタイプ.</param>
    /// <param name="methodType">アニメーションカーブタイプ.</param>
    /// <param name="callback">アニメーション終了後に実行する.</param>
    public static void Position(GameObject obj, float duration, Vector3 pos, int styleType, int methodType, EventDelegate callback) {
        
        // Tweenアニメーションセット.
        UITweener tween = TweenPosition.Begin(obj, duration, pos);

        // アニメーションスタイル分け.
        switch ((TweenStyleType)(styleType)) {
            case TweenStyleType.Once:
                tween.style = UITweener.Style.Once;
                break;
            case TweenStyleType.Loop:
                tween.style = UITweener.Style.Loop;
                break;
            case TweenStyleType.PingPong:
                tween.style = UITweener.Style.PingPong;
                break;
        }

        // アニメーションタイプ分け.
        switch ((TweenMethodType)(methodType)) {
            case TweenMethodType.EaseIn:
                tween.method = UITweener.Method.EaseIn;
                break;
            case TweenMethodType.EaseOut:
                tween.method = UITweener.Method.EaseOut;
                break;
            case TweenMethodType.EaseInOut:
                tween.method = UITweener.Method.EaseOut;
                break;
        }

        // コールバックの指定.
        if(callback != null){
            EventDelegate.Set(tween.onFinished, callback);
        }
    }
	
}
