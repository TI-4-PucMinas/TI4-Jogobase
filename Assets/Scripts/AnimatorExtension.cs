
using System;
using UnityEngine;

public static class AnimatorExtension
{
    static int _totalFrames
    {
        get { return _totalFrames; }
        set { _totalFrames = value; }
    }



    public static bool IsPlayingOnLayer(this Animator animator, int fullPathHash, int layer)
    {
        return animator.GetCurrentAnimatorStateInfo(layer).fullPathHash == fullPathHash;
    }

    public static double NormalizedTime(this Animator animator, Int32 layer)
    {
        double time = animator.GetCurrentAnimatorStateInfo(layer).normalizedTime;
        return time > 1 ? 1 : time;
    }


}