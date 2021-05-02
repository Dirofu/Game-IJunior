using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTouchHandler : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
}
