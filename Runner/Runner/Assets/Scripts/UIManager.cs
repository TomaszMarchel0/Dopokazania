using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text pointsValueText;
    public Image shieldIcon;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.uiManager = this;
        shieldIcon.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        pointsValueText.text = GameManager.playerController.playerPoints.ToString();
    }

    public void ShowShieldIcon()
    {
        shieldIcon.enabled=true;
    }

    public void HideShieldIcon()
    {
        shieldIcon.enabled = false;
    }
}
