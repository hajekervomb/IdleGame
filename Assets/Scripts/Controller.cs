using UnityEngine;
using TMPro;
using BreakInfinity;

public class Controller : MonoBehaviour
{
    public Data data;

    [SerializeField] private UpgradesManager upgradesManager;

    [SerializeField] private TMP_Text flasksText;
    [SerializeField] private TMP_Text flasksClickPowerText;


    [SerializeField] private BigDouble flasksPerClick = 1;

    private void Start()
    {
        data = new Data();

        upgradesManager.StartUpgradesManager();
    }
    
    public void GenerateFlasks()
    {
        data.flasks += ClickPower();
        UpdateUIText();
    }

    public BigDouble ClickPower()
    {
        return flasksPerClick + data.clickUpgradeLevel;
    }

    public void UpdateUIText()
    {
        flasksText.text = data.flasks + " Flasks";
        flasksClickPowerText.text = "+" + ClickPower() + " Flasks";
    }
}
