using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject levelTxtObj;
    private TextMeshProUGUI levelTxt;

    void Start()
    {
        levelTxt = levelTxtObj.GetComponent<TextMeshProUGUI>();
        Locator.Instance.Player.LevelUp += HandleLevelUp;
    }

    void HandleLevelUp(int lvl)
    {
        levelTxt.text = "Level " + lvl;
    }
}
