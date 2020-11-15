using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorSummoning : MonoBehaviour
{
    public Animator IDAnimator;
    public Animator managerAnimator;
    public Animator summonButtonAnimator;
    public Animator byeButtonAnimator;

    public void AnimateIn()
    {
        IDAnimator.SetBool("IsOpen", true);
        managerAnimator.SetBool("IsOpen", true);
        summonButtonAnimator.SetBool("CanOpen", false);
        byeButtonAnimator.SetBool("IsOpen", true);
    }

    public void AnimateOut()
    {
        IDAnimator.SetBool("IsOpen", false);
        managerAnimator.SetBool("IsOpen", false);
        summonButtonAnimator.SetBool("CanOpen", true);
        byeButtonAnimator.SetBool("IsOpen", false);
    }
}
