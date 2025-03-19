using UnityEngine;

public class DebugMenu : MonoBehaviour
{
    [SerializeField] private GameObject _debugMenuElements;

    public void ActivateDebugMenu()
    {
        if(_debugMenuElements.activeSelf)
        {
            _debugMenuElements.SetActive(false);
        }
        else
        {
            _debugMenuElements.SetActive(true);
        }
    }
}
