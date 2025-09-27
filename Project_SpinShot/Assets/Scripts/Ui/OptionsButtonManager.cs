using UnityEngine;

public class OptionsButtonManager : MonoBehaviour
{
    [SerializeField] MainMenuManager.OptionsButtons _ButtonType;
    public void ButtonClicked()
    {
        MainMenuManager._.OptionsButtonClicked(_ButtonType);

    }
}
