using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject _languagesPanel;
    Button[] allButton;
    private void Awake()
    {
        allButton = GetComponentsInChildren<Button>();
    }
    public void ClickLanguagesButton()
    {
        IsActiveButton(false);
        IsActivePanel(true);
    }

    private void IsActiveButton(bool active)
    {
        
        foreach (Button button in allButton)
        {
            if (button != null)
            {
                button.gameObject.SetActive(active);
            }
        }

    }
    private void IsActivePanel(bool active)
    {
        if (_languagesPanel != null)
            _languagesPanel.SetActive(active);
    }
    public void ClickBackButton()
    {
        IsActivePanel(false);
        IsActiveButton(true);
    }

    public void ClickStartButton()
    {
        SceneManager.LoadScene(0);
    }
    public void ClickQuitButton()
    {
        Application.Quit();
    }
}
