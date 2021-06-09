using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

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

    [SerializeField] private Button hermoorGateButton;
    [SerializeField] private Button earthGateButton;
    [SerializeField] private Button gronorGateButton;
    [SerializeField] private Button rahaGateButton;
    [SerializeField] private Button wodasGateButton;
    [SerializeField] private Button liridianGateButton;
    [SerializeField] private Button brenitGateButton;
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

    private void OnEnable()
    {
        ResourceManager.onResourceChange += InventoryAmountUpdate;
    }

    private void OnDisable()
    {
        ResourceManager.onResourceChange -= InventoryAmountUpdate;
    }

    private void Awake()
    {
        Instance = this;

        gateList = Resources.Load<GateListSO>(typeof(GateListSO).Name);

        CheckGateStatus();
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

        InventoryAmountUpdate();
        #endregion

    }

    void Update()
    {
        GateMenuControl();
        InventoryMenuControl();
        MainMenuControl();
    }

    private void OnGateCrafted(GateSO result)
    {
        SetInventoryGateImage(result, .5f);
    }

    private void SetVisibility(Image image, float visibility)
    {
        var temp = image.color;
        temp.a = visibility;
        image.color = temp;
    }

    private void SetInventoryGateButton(GateSO targetGate, bool isEnable)
    {
        switch (targetGate.gateType)
        {
            case GateType.Hermoor:
                hermoorGateButton.enabled = isEnable;
                break;
            case GateType.Earth:
                earthGateButton.enabled = isEnable;
                break;
            case GateType.Gronor:
                gronorGateButton.enabled = isEnable;
                break;
            case GateType.Raha:
                rahaGateButton.enabled = isEnable;
                break;
            case GateType.Wodas:
                wodasGateButton.enabled = isEnable;
                break;
            case GateType.Liridian:
                liridianGateButton.enabled = isEnable;
                break;
            case GateType.Brenit:
                brenitGateButton.enabled = isEnable;
                break;
            default:
                break;
        }
    }

    public void SetInventoryGateImage(GateSO targetGate, float visibility)
    {
        switch (targetGate.gateType)
        {
            case GateType.Hermoor:
                SetVisibility(hermoorGateImage, visibility);
                break;
            case GateType.Earth:
                SetVisibility(earthGateImage, visibility);
                break;
            case GateType.Gronor:
                SetVisibility(gronorGateImage, visibility);
                break;
            case GateType.Raha:
                SetVisibility(rahaGateImage, visibility);
                break;
            case GateType.Wodas:
                SetVisibility(wodasGateImage, visibility);
                break;
            case GateType.Liridian:
                SetVisibility(liridianGateImage, visibility);
                break;
            case GateType.Brenit:
                SetVisibility(brenitGateImage, visibility);
                break;
            default:
                break;
        }

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
            SetInventoryGateButton(activeGate, true);
            craftButton.interactable = false;
            activeGate.gateRecipe.Use();
            OnGateCrafted(activeGate);
        }
    }

    public void GateActivateButton(GateSO targetGate)
    {
        if (targetGate.isActive)
        {
            GateManager.Instance.RemoveGateFromList(targetGate);
            Debug.Log("1");

            switch (targetGate.gateType)
            {
                case GateType.Hermoor:
                    hermoorGateButton.enabled = true;
                    break;
                case GateType.Earth:
                    earthGateButton.enabled = true;
                    break;
                case GateType.Gronor:
                    gronorGateButton.enabled = true;
                    break;
                case GateType.Raha:
                    rahaGateButton.enabled = true;
                    break;
                case GateType.Wodas:
                    wodasGateButton.enabled = true;
                    break;
                case GateType.Liridian:
                    liridianGateButton.enabled = true;
                    break;
                case GateType.Brenit:
                    brenitGateButton.enabled = true;
                    break;
                default:
                    break;
            }
        }
        else if (targetGate.isCrafted && !targetGate.isActive)
        {
            Debug.Log("3");

            GateManager.Instance.AddActiveGate(targetGate);

            switch (targetGate.gateType)
            {
                case GateType.Hermoor:
                    hermoorGateButton.enabled = true;
                    break;
                case GateType.Earth:
                    earthGateButton.enabled = true;
                    break;
                case GateType.Gronor:
                    gronorGateButton.enabled = true;
                    break;
                case GateType.Raha:
                    rahaGateButton.enabled = true;
                    break;
                case GateType.Wodas:
                    wodasGateButton.enabled = true;
                    break;
                case GateType.Liridian:
                    liridianGateButton.enabled = true;
                    break;
                case GateType.Brenit:
                    brenitGateButton.enabled = true;
                    break;
                default:
                    break;
            }
        }

        if (!targetGate.isCrafted)
        {
            SetInventoryGateButton(targetGate, false);
        }
    }

    private void CheckGateStatus()
    {
        foreach (GateSO gate in gateList.list)
        {
            if (gate.isActive && gate.isCrafted)
            {
                SetInventoryGateImage(gate, 1f);
            }
            else if (gate.isCrafted && !gate.isActive)
            {
                SetInventoryGateImage(gate, .5f);
            }
            else if (!gate.isCrafted)
            {
                SetInventoryGateImage(gate, .1f);
            }
        }
    }

    public void InventoryAmountUpdate()
    {
        hermitStoneAmountText.text = hermitStone.amount.ToString();
        WaterStoneAmountText.text = waterStone.amount.ToString();
        HermoWaterAmountText.text = hermoWater.amount.ToString();
        HydroIronAmountText.text = HydroIron.amount.ToString();
        IronStoneAmountText.text = ironStone.amount.ToString();
        AeroWaterStoneAmountText.text = aeroWaterStone.amount.ToString();
        AeroIronAmountText.text = aeroIron.amount.ToString();
        FixaronAmountText.text = fixaron.amount.ToString();
        AirStoneAmountText.text = airStone.amount.ToString();
    }


}
