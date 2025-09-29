using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour
{
    [SerializeField] MainMenuManager.MainMenuButtons _ButtonType;
    [SerializeField] AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void ButtonClicked()
    {
        MainMenuManager._.MainMenuButtonClicked(_ButtonType);
        audioManager.PlaySFX(audioManager.ButtonClick);
    }
}
