using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenuController : MonoBehaviour
{
    public GameObject menuPanel;

    private bool isMenuVisible;

    private void Start()
    {
        HideMenu();
    }

    public void ToggleMenu()
    {
        isMenuVisible = !isMenuVisible;
        menuPanel.SetActive(isMenuVisible);
    }

    public void HideMenu()
    {
        isMenuVisible = false;
        menuPanel.SetActive(false);
    }
}
