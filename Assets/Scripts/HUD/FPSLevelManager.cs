using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using Tornado4.Player;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FPSLevelManager : MonoBehaviour, IJsonSaveable
{
    public TextMeshProUGUI coinsText;
    public GameObject youWinCanvas;
    public GameObject youLoseCanvas;
    public PlayerFPSMove playerFPSMove;
    public PlayerFPSLook playerFPSLook;
    public Image healthBarImage;
    public Transform player;
    
    public float countDownTime  = 3.0f;
    
    public SavingSystem savingSystem;

    public JToken CaptureAsJToken()
    {
        JToken countDownTimeJToken = JToken.FromObject(countDownTime);
        return countDownTimeJToken;
    }

    public void RestoreFromJToken(JToken state)
    {
        countDownTime = state.ToObject<float>();
    }
    
    private void Start()
    {
        youWinCanvas.SetActive(false);
        youLoseCanvas.SetActive(false);
    }

    private void Update()
    {
        countDownTime -= Time.deltaTime;
        healthBarImage.fillAmount = countDownTime / 3f;
        if (countDownTime <= 0)
        {
            LoseGame();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            savingSystem.Save("game4");
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            savingSystem.Load("game4");
        }
        
    }

    public void CheckCoinsAndUpdateUI(int coins)
    {
        coinsText.text = coins.ToString();
        
        if (coins == 3)
        {
            WinGame();
        }
    }

    public void PlayerOnConsole()
    {
        SceneManager.LoadSceneAsync("New Scene Additive", LoadSceneMode.Additive);
    }

    public void PlayerOutOfConsole()
    {
        SceneManager.UnloadSceneAsync("New Scene Additive");
    }
    
    private void WinGame()
    {
       
        //Debug.Log("You Win!");
        // Mostrar Canvas You Win
        youWinCanvas.SetActive(true);
            
        // Desactivar moviment del Player
        playerFPSMove.enabled = false;
        playerFPSLook.enabled = false;
            
        // Mostrar el cursor del ratolí
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void LoseGame()
    {
        youLoseCanvas.SetActive(true);
        
        // Desactivar moviment del Player
        playerFPSMove.enabled = false;
        playerFPSLook.enabled = false;
            
        // Mostrar el cursor del ratolí
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
