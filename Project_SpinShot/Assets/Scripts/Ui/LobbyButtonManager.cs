using UnityEngine;
using static MainMenuManager;

public class LobbyButtonManager : MonoBehaviour

{
    public static LobbyButtonManager _;
    [SerializeField] private AudioClip ButtonSound;
    [SerializeField] LobbyManager.LobbyButtons _LobbyButtonType;
    private void Awake()
    {
        
    }
    public void ButtonClicked()
    {
        LobbyManager._.ButtonClicked(_LobbyButtonType);
          
        AudioManager._.PlaySFXClip(ButtonSound, transform, 1f);
    }

}