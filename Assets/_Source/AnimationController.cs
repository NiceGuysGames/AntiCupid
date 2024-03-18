using UnityEngine;

public static class AnimationController
{
    public static string CurrentAnimation { get; private set; }
    
    public static void ChangeAnimation(string animation, Animator animator)
    {
        if (CurrentAnimation == animation)
        {
            return;
        }
		
        animator.Play(animation);
        CurrentAnimation = animation;
    }
}
