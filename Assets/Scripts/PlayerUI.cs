using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image[] spellImages;
    public Image healthBar;

    private void Start()
    {
        this.transform.rotation = Camera.main.transform.rotation;
    }
}
