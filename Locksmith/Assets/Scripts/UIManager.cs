using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GateSO activeGate;

    [SerializeField] private TextMeshProUGUI gateName;
    [SerializeField] private TextMeshProUGUI gateDescription;
    [SerializeField] private TextMeshProUGUI gateRequirement;
    [SerializeField] private TextMeshProUGUI adverseEffectsText;
    [SerializeField] private TextMeshProUGUI positiveEffectsText;


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
            if (GameManager.Instance.isPaused)
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

    public void SetActiveGate(GateSO gate)
    {
        activeGate = gate;
        gateName.text = activeGate.gateName;
        gateDescription.text = activeGate.gateDescription;
        gateRequirement.text = activeGate.gateRequirementDescription;
        adverseEffectsText.text = activeGate.adverseEffectsDescription;
        positiveEffectsText.text = activeGate.positiveEffectsDescription;

    }

}
