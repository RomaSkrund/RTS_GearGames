using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] private UnitBalance unitBalance;
    [SerializeField] private float shootingSpeed = 1f;
    private Coroutine _coroutine;
    public GameObject bullet;
    
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
        GameObject obj = Instantiate(bullet, transform.GetChild(3).position, Quaternion.identity);
        BulletController bulletController = obj.GetComponent<BulletController>();
        bulletController.TargetPosition = enemyPosition.transform.position;
        bulletController.causedDamage = unitBalance.UnitDamage;
        yield return new WaitForSeconds(shootingSpeed);
        StopCoroutine(_coroutine);
        _coroutine = null;
    }
}
