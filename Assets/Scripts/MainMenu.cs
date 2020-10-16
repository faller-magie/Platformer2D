using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayMenu ()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CreditsMenu()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitMenu ()
    {
        Debug.Log("Fermeture du jeu");
        Application.Quit(); 
    }
}
