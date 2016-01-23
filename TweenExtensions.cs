/************************************************
TweenExtensions.cs

Copyright (c) 2016 LotosLabo

This software is released under the MIT License.
http://opensource.org/licenses/mit-license.php
************************************************/

using UnityEngine;
using System.Collections;

/* Tween実装クラス. */
public class TweenExtensions : MonoBehaviour
{

    /// <summary>
    /// Tweenアニメーションタイプ.
    /// </summary>
    public enum TweenType
    {
        None = 0,
        Position, // ポジション.
        Rotation, // 角度.
        Scale,    // 大きさ.
        Alpha     // 透明度.
    }

    private TweenType m_tweenType = TweenType.None;

    /// <summary>
    /// Tweenスタイルタイプ.
    /// </summary>
    public enum TweenStyleType
    {
        None = 0,
        Once,  // 一回だけ.
        Loop,  // 繰り返し.
        PingPong // 跳ね返り.
    }

    private TweenStyleType m_styleType = TweenStyleType.None;


    /// <summary>
    /// TweenAnimationCurveタイプ.
    /// </summary>
    public enum TweenMethodType
    {
        None = 0,
        EaseIn,    // 始めに遅くなる.
        EaseOut,   // 最後に遅くなる.
        EaseInOut  // 始めと最後に遅くなる.
    }

    private TweenMethodType m_methodType = TweenMethodType.None;


    /// <summary>
    /// Tweenのアニメーション.
    /// </summary>
    /// <param name="tweenType">アニメーションタイプ.</param>
    /// <param name="obj">Tweenを追加するオブジェクト.</param>
    /// <param name="duration">遅延速度.</param>
    /// <param name="startDelay">最初の遅延.</param>
    /// <param name="pos">ポジション.</param>
    /// <param name="styleType">アニメーションスタイルタイプ.</param>
    /// <param name="methodType">アニメーションカーブタイプ.</param>
    /// <param name="callback">アニメーション終了後に実行する.</param>
    public static void AnimationStart(int tweenType, GameObject obj, float duration, float startDelay, Vector3 pos, int styleType, int methodType, EventDelegate callback)
    {

        UITweener tween = null;

        // Tweenアニメーションセット.
        switch ((TweenType)(tweenType))
        {
            case TweenType.Position:
                tween = TweenPosition.Begin(obj, duration, pos);
                break;
            case TweenType.Rotation:
                tween = TweenRotation.Begin(obj, duration, Quaternion.Euler(pos));
                break;
            case TweenType.Scale:
                tween = TweenScale.Begin(obj, duration, pos);
                break;
            case TweenType.Alpha:
                break;
        }

        if (tween == null) return;

        //　最初の遅延.
        tween.delay = startDelay;

        // アニメーションスタイル分け.
        switch ((TweenStyleType)(styleType))
        {
            case TweenStyleType.Once:
                tween.style = UITweener.Style.Once;
                break;
            case TweenStyleType.Loop:
                tween.style = UITweener.Style.Loop;
                break;
            case TweenStyleType.PingPong:
                tween.style = UITweener.Style.PingPong;
                break;
            default:
                break;
        }

        // アニメーションタイプ分け.
        switch ((TweenMethodType)(methodType))
        {
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

        if (callback == null)
        {
            return;
        }

        // コールバックの指定.
        EventDelegate.Set(tween.onFinished, callback);
    }
}
