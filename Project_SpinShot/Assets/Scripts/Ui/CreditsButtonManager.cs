using UnityEngine;

public class CreditsButtonManager : MonoBehaviour
{
    [SerializeField] MainMenuManager.CreditsButtons _ButtonType;
    public void ButtonClicked()
    {
        MainMenuManager._.CreditsButtonClicked(_ButtonType);

    }
    
}
