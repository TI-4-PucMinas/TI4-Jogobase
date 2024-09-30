[System.Serializable]
public class FrameChecker
{
    public int hitFrameStart;
    public int hitFrameEnd;
    public int totalFrames;

    private IFrameCheckHandler _frameCheckHandler;
    private AnimationClipEX _extendedClip;
    private bool _checkedHitFrameStart;
    private bool _checkedHitFrameEnd;
    private bool _lastFrame;

    public void Initialize(IFrameCheckHandler frameCheckHandler, AnimationClipEX extendedClip)
    {
        _frameCheckHandler = frameCheckHandler;

        _extendedClip = extendedClip;

        totalFrames = extendedClip.TotalFrames();

        InitCheck();

    }


    public void InitCheck()
    {
        _checkedHitFrameStart = false;

        _checkedHitFrameEnd = false;

        _lastFrame = false;

    }

    public void CheckFrames()
    {
        if (_lastFrame)
        {

            _lastFrame = false;

            _frameCheckHandler.OnLastFrameEnd();

        }


        if (!_extendedClip.IsActive()) { return; }


        if (!_checkedHitFrameStart && _extendedClip.BiggerOrEqualThanFrame(hitFrameStart))
        {

            _frameCheckHandler.OnHitFrameStart();

            _checkedHitFrameStart = true;

        }
        else if (!_checkedHitFrameEnd && _extendedClip.BiggerOrEqualThanFrame(hitFrameEnd))
        {

            _frameCheckHandler.OnHitFrameEnd();

            _checkedHitFrameEnd = true;

        }

        if (!_lastFrame && _extendedClip.ItsOnLastFrame())
        {

            _frameCheckHandler.OnLastFrameStart();

            _lastFrame = true; // This is here so we don't skip the last frame

        }

    }



}