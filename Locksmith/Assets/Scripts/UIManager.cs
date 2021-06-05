using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryMenu;

    void Start()
    {
        inventoryMenu.gameObject.SetActive(false);
    }

    void Update()
    {
        InventoryControl();
    }

    private void InventoryControl()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(GameManager.Instance.isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Resume()
    {
        inventoryMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameManager.Instance.isPaused = false;
    }

    private void Pause()
    {
        inventoryMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
        GameManager.Instance.isPaused = true;
    }
}
