using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class PlayerProgress : MonoBehaviour
{
    public List<PlayerProgressLevel> levels;
    private int _levelValue = 1;
    private float _experienceCurrentValue;
    private float _experienceTargetValue;
    public Image ExpBar;
    public TextMeshProUGUI levelValueTMP;
    private void Start()
    {
        SetLevel(_levelValue);
        DrawUI();
    }
    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if (_experienceCurrentValue >= _experienceTargetValue)
        {
            SetLevel(_levelValue += 1);
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }
    private void SetLevel(int value)
    {
        var currentLevel = levels[_levelValue - 1];
        _levelValue = value;
        _experienceTargetValue = currentLevel.experienceForTheNextLevel;
        GetComponent<FireballCaster>().damage = currentLevel.fireballDamage;
        var grenageCaster = GetComponent<GrenageCaster>();
        grenageCaster.damage = currentLevel.grenadeDamage;
        if (currentLevel.grenadeDamage < 0)
            grenageCaster.enabled = false;
        else
            grenageCaster.enabled = true;
    }
    private void DrawUI()
    {
        ExpBar.fillAmount = _experienceCurrentValue / _experienceTargetValue;
        levelValueTMP.text = _levelValue.ToString();
    }
}
