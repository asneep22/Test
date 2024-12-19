using TMPro;
using UnityEngine;

public class GameUi : BaseUIMenu
{
    [SerializeField] private TextMeshProUGUI _earned_money_TMProUGUI;

    public TextMeshProUGUI EarnedMoneyTMProUGUI { get => _earned_money_TMProUGUI; }

    public void UpdateEarnedMoneyText(int earned_money)
    {
        _earned_money_TMProUGUI.text = earned_money.ToString();
    }
}
