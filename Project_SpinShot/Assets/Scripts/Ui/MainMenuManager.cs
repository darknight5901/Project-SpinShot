using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    
    public enum MainMenuButtons { play, options, credits, quit, None };
    public enum SocialButtons { Website, Youtube, Discord, None};
    public enum OptionsButtons { back, None };
    public enum CreditsButtons { back, None};
    
    public static MainMenuManager _;
    [SerializeField] private string _sceneToLoadAfterClickingPlay;
    [SerializeField] private bool _debugMode;
    [SerializeField] GameObject _MainMenuContainer;
    [SerializeField] GameObject _CreditsMenuContainer;
    [SerializeField] GameObject _OptionsMenuContainer;
    public void Awake()
    {
        if (_ == null)
        {
            _ = this;
        }
        else
        {
            Debug.LogError("There are more than 1 MainMenuManger's in the scene");
        }
    }
    public void Start()
    {
        OpenMenu(_MainMenuContainer);
    }

    public void MainMenuButtonClicked(MainMenuButtons buttonClicked)
    {
        DebugMessage("Button Clicked:" + buttonClicked.ToString());
        switch (buttonClicked)
        {

            case MainMenuButtons.play:
                PlayClicked();
                break;
            case MainMenuButtons.options:
                OptionsClicked();
                break;
            case MainMenuButtons.credits:
                CreditsClicked();
                break;
            case MainMenuButtons.quit:
                QuitGame();
                break;
            default:
                print("button clicked and its not added to" + _.ToString() + " Method");
                break;
        }
    }
    public void SocialButtonClicked(SocialButtons buttonClicked)
    {
        DebugMessage("Button Clicked:" + buttonClicked.ToString());
        
            string websiteLink = "";
        switch(buttonClicked) {
            case SocialButtons.Youtube:
                websiteLink = "www.youtube.com"; //not created yet
                break;
            case SocialButtons.Discord:
                websiteLink = "discord server"; //not created yet

                break;
            case SocialButtons.Website:
                websiteLink = "https://docs.google.com/document/d/1OYHUvQLqFZjGfoHl4slFo0C9MsjjybU3tStiooOlkH0/edit?tab=t.0#heading=h.gtxet06x4vnp";
                break;
            default:
                print("button clicked and its not added to" + _.ToString() + " Method");
                break;

        }
        if (websiteLink != "")
        {
            Application.OpenURL(websiteLink);
            websiteLink = "";
        }
        
    }
    public void OptionsButtonClicked(OptionsButtons buttonClicked)
    {
        DebugMessage("Button Clicked:" + buttonClicked.ToString());
        switch (buttonClicked)
        {
            case OptionsButtons.back:
                ReturnToMainMenu();
                break;
            default: break;
        }
    }
    public void CreditsButtonClicked(CreditsButtons buttonClicked)
    {
        DebugMessage("Button Clicked:" + buttonClicked.ToString());
        switch (buttonClicked)
        {
            case CreditsButtons.back:
                ReturnToMainMenu(); 
                break;
            default: break;
        }
    }

    public void ReturnToMainMenu()
    {
        OpenMenu(_MainMenuContainer);
    }
    public void OptionsClicked()
    {
        OpenMenu(_OptionsMenuContainer);
    }
    public void CreditsClicked()
    {
        OpenMenu(_CreditsMenuContainer);
    }


    public void PlayClicked()
    {
        SceneManager.LoadScene(_sceneToLoadAfterClickingPlay);
    }

    public void QuitGame()
    {
        
        #if UNITY_EDITOR
                 UnityEditor.EditorApplication.ExitPlaymode();
        #else
               Application.Quit();
        #endif
    }
   private void DebugMessage (string message)
    {
        if (_debugMode)
        {
            print(message);
        }
    }

    public void OpenMenu(GameObject menuToOpen)
    {
        _MainMenuContainer.SetActive(menuToOpen == _MainMenuContainer);
        _CreditsMenuContainer.SetActive(menuToOpen == _CreditsMenuContainer);
        _OptionsMenuContainer.SetActive(menuToOpen == _OptionsMenuContainer);
    }
}
