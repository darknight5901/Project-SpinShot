using UnityEngine;
using static MainMenuManager;

public class OptionsButtonManager : MonoBehaviour

{
    public static OptionsButtonManager _;
    [SerializeField] AudioManager audioManager;
    [SerializeField] MainMenuManager.OptionsButtons _ButtonType;
    [SerializeField] OptionsManager.OptionsTabs _OptionsButtonType;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
        audioManager.PlaySFX(audioManager.ButtonClick);
    }

}