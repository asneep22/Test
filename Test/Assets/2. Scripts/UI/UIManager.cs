using ButchersGames;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private BaseUIMenu _start_UI;
    [SerializeField] private GameUi _game_UI;
    [SerializeField] private BaseUIMenu _win_UI;
    [SerializeField] private BaseUIMenu _lose_UI;

    public BaseUIMenu StartUI { get => _start_UI; }
    public GameUi GameUI { get => _game_UI; }
    public BaseUIMenu WinUI { get => _win_UI; }
    public BaseUIMenu LoseUI { get => _lose_UI; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void ResetAll()
    {
        StartUI.Enable();
        GameUI.Disable();
        WinUI.Disable();
        LoseUI.Disable();
    }
}
