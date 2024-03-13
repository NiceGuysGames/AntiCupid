using UnityEngine;

public static class AnimationController
{
    public static string _currentAnimation { get; private set; }
    
    public static void ChangeAnimation(string animation, Animator animator)
    {
        if (_currentAnimation == animation)
        {
            return;
        }
		
        animator.Play(animation);
        _currentAnimation = animation;
    }
}
