using UnityEngine;
using static MainMenuManager;

public class OptionsButtonManager : MonoBehaviour

{
    public static OptionsButtonManager _;
    [SerializeField] private AudioClip ButtonSound;
    [SerializeField] MainMenuManager.OptionsButtons _ButtonType;
    [SerializeField] OptionsManager.OptionsTabs _OptionsButtonType;
    private void Awake()
    {
        
    }
    public void ButtonClicked()
    {


        if (_ButtonType == MainMenuManager.OptionsButtons.None)
        {
            OptionsManager._.TabClicked(_OptionsButtonType);
            
        }
        if (_OptionsButtonType == OptionsManager.OptionsTabs.None)
        {
            MainMenuManager._.OptionsButtonClicked(_ButtonType);
            
        }
        AudioManager._.PlaySFXClip(ButtonSound, transform, 1f);
    }

}