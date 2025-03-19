using UnityEngine;

[CreateAssetMenu(fileName = "FighterStateData", menuName = "Scriptable Objects/FighterStateData")]
public class FighterStateData : ScriptableObject
{
    #region Attack
    public GameObject _attackToSpawn;
    public float _attackDamage;
    public float _attackCooldown;
    #endregion

    #region Movement
    public float _speed = 8.0f;
    public float _rotationSmoothTime = 0.05f;
    public float _gravityMultiplier = 3.0f;
    #endregion

    public int _health = 2;
    public Material _stateMaterial;
}
