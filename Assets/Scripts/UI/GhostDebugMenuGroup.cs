using TMPro;
using UnityEngine;

public class GhostDebugMenuGroup : DebugMenuGroup
{
    private GhostStateData _stateData;

    [SerializeField] private TextMeshProUGUI _textMeshSpeed;

    [SerializeField] private TMP_InputField _inputFieldSpeed;

    private void Start()
    {
        _stateData = (GhostStateData)_data;
        _textMeshSpeed.text = _stateData._speed.ToString();

        _inputFieldSpeed.onValueChanged.AddListener(delegate { ValueChanged(_textMeshSpeed, _inputFieldSpeed, 2); });
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
            case 2:
                _stateData._speed = float.Parse(value);
                break;
        }
        textMesh.text = value;
        Debug.Log(textMesh);
    }
}
