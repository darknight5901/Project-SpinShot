using Unity.VisualScripting;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public enum LobbyButtons { Main, Settings, Skills, None, Appearance, Stats }
    public static LobbyManager _;
    [SerializeField] GameObject[] MenuTab;




    public void ButtonClicked(LobbyButtons buttonClicked)
    {
        switch (buttonClicked)
        {
            case LobbyButtons.Skills:

                OpenMenu(MenuTab[(int)LobbyButtons.Skills], (int)LobbyButtons.Skills);
                break;
            case LobbyButtons.Settings:
                OpenMenu(MenuTab[(int)LobbyButtons.Settings], (int)LobbyButtons.Settings);
                print(buttonClicked);
                break;
            case LobbyButtons.Main:
                OpenMenu(MenuTab[(int)LobbyButtons.Main], (int)LobbyButtons.Main);
                print(buttonClicked);
                break;
            case LobbyButtons.Appearance:
                OpenMenu(MenuTab[(int)LobbyButtons.Appearance], (int)LobbyButtons.Appearance);
                print(buttonClicked);
                break;
            case LobbyButtons.Stats:
                OpenMenu(MenuTab[(int)LobbyButtons.Stats], (int)LobbyButtons.Stats);
                print(buttonClicked);
                break;

            default:
                print("There is no button method assigned to " + buttonClicked + ". Please assing one in LobbyManager");
                break;
        }
    }
    public void OpenMenu(GameObject menuToOpen, int i)
    {
        MenuTab[i].SetActive(menuToOpen == MenuTab[i]);
      
        print(menuToOpen);
    }
}
