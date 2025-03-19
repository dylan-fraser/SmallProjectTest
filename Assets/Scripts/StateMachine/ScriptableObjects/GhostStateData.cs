using UnityEngine;

[CreateAssetMenu(fileName = "GhostStateData", menuName = "Scriptable Objects/GhostStateData")]
public class GhostStateData : ScriptableObject
{
    public float _speed = 10.0f;
    public float _rotationSmoothTime = 0.05f;
    public float _gravityMultiplier = 2.0f;

    public Material _stateMaterial;
}
