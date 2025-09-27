using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour
{
    [SerializeField] MainMenuManager.MainMenuButtons _ButtonType;
    public void ButtonClicked()
    {
        MainMenuManager._.MainMenuButtonClicked(_ButtonType);

    }
}
