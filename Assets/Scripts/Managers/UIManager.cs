using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject levelTextObject;
    [SerializeField] GameObject lvlUpTextObject;
    TextMeshProUGUI levelText;

    void Start()
    {
        levelText = levelTextObject.GetComponent<TextMeshProUGUI>();
        Locator.Instance.Player.LevelUp += HandleLevelUp;


    }

    void HandleLevelUp(int lvl)
    {
        levelText.text = "Level " + lvl;
        Instantiate(lvlUpTextObject,
                    levelTextObject.transform.parent);
    }
}
