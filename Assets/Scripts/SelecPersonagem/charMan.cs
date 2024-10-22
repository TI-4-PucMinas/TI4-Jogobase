using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charMan : MonoBehaviour
{

    public characterDatabase chardb;

    public Text nameText;
    public SpriteRenderer artworkSprite;

    // Sprites a esquerda e direita do personagem
    public SpriteRenderer leftSprite;
    public SpriteRenderer rightSprite;

    // Statico. Passamos isso para saber qual sprite carregar.
    public static int selectedOption;

    // Start is called before the first frame update
    void Start()
    {
        updateCharacter(selectedOption);   
    }

    public void nextOption()
    {
        selectedOption++;

        if (selectedOption >= chardb.CharacterCount) selectedOption = 0;
        updateCharacter(selectedOption);
    }

    public void prevOption()
    {
        selectedOption--;

        if (selectedOption < 0) selectedOption = chardb.CharacterCount-1;
        updateCharacter(selectedOption);
    }

    private void updateCharacter(int selectedOption)
    {
        Character character = chardb.GetCharacter(selectedOption);
        nameText.text = character.characterName;
        artworkSprite.sprite = character.characterSprite;
        if (selectedOption == chardb.CharacterCount - 1)
        {
            rightSprite.sprite = chardb.GetCharacter(0).characterSprite;
        }
        else rightSprite.sprite = chardb.GetCharacter(selectedOption + 1).characterSprite;
        if(selectedOption == 0)
        {
            leftSprite.sprite = chardb.GetCharacter(chardb.CharacterCount - 1).characterSprite;
        }
        else leftSprite.sprite = chardb.GetCharacter(selectedOption - 1).characterSprite;
    }
}
