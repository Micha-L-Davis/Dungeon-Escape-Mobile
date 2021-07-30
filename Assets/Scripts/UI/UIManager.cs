using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get {

            if (_instance == null)
            {
                throw new UnityException("UI Manager is NULL");
            }
            
            return _instance;
        }
    }

    public Text playerLootShopText;
    public Text playerLootUIText;
    public GameObject[] lifeDisplay;
    public Image selector;
    public GameObject victoryPanel;

    public void OpenShop(int lootCount)
    {
        playerLootShopText.text = "" + lootCount + "G";
    }

    public void UpdateSelector(int yPos)
    {
        selector.gameObject.SetActive(true);
        selector.rectTransform.anchoredPosition = new Vector2(selector.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateLootCount(int count)
    {
        playerLootUIText.text = "" + count;
    }

    public void UpdateHealth(int livesRemaining)
    {
        for (int i = 0; i < lifeDisplay.Length; i++)
        {
            if (i == livesRemaining)
            {
                lifeDisplay[i].SetActive(false);
            }
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Awake()
    {
        _instance = this;
    }
}
