using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEventHandlers : MonoBehaviour
{
    public void OnExitButtonClicked()
    {
// If we are running in the editor
// #if UNITY_EDITOR
//         // Stop playing the scene
//         UnityEditor.EditorApplication.isPlaying = false;
// #else
            // Quit the application
            Application.Quit();
// #endif
    }

    public void OnNextLevelButtonClicked()
    {
        SceneManager.LoadSceneAsync("Level 1");
        //SceneManager.LoadSceneAsync(1);
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
