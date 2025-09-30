using UnityEngine;

public class SocialButtonManager : MonoBehaviour
{
    [SerializeField] private AudioClip ButtonSound;
    [SerializeField] MainMenuManager.SocialButtons _ButtonType;
    public void ButtonClicked()
    {
        MainMenuManager._.SocialButtonClicked(_ButtonType);
        AudioManager._.PlaySFXClip(ButtonSound, transform, 1f);
    }
}
