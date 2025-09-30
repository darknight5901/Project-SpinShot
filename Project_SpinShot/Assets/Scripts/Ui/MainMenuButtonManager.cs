using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour
{
    [SerializeField] private AudioClip ButtonSound;
    [SerializeField] MainMenuManager.MainMenuButtons _ButtonType;
 
    private void Awake()
    {
       
    }
    public void ButtonClicked()
    {
        MainMenuManager._.MainMenuButtonClicked(_ButtonType);
        AudioManager._.PlaySFXClip(ButtonSound, transform, 1f);
    }
}
