using UnityEngine.SceneManagement;
using UnityEngine;

public class TItleUIController : MonoBehaviour
{
    public void LoadStudentScene()
    {
        SceneManager.LoadSceneAsync("Art_Mockup");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
