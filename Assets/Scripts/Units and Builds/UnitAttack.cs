using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] private UnitBalance unitBalance;
    [SerializeField] private float shootingSpeed;
    private Coroutine _coroutine;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBulletPoint;
    
    private void Update()
    {
        DetectCollision();
    }

    private void DetectCollision()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, unitBalance.UnitRadiusAttack);
        
        if (hitColliders.Length == 0 && _coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;

            if (gameObject.CompareTag("Enemy"))
            {
                GetComponent<NavMeshAgent>().SetDestination(gameObject.transform.position);
            }
        }

        foreach (var el in hitColliders)
        {
            if ((gameObject.CompareTag("Player") && el.gameObject.CompareTag("Enemy"))
                || (gameObject.CompareTag("Enemy") && el.gameObject.CompareTag("Player")))
            {
                if (gameObject.CompareTag("Enemy"))
                {
                    GetComponent<NavMeshAgent>().SetDestination(el.transform.position);
                }

                if (_coroutine == null)
                {
                    _coroutine = StartCoroutine(StartAttack(el));
                }
            }
        }
    }

    IEnumerator StartAttack(Collider enemyPosition)
    {
        GameObject ownBullet = Instantiate(bullet, spawnBulletPoint.position, Quaternion.identity);
        BulletController ownBulletController = ownBullet.GetComponent<BulletController>();
        ownBulletController.TargetPosition = enemyPosition.transform.position;
        ownBulletController.causedDamage = unitBalance.UnitDamage;
        yield return new WaitForSeconds(shootingSpeed);
        StopCoroutine(_coroutine);
        _coroutine = null;
    }
}
