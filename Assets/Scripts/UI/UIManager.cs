using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Text playerLootCountText;
    public Image selector;

    public void OpenShop(int lootCount)
    {
        playerLootCountText.text = "" + lootCount + "G";
    }

    public void UpdateSelector(int yPos)
    {
        selector.rectTransform.anchoredPosition = new Vector2(selector.rectTransform.anchoredPosition.x, yPos);
    }

    private void Awake()
    {
        _instance = this;
    }
}
