using System.Collections.Generic;
using UnityEngine;

public class AttackGameObject : MonoBehaviour
{
    protected float _damage;
    protected GameObject _parent;
    protected List<GameObject> _hitEnemies;
    public virtual void InitializeAttack(float damage, GameObject parent = null, float lifetime = 0.5f)
    {
        _damage = damage;
        if(parent != null)
        {
            _parent = parent;
            this.transform.SetParent(parent.transform);
        }
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject != _parent && !_hitEnemies.Contains(collision.gameObject))
        {
            //HealthComponent enemyCollisionHealth = collision.gameObject.GetComponent<HealthComponent>();
            _hitEnemies.Add(collision.gameObject);
        }
    }
}
