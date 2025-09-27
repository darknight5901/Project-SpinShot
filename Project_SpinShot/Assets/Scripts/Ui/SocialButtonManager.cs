using UnityEngine;

public class SocialButtonManager : MonoBehaviour
{
    [SerializeField] MainMenuManager.SocialButtons _ButtonType;
    public void ButtonClicked()
    {
        MainMenuManager._.SocialButtonClicked(_ButtonType);

    }
}
