using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    GameObject _menuPanel;
    int _selectedItem;
    Player _player;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player = other.GetComponent<Player>();
            if (_player != null)
            {
                _menuPanel.SetActive(true);
                UIManager.Instance.OpenShop(_player.loot);
            }

        }
    }

    public void SelectItem(int item) //Items are ID'd by their cost
    {
        _selectedItem = item;
        switch (item)
        {
            case 200: //flame sword
                UIManager.Instance.UpdateSelector(195);
                break;
            case 400: //boots of flying
                UIManager.Instance.UpdateSelector(95);
                break;
            case 100: //key to the castle
                UIManager.Instance.UpdateSelector(-6);
                break;
            default:
                break;
        }
    }

    public void Buy()
    {
        if (_player.loot >= _selectedItem)
        {
            switch (_selectedItem)
            {
                case 200:
                    Debug.Log("Flaming Sword Purchased");
                    break;
                case 400:
                    Debug.Log("Boots of Flight Purchased");
                    break;
                case 100:
                    GameManager.Instance.HasKeyToCastle = true;
                    break;
                default:
                    break;
            }
            GameManager.Instance.LootLose(_selectedItem);
            UIManager.Instance.OpenShop(_player.loot);
            _menuPanel.SetActive(false);
        }
        else
        {
            _menuPanel.SetActive(false);
        }
    }
    
    //buy method
    //if player gems >= item cost
    //subtract item cost
    //else cancel sale

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _menuPanel.SetActive(false);
        }
    }
}
