using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public bool enableSelectPlayer;

    public enum Player {Boy, Girl, TeenMan, TeenWoman, Man, Woman};
    public Player playerSelected;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playersController;
    public Sprite[] playersRenderer;

    void Start()
    {
        if (!enableSelectPlayer)
        {
            ChangePlayerSkin();
        } else 
        {
            switch (playerSelected)
            {
                case Player.Boy:
                    spriteRenderer.sprite = playersRenderer[0];
                    animator.runtimeAnimatorController = playersController[0];
                    break;
                case Player.Girl:
                    spriteRenderer.sprite = playersRenderer[1];
                    animator.runtimeAnimatorController = playersController[1];
                    break;
                case Player.TeenMan:
                    spriteRenderer.sprite = playersRenderer[2];
                    animator.runtimeAnimatorController = playersController[2];
                    break;
                case Player.TeenWoman:
                    spriteRenderer.sprite = playersRenderer[3];
                    animator.runtimeAnimatorController = playersController[3];
                    break;
                case Player.Man:
                    spriteRenderer.sprite = playersRenderer[4];
                    animator.runtimeAnimatorController = playersController[4];
                    break;
                case Player.Woman:
                    spriteRenderer.sprite = playersRenderer[5];
                    animator.runtimeAnimatorController = playersController[5];
                    break;
                default:
                    break;
            }
        }
    }

    public void ChangePlayerSkin()
    {
        switch (PlayerPrefs.GetString("PlayerSelected"))
        {
            case "Boy":
                spriteRenderer.sprite = playersRenderer[0];
                animator.runtimeAnimatorController = playersController[0];
                break;
            case "Girl":
                spriteRenderer.sprite = playersRenderer[1];
                animator.runtimeAnimatorController = playersController[1];
                break;
            case "TeenMan":
                spriteRenderer.sprite = playersRenderer[2];
                animator.runtimeAnimatorController = playersController[2];
                break;
            case "TeenWoman":
                spriteRenderer.sprite = playersRenderer[3];
                animator.runtimeAnimatorController = playersController[3];
                break;
            case "Man":
                spriteRenderer.sprite = playersRenderer[4];
                animator.runtimeAnimatorController = playersController[4];
                break;
            case "Woman":
                spriteRenderer.sprite = playersRenderer[5];
                animator.runtimeAnimatorController = playersController[5];
                break;
            default:
                break;
        }
    }
}
