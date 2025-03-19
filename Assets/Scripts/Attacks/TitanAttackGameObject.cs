using UnityEngine;

public class TitanAttackGameObject : AttackGameObject
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _bulletCount = 8;
    [SerializeField] private float _bulletSpeed = 10.0f;
    public override void InitializeAttack(float damage, GameObject parent = null, float lifetime = 0.5f)
    {
        base.InitializeAttack(damage, parent, lifetime);

        Vector3 direction = transform.forward;
        float spinAmount = 360.0f/_bulletCount;
        
        for(int i = 0; i < _bulletCount; ++i)
        {
            GameObject bulletObject = Instantiate(_bulletPrefab, this.transform.position, this.transform.rotation);
            Rigidbody bulletRigidbody = bulletObject.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(direction * _bulletSpeed);
            direction = Quaternion.AngleAxis(spinAmount, Vector3.up) * direction;
            Destroy(bulletObject, 0.1f);
        }
    }
}
