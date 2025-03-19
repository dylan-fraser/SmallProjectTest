using TMPro;
using UnityEngine;

public class FighterDebugMenuGroup : DebugMenuGroup
{
    private FighterStateData _stateData;

    [SerializeField] private TextMeshProUGUI _textMeshDamage;
    [SerializeField] private TextMeshProUGUI _textMeshCooldown;
    [SerializeField] private TextMeshProUGUI _textMeshSpeed;
    [SerializeField] private TextMeshProUGUI _textMeshHealth;

    [SerializeField] private TMP_InputField _inputFieldDamage;
    [SerializeField] private TMP_InputField _inputFieldCooldown;
    [SerializeField] private TMP_InputField _inputFieldSpeed;
    [SerializeField] private TMP_InputField _inputFieldHealth;

    private void Start()
    {
        _stateData = (FighterStateData)_data;
        _textMeshDamage.text = _stateData._attackDamage.ToString();
        _textMeshCooldown.text = _stateData._attackCooldown.ToString();
        _textMeshSpeed.text = _stateData._speed.ToString();
        _textMeshHealth.text = _stateData._health.ToString();

        _inputFieldDamage.onValueChanged.AddListener(delegate { ValueChanged(_textMeshDamage, _inputFieldDamage, 0); });
        _inputFieldCooldown.onValueChanged.AddListener(delegate { ValueChanged(_textMeshCooldown, _inputFieldCooldown, 1); });
        _inputFieldSpeed.onValueChanged.AddListener(delegate { ValueChanged(_textMeshSpeed, _inputFieldSpeed, 2); });
        _inputFieldHealth.onValueChanged.AddListener(delegate { ValueChanged(_textMeshHealth, _inputFieldHealth, 3); });
    }

    public void ValueChanged(TextMeshProUGUI textMesh, TMP_InputField inputField, int selector)
    {
        string value = inputField.text;

        if (string.IsNullOrEmpty(value))
        {
            Debug.Log("Needs to be set to a proper value.");
            return;
        }

        switch (selector)
        {
            case 0:
                _stateData._attackDamage = float.Parse(value);
                break;
            case 1:
                _stateData._attackCooldown = float.Parse(value);
                break;
            case 2:
                _stateData._speed = float.Parse(value);
                break;
            case 3:
                _stateData._health = int.Parse(value);
                break;
        }
        textMesh.text = value;
        Debug.Log(textMesh);
    }
}
