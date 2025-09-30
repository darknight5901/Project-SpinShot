using UnityEngine;
using UnityEngine.Audio;

public class LobbyManager : MonoBehaviour
{
    public enum LobbyTabs { None, Main, Settings, Skills, Appearance, Stats }
    public enum LobbyButton { None, Play, OnlineToggle, Search, Host }
    public static LobbyManager _;
    [SerializeField] GameObject _LobbyTab;
    [SerializeField] GameObject _SkillsTab;
    [SerializeField] GameObject _AppearanceTab;
    [SerializeField] GameObject _StatsTab;
    [SerializeField] GameObject _SettingsTab;

    private void Awake()
    {
        if (_ == null)
        {
            _ = this;
        }
        else
        {
            Debug.LogError("There are more than 1 OptionsMenuManager 's in the scene");
        }
    }
    private void Start()
    {
        OpenMenu(_LobbyTab);
    }

    public void TabClicked(LobbyTabs buttonClicked)
    {
        print("was clicked");
        switch (buttonClicked)
        {
            case LobbyTabs.Skills:

                OpenMenu(_SkillsTab);
                break;
            case LobbyTabs.Settings:
                OpenMenu(_SettingsTab);
                print(buttonClicked);
                break;
            case LobbyTabs.Main:
                OpenMenu(_LobbyTab);
                print(buttonClicked);
                break;
            case LobbyTabs.Appearance:
                OpenMenu(_AppearanceTab);
                print(buttonClicked);
                break;
            case LobbyTabs.Stats:
                OpenMenu(_StatsTab);
                print(buttonClicked);
                break;

            default:
                print("There is no button method assigned to " + buttonClicked + ". Please assign one in LobbyManager");
                break;
        }
    }
    public void OpenMenu(GameObject menuToOpen)
    {
        _AppearanceTab.SetActive(menuToOpen == _AppearanceTab);
        _StatsTab.SetActive(menuToOpen == _StatsTab);
        _LobbyTab.SetActive(menuToOpen == _LobbyTab);
        _SettingsTab.SetActive(menuToOpen == _SettingsTab);
        _SkillsTab.SetActive(menuToOpen == _SkillsTab);

        print(menuToOpen);
    }
    public void ButtonClicked(LobbyButton buttonClicked)
    {
        switch (buttonClicked)
        {
            case LobbyButton.Play:

                break;
            case LobbyButton.OnlineToggle:

                break;
            case LobbyButton.Search:

                break;
            case LobbyButton.Host:

                break;
            default :
                break;
        }

        
    }
}
