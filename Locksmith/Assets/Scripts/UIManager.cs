using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Gate UI
    [Header("Gate UI")]

    public GameObject gateMenu;
    public GateSO activeGate;

    [SerializeField] private TextMeshProUGUI gateName;
    [SerializeField] private TextMeshProUGUI gateDescription;
    [SerializeField] private TextMeshProUGUI gateRequirement;
    [SerializeField] private TextMeshProUGUI adverseEffectsText;
    [SerializeField] private TextMeshProUGUI positiveEffectsText;
    [SerializeField] private Button craftButton;
    #endregion

    #region Inventory UI 
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

    [Header("Inventory UI Gate Images")]
    [SerializeField] private Image hermoorGateImage;
    [SerializeField] private Image earthGateImage;
    [SerializeField] private Image gronorGateImage;
    [SerializeField] private Image rahaGateImage;
    [SerializeField] private Image wodasGateImage;
    [SerializeField] private Image liridianGateImage;
    [SerializeField] private Image brenitGateImage;
    #endregion

    #region ResourceTypes
    private ResourceTypeSO hermitStone;
    private ResourceTypeSO waterStone;
    private ResourceTypeSO hermoWater;
    private ResourceTypeSO HydroIron;
    private ResourceTypeSO airStone;
    private ResourceTypeSO ironStone;
    private ResourceTypeSO aeroWaterStone;
    private ResourceTypeSO aeroIron;
    private ResourceTypeSO fixaron;
    #endregion
    [Space]
    public GameObject mainMenu;
    GateListSO gateList;

    private void Awake()
    {
        gateList = Resources.Load<GateListSO>(typeof(GateListSO).Name);
            }
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

        CheckGateCrafted();

    }

    void Update()
    {
        GateMenuControl();
        InventoryMenuControl();
        MainMenuControl();
           
    }
    private void OnGateCrafted(GateSO result)
    {
        switch (result.gateType)
        {
            case GateType.Hermoor:
                ChangeVisibility(hermoorGateImage, 1);
                break;
            case GateType.Earth:
                ChangeVisibility(earthGateImage, 1);
                break;
            case GateType.Gronor:
                ChangeVisibility(gronorGateImage, 1);
                break;
            case GateType.Raha:
                ChangeVisibility(rahaGateImage, 1);
                break;
            case GateType.Wodas:
                ChangeVisibility(wodasGateImage, 1);
                break;
            case GateType.Liridian:
                ChangeVisibility(liridianGateImage, 1);
                break;
            case GateType.Brenit:
                ChangeVisibility(brenitGateImage, 1);
                break;
            default:
                break;
        }
    }

    private void CheckGateCrafted()
    {
        foreach (GateSO gateSO in gateList.list)
        {
            if (!gateSO.isCrafted)
            {
                switch (gateSO.gateType)
                {
                    case GateType.Hermoor:
                        ChangeVisibility(hermoorGateImage, .5f);
                        break;
                    case GateType.Earth:
                        ChangeVisibility(earthGateImage, .5f);
                        break;
                    case GateType.Gronor:
                        ChangeVisibility(gronorGateImage, .5f);
                        break;
                    case GateType.Raha:
                        ChangeVisibility(rahaGateImage, .5f);
                        break;
                    case GateType.Wodas:
                        ChangeVisibility(wodasGateImage, .5f);
                        break;
                    case GateType.Liridian:
                        ChangeVisibility(liridianGateImage, .5f);
                        break;
                    case GateType.Brenit:
                        ChangeVisibility(brenitGateImage, .5f);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch(gateSO.gateType)
                {
                    case GateType.Hermoor:
                        ChangeVisibility(hermoorGateImage, 1f);
                    break;
                    case GateType.Earth:
                        ChangeVisibility(earthGateImage, 1f);
                    break;
                    case GateType.Gronor:
                        ChangeVisibility(gronorGateImage, 1f);
                    break;
                    case GateType.Raha:
                        ChangeVisibility(rahaGateImage, 1f);
                    break;
                    case GateType.Wodas:
                        ChangeVisibility(wodasGateImage, 1f);
                    break;
                    case GateType.Liridian:
                        ChangeVisibility(liridianGateImage, 1f);
                    break;
                    case GateType.Brenit:
                        ChangeVisibility(brenitGateImage, 1f);
                    break;
                    default:
                        break;
                }
            }
        }
    }

    private void ChangeVisibility(Image image, float visibility)
    {
        var temp = image.color;
        temp.a = visibility;
        image.color = temp;
    }
    // Menu Control metodlarının hepsi gözden geçirelecek, nihai sonuç bu değil.
    private void MainMenuControl()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameManager.Instance.isPaused)
            {
                Resume(inventoryMenu);
                Resume(gateMenu);
                Resume(mainMenu);
            }
            else
            {
                Pause(mainMenu);
            }
        }
    }

    // Menu Control metodlarının hepsi gözden geçirelecek, nihai sonuç bu değil.
    private void GateMenuControl()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameManager.Instance.isPaused)
            {
                Resume(gateMenu);
                Resume(inventoryMenu);
                Resume(mainMenu);
            }
            else
            {
                Pause(gateMenu);
            }
        }
    }

    // Menu Control metodlarının hepsi gözden geçirelecek, nihai sonuç bu değil.
    private void InventoryMenuControl()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (GameManager.Instance.isPaused)
            {
                Resume(inventoryMenu);
                Resume(gateMenu);
                Resume(mainMenu);
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
            craftButton.interactable = false;
            activeGate.gateRecipe.Use();
            OnGateCrafted(activeGate);
        }
    }
}
