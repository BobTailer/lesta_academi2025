using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Entity _entity;

    [SerializeField] private Image _fillBar;
    [SerializeField] private Text _healthText;

    private void Update()
    {
        if (_entity == null) return;

        // Обновление текста здоровья
        _healthText.text = $"{_entity.currentHP} / {_entity.maxHP}";

        // Обновление заполнения полоски здоровья
        float fillAmount = _entity.maxHP > 0 ? (float)_entity.currentHP / _entity.maxHP : 0f;
        _fillBar.fillAmount = Mathf.Clamp01(fillAmount);
    }
}
