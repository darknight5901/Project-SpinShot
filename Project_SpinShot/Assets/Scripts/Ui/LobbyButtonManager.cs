using UnityEngine;
using static LobbyButtonManager;
using static AudioManager;

public class LobbyButtonManager : MonoBehaviour

{
    public static LobbyButtonManager _;
    [SerializeField] private AudioClip ButtonSound;
    [SerializeField] LobbyManager.LobbyTabs _LobbyTabType;
    [SerializeField] LobbyManager.LobbyButton _LobbyButtonType;
   
    public void TabClicked()
    {
        print(_LobbyButtonType + "(lobby button Manager)");
        LobbyManager._.TabClicked(_LobbyTabType);
          
        AudioManager._.PlaySFXClip(ButtonSound, transform, 1f);
    }
    public void ButtonClicked()
    {
        LobbyManager._.ButtonClicked(_LobbyButtonType);
    }

}