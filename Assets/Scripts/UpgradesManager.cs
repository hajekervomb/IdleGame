using BreakInfinity;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    [SerializeField] private Controller controller;
    private Data data;

    [SerializeField] private BigDouble clickUpgradeBaseCost;
    [SerializeField] private BigDouble clickUpgradeCostMult;

    [SerializeField] private Upgrades clickUpgrade;

    [SerializeField] private string clickUpgradeName;

    public void StartUpgradesManager()
    {
        clickUpgradeBaseCost = 10;
        clickUpgradeCostMult = 1.5;
        UpdateClickUpgradeUI();
        controller.UpdateUIText();
        clickUpgradeName = " Flasks per click";
    }

    private BigDouble Cost()
    {
        return clickUpgradeBaseCost * BigDouble.Pow(clickUpgradeCostMult, controller.data.clickUpgradeLevel);
    }

    public void BuyUpgrade()
    {
        if (controller.data.flasks >= Cost())
        {             
            controller.data.flasks -= Cost();
            controller.data.clickUpgradeLevel += 1;            

            Debug.Log(Cost());

            UpdateClickUpgradeUI();
        }
    }

    private void UpdateClickUpgradeUI()
    {
        clickUpgrade.levelText.text = controller.data.clickUpgradeLevel.ToString();
        //clickUpgrade.nameText.text = controller.data.clickUpgradeLevel.ToString() + clickUpgradeName;
        clickUpgrade.costText.text = "Cost: " + Cost().ToString("F2") + " Flasks";
        controller.UpdateUIText();
    }
}
