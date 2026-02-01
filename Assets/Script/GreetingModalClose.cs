using UnityEngine;

/// <summary>
/// Colocado no root da modal GreetingCTA. Ao clicar em "Let's go!" fecha a modal
/// e dispara o resto da experiência (blocos, etc.) via InitialSetup.
/// </summary>
public class GreetingModalClose : MonoBehaviour
{
    public void CloseAndStartExperience()
    {
        gameObject.SetActive(false);
        var setup = FindObjectOfType<InitialSetup>();
        if (setup != null)
            setup.OnStartExperienceAfterModalClosed();
    }
}
