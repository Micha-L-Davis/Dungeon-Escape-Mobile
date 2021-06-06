using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    GameObject _menuPanel;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                _menuPanel.SetActive(true);
                UIManager.Instance.OpenShop(player._loot);
            }

        }
    }

    public void SelectItem(int item) //0 = flame sword, 1 = boots, 2 = key
    {
        Debug.Log("Select Item " + item);
        switch (item)
        {
            case 0:
                UIManager.Instance.UpdateSelector(195);
                break;
            case 1:
                UIManager.Instance.UpdateSelector(95);
                break;
            case 2:
                UIManager.Instance.UpdateSelector(-6);
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _menuPanel.SetActive(false);
        }
    }
}
