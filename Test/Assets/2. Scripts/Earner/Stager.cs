using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Stager : MonoBehaviour
{
    [System.Serializable]
    public class Stage
    {
        [SerializeField] private int _need_earn;
        [SerializeField] private Mesh _skin_mesh;
        [SerializeField] private Color _fill_area_color;

        public int NeedEarn { get => _need_earn; }
        public Mesh SkinMesh { get => _skin_mesh; }
        public Color FillAreaColor { get => _fill_area_color; }
    }

    [SerializeField] private int _money_earned;
    [SerializeField] private UnityEvent _on_less = new();

    [SerializeField, Min(1)] private int _start_stage_index = 1;
    [SerializeField] private List<Stage> _stages = new();
    [SerializeField] private Slider _slider;

    private Stage _current_stage;
    private MeshFilter _mesh_filter;
    private UnityEvent _on_stage_changed = new();

    private int _current_stage_index;
    public int CurrentStageIndex { get => _current_stage_index; }

    private void Start()
    {
        _mesh_filter = GetComponent<MeshFilter>();
        _on_stage_changed.AddListener(() => UpdateStage());
        _update_slider_max_value();

        _current_stage_index = _start_stage_index;
        _money_earned = _stages[_current_stage_index - 1].NeedEarn;
        UIManager.Instance.GameUI.UpdateEarnedMoneyText(_money_earned);
        _update_slider();
        UpdateStage();
    }

    public int MoneyEarned
    {
        get => _money_earned;
    }

    public void Add(int val)
    {
        _money_earned += val;
        UIManager.Instance.GameUI.UpdateEarnedMoneyText(_money_earned);

        _update_slider();

        if (_money_earned >= _current_stage.NeedEarn)
            IncreaseStage();
    }

    public void Substract(int val)
    {
        _money_earned -= val;
        UIManager.Instance.GameUI.UpdateEarnedMoneyText(_money_earned);

        if (_money_earned <= _current_stage.NeedEarn)
            DecreaseStage();

        _update_slider();

        if (_money_earned <= 0)
            _on_less?.Invoke();
    }

    public void IncreaseStage()
    {
        _current_stage_index++;
        _on_stage_changed?.Invoke();

    }

    public void DecreaseStage()
    {
        _on_stage_changed?.Invoke();
        _current_stage_index--;
    }

    private void UpdateStage()
    {
        if (_current_stage_index > _stages.Count - 1 || _current_stage_index < 0)
            return;

        _current_stage = _stages[_current_stage_index];
        _slider.fillRect.GetComponent<Image>().color = _stages[_current_stage_index].FillAreaColor;
        _mesh_filter.mesh = _current_stage.SkinMesh;
    }

    private void _update_slider_max_value()
    {
        _slider.maxValue = _stages[_stages.Count - 1].NeedEarn;
    }

    private void _update_slider()
    {
        _slider.value = _money_earned;
    }
}
