using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{


    [Header("Gate UI")]

    public GameObject gateMenu;
    public GateSO activeGate;

    [SerializeField] private TextMeshProUGUI gateName;
    [SerializeField] private TextMeshProUGUI gateDescription;
    [SerializeField] private TextMeshProUGUI gateRequirement;
    [SerializeField] private TextMeshProUGUI adverseEffectsText;
    [SerializeField] private TextMeshProUGUI positiveEffectsText;
    [SerializeField] private Button craftButton;

    [Header("Inventory UI")]

    public GameObject inventoryMenu;

    [SerializeField] private TextMeshProUGUI hermitStoneAmountText;
    [SerializeField] private TextMeshProUGUI WaterStoneAmountText;
    [SerializeField] private TextMeshProUGUI HermoWaterAmountText;
    [SerializeField] private TextMeshProUGUI HydroIronAmountText;
    [SerializeField] private TextMeshProUGUI AirStoneAmountText;
    [SerializeField] private TextMeshProUGUI IronStoneAmountText;
    [SerializeField] private TextMeshProUGUI AeroWaterStoneAmountText;
    [SerializeField] private TextMeshProUGUI AeroIronAmountText;
    [SerializeField] private TextMeshProUGUI FixaronAmountText;

    private ResourceTypeSO hermitStone;
    private ResourceTypeSO waterStone;
    private ResourceTypeSO hermoWater;
    private ResourceTypeSO HydroIron;
    private ResourceTypeSO airStone;
    private ResourceTypeSO ironStone;
    private ResourceTypeSO aeroWaterStone;
    private ResourceTypeSO aeroIron;
    private ResourceTypeSO fixaron;

    public List<GameObject> UIMenu;

    void Start()
    {
        #region Gate Menu

        gateMenu.gameObject.SetActive(false);

        if (activeGate.isCrafted) craftButton.interactable = false;

        gateName.text = activeGate.gateName;
        gateDescription.text = activeGate.gateDescription;
        gateRequirement.text = activeGate.gateRequirementDescription;
        adverseEffectsText.text = activeGate.adverseEffectsDescription;
        positiveEffectsText.text = activeGate.positiveEffectsDescription;
        #endregion

        #region Inventory Menu
        inventoryMenu.gameObject.SetActive(false);

        hermitStone = Resources.Load<ResourceTypeSO>("HermitStone");
        waterStone = Resources.Load<ResourceTypeSO>("WaterStone");
        hermoWater = Resources.Load<ResourceTypeSO>("HermoWaterStone");
        HydroIron = Resources.Load<ResourceTypeSO>("HydroIronStone");
        ironStone = Resources.Load<ResourceTypeSO>("IronStone");
        aeroWaterStone = Resources.Load<ResourceTypeSO>("AeroWaterStone");
        aeroIron = Resources.Load<ResourceTypeSO>("AeroIronStone");
        fixaron = Resources.Load<ResourceTypeSO>("Fixaron");
        airStone = Resources.Load<ResourceTypeSO>("AirStone");

        hermitStoneAmountText.text = hermitStone.amount.ToString();
        WaterStoneAmountText.text = waterStone.amount.ToString();
        HermoWaterAmountText.text = hermoWater.amount.ToString();
        HydroIronAmountText.text = HydroIron.amount.ToString();
        IronStoneAmountText.text = ironStone.amount.ToString();
        AeroWaterStoneAmountText.text = aeroWaterStone.amount.ToString();
        AeroIronAmountText.text = aeroIron.amount.ToString();
        FixaronAmountText.text = fixaron.amount.ToString();
        AirStoneAmountText.text = airStone.amount.ToString();
        #endregion
    }

    void Update()
    {
        GateMenuControl();
        InventoryMenuControl();

        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(activeGate.gateRecipe.CanCraft());
        }
    }

    private void GateMenuControl()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameManager.Instance.isPaused)
            {
                Resume(gateMenu);
                Resume(inventoryMenu);
            }
            else
            {
                Pause(gateMenu);
            }
        }
    }

    private void InventoryMenuControl()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (GameManager.Instance.isPaused)
            {
                Resume(inventoryMenu);
                Resume(gateMenu);
            }
            else
            {
                Pause(inventoryMenu);
            }
        }
    }

    private void Resume(GameObject UImenu)
    {
        UImenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameManager.Instance.isPaused = false;
    }

    private void Pause(GameObject UImenu)
    {
        UImenu.gameObject.SetActive(true);
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

        if (activeGate.isCrafted)
        {
            craftButton.interactable = false;
        }
        else if (!activeGate.gateRecipe.CanCraft())
        {
            craftButton.interactable = false;
        }
        else
        {
            craftButton.interactable = true;
        }
    }

    public void CraftButton()
    {
        if (activeGate.gateRecipe.CanCraft())
        {
            craftButton.interactable = true;
            activeGate.gateRecipe.Use();
        }
    }
}
