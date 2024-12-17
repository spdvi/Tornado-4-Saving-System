using TMPro;
using UnityEngine;
using Tornado4.Player;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FPSLevelManager : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public GameObject youWinCanvas;
    public GameObject youLoseCanvas;
    public PlayerFPSMove playerFPSMove;
    public PlayerFPSLook playerFPSLook;
    public Image healthBarImage;
    public Transform player;
    
    private int coins = 0;
    public float countDownTime  = 3.0f;
    
    public GameObject savingSystem;
    
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
            
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            
        }
        
    }

    public void CoinCollected()
    {
        coins++;
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