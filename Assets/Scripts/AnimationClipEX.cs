using UnityEngine;

[System.Serializable]
public class AnimationClipEX
{
    public Animator animator;
    public AnimationClip clip;
    public string animatorStateName;
    public int layerNumber;

    private int _totalFrames = 0;
    private int _animationFullNameHash;

    public void Initialize()
    {
        _totalFrames = Mathf.RoundToInt(clip.length * clip.frameRate);

        if (animator.isActiveAndEnabled)
        {
            string name = animator.GetLayerName(layerNumber) + "." + animatorStateName;

            _animationFullNameHash = Animator.StringToHash(name);

        }

    }

    public int TotalFrames()
    {
        return _totalFrames;
    }


    public bool IsActive()
    {
        return animator.IsPlayingOnLayer(_animationFullNameHash, 0);

    }

    double PercentageOnFrame(int frameNumber)
    {
        return (double)frameNumber / (double)_totalFrames;
    }

    public bool BiggerOrEqualThanFrame(int frameNumber)
    {
        double percentage = animator.NormalizedTime(layerNumber);
        return (percentage >= PercentageOnFrame(frameNumber));
    }

    public bool ItsOnLastFrame()
    {
        double percentage = animator.NormalizedTime(layerNumber);
        return (percentage > PercentageOnFrame(_totalFrames - 1));
    }
}

public interface IFrameCheckHandler
{
    void OnHitFrameStart();
    void OnHitFrameEnd();
    void OnLastFrameStart();
    void OnLastFrameEnd();
}