using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class OptionsManager : MonoBehaviour
{
    public static OptionsManager _;

    [Header("------- Setting References -------")]
    public TMP_Dropdown resolutionDropdown;
    public AudioMixer audioMixer;
    public Slider[] AudioSliders;
    private Resolution[] resolutions;
    public enum OptionsTabs { Graphics, Audio, Controls,MainMenu, None }
    [SerializeField] private string _MainMenuScene = null;
    [SerializeField] GameObject _GraphicsMenu;
    [SerializeField] GameObject _AudioMenu;
    [SerializeField] GameObject _ControlsMenu;
    [SerializeField] ScrollRect _OptionsScrollRect;


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
        GetComponent<ScrollRect>();
    }
    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();
        int currentResolutionIndex = 0;
        List<string> options = new();
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + "x" + resolutions[i].height + resolutions[i].refreshRateRatio+"hz";
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
            
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        OpenMenu(_GraphicsMenu);
        for (int i = 0; i < AudioSliders.Length; i++)
            switch (i)
            {
                case 0:
                    if (PlayerPrefs.HasKey("masterVolume"))
                    {
                        LoadVolume(i);
                    }
                    SetAllVolume(i);
                    break;
                case 1:
                    if (PlayerPrefs.HasKey("sfxVolume"))
                    {
                        LoadVolume(i);
                    }
                    SetAllVolume(i);
                    break;
                case 2:
                    if (PlayerPrefs.HasKey("musicVolume"))
                    {
                        LoadVolume(i);
                    }
                    SetAllVolume(i);
                        break;
                    
            }
    }
    public void SetMasterVolume()
    {   float volume = AudioSliders[0].value;
        audioMixer.SetFloat("master", volume);
        PlayerPrefs.SetFloat("masterVolume", volume);
                
        print(volume);
    }
    public void SetSFXVolume()
    {
       float  volume = AudioSliders[1].value;
        audioMixer.SetFloat("sfx", volume);
        PlayerPrefs.SetFloat("sfxVolume", volume);
        print(volume);
    }
    public void SetMusicVolume()
    {
        float volume = AudioSliders[2].value;
        audioMixer.SetFloat("music", volume);
        PlayerPrefs.SetFloat("musicVolume", volume);
        print(volume);
    }
    private void LoadVolume(int sliderIndex)
    {
     
            switch (sliderIndex)
            {
                case 0:AudioSliders[sliderIndex].value = PlayerPrefs.GetFloat("masterVolume");
                    SetMasterVolume();
                    break;
                case 1:
                    AudioSliders[sliderIndex].value = PlayerPrefs.GetFloat("sfxVolume");
                    SetSFXVolume();
                    break;
                case 2:
                    AudioSliders[sliderIndex].value = PlayerPrefs.GetFloat("musicVolume");
                    SetMusicVolume();
                    break;
            }
            
    }
    private void SetAllVolume(int sliderIndex)
    {
        switch (sliderIndex)
        {
            case 0:
                SetMasterVolume();
                break;
            case 1:
                SetSFXVolume();
                break;
            case 2:
                SetMusicVolume();
                break;
        }
    }      
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel (qualityIndex);
        print("the quality level is " + QualitySettings.GetQualityLevel());
    }
    public void SetResolution(int resolutionIndex) 
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetFullscreen(bool isFullscreen)
    {
         Screen.fullScreen = isFullscreen;
        print("Fullscreen is" + Screen.fullScreen);
    }
    public void OpenMenu(GameObject menuToOpen)
    {
        _GraphicsMenu.SetActive(menuToOpen == _GraphicsMenu);
        _AudioMenu.SetActive(menuToOpen == _AudioMenu);
        _ControlsMenu.SetActive(menuToOpen == _ControlsMenu);

        var menuContent = menuToOpen.GetComponent<RectTransform>();
        _OptionsScrollRect.content = menuContent;
        print(menuToOpen);
    }
    public void TabClicked(OptionsTabs tabClicked)
    {
        switch (tabClicked)
        {
            case OptionsTabs.Graphics:
                OpenMenu(_GraphicsMenu);
            break;
            case OptionsTabs.Audio:
                OpenMenu(_AudioMenu);
                break;
            case OptionsTabs.Controls:
                OpenMenu(_ControlsMenu);
                break;
            case OptionsTabs.MainMenu:
                MainMenuClicked();
                break;
            default:
                OpenMenu(_GraphicsMenu);
                print(tabClicked + " does not have an TAB assigned event yet");
                break;
        }
    }
    
    public void SetVSYNC(bool Vsync)
    {
        if (Vsync)
        { 
            QualitySettings.vSyncCount = 1; 
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        print( "VSYNC is set to " + Vsync);
    }
 
    private void MainMenuClicked()
    {
        SceneManager.LoadScene(_MainMenuScene);
    }
    
}
