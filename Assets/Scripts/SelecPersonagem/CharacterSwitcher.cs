using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public RuntimeAnimatorController[] characterControllers;
    public Sprite[] characterSprites;

    void Start()
    {
        SwitchCharacter();
    }

    public void SwitchCharacter()
    {
        int characterIndex = charMan.selectedOption;
        if (characterIndex >= 0 && characterIndex < characterControllers.Length)
        {
            animator.runtimeAnimatorController = characterControllers[characterIndex];
            if (spriteRenderer != null && characterSprites.Length > characterIndex)
            {
                spriteRenderer.sprite = characterSprites[characterIndex];
            }
        }
        else
        {
            Debug.LogWarning("ERRO! Invalid character index");
        }
    }
}
