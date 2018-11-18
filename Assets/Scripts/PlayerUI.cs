using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Sprite[] spellSprites;
    public Image[] spellImages;
    public Image healthBar;

    private void Start()
    {
        ResetSpriteImages();
        this.transform.rotation = Camera.main.transform.rotation;
    }

    public void UpdateHealthbar(float percentage)
    {
        healthBar.fillAmount = percentage;
    }

    public void ResetSpriteImages()
    {
        for (int i = 0; i < spellImages.Length; i++)
        {
            spellImages[i].sprite = null;
            spellImages[i].color = new Color(0, 0, 0, 0);
        }
    }

    public void SetSpriteImage(SpellSchools spell, int index)
    {
        switch (spell)
        {
            case SpellSchools.Ritual:
                spellImages[index].sprite = spellSprites[0];
                break;
            case SpellSchools.Rot:
                spellImages[index].sprite = spellSprites[1];
                break;
            case SpellSchools.Dark:
                spellImages[index].sprite = spellSprites[2];
                break;
            case SpellSchools.Fire:
                spellImages[index].sprite = spellSprites[3];
                break;
        }
        spellImages[index].color = new Color(1, 1, 1, 1);
    }
}
