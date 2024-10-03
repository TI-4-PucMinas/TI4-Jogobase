
using UnityEngine;

public class PegaAnimation : StateMachineBehaviour
{

    AnimationClip clip;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        clip = animator.GetCurrentAnimatorClipInfo(layerIndex)[0].clip;
        
    }

    public AnimationClip GetClip()
    {
        return clip;
    }

}