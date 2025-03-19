using UnityEngine;

[CreateAssetMenu(fileName = "TitanStateData", menuName = "Scriptable Objects/TitanStateData")]
public class TitanStateData : ScriptableObject
{
    public GameObject _attackToSpawn;
    public float _attackDamage;
    public float _attackCooldown;

    public float _speed = 5.0f;
    public float _rotationSmoothTime = 0.02f;
    public float _gravityMultiplier = 5.0f;

    public float _scaleChange = 0.2f;

    public int _health = 5;
    public Material _stateMaterial;
}
