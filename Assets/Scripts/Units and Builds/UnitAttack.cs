using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] private int unitCost; //SO
    public static int unitCoststatic;
    [SerializeField] private float radius; //SO;
    [SerializeField] private float shootingSpeed = 1f;
    private Coroutine _coroutine;
    public GameObject bullet;

    private void Start()
    {
        unitCoststatic = unitCost;
    }

    private void Update()
    {
        DetectCollision();
    }

    private void DetectCollision()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        
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
        obj.GetComponent<BulletController>().position = enemyPosition.transform.position;
        yield return new WaitForSeconds(shootingSpeed);
        StopCoroutine(_coroutine);
        _coroutine = null;
    }
}
