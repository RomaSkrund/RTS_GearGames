using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SelectController : MonoBehaviour
{
    [SerializeField] private GameObject cube; 
    public List<GameObject> players; 
    private Camera _cam;
    [SerializeField] private LayerMask layer, layerMask, interfaceLayer;
    private GameObject _cubeSelection;
    private RaycastHit _hit;

    private void Awake()
    {
        _cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && players.Count > 0)
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition); 

            if (Physics.Raycast(ray, out RaycastHit agentTarget, 1000f, layer))
            {
                foreach (var el in players)
                {
                    if (el) //должен быть пулл объектов которые хранят инфу что они выделенны, и когда они умирают они сами выходят из массива  
                    {
                        el.GetComponent<NavMeshAgent>().SetDestination(agentTarget.point);
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            foreach (var el in players)
            {
                if (el != null)
                {
                    el.transform.GetChild(2).gameObject.SetActive(false);
                }
            }

            players.Clear();

            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out _hit, 1000f, layer))
            {
                _cubeSelection = Instantiate(cube, new Vector3(_hit.point.x, 0.56f, _hit.point.z),
                    Quaternion.identity);
            }
        }

        if (_cubeSelection)
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition); 

            if (Physics.Raycast(ray, out RaycastHit hitDrag, 1000f, layer))
            {
                var xScale = (_hit.point.x - hitDrag.point.x) * -1;
                var zScale = (_hit.point.z - hitDrag.point.z) * -1;

                if (xScale < 0.0f && zScale < 0.0f)
                {
                    _cubeSelection.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                }
                else if (xScale < 0.0f)
                {
                    _cubeSelection.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
                }
                else if (zScale < 0.0f)
                {
                    _cubeSelection.transform.localRotation = Quaternion.Euler(new Vector3(180, 0, 0));
                }
                else
                {
                    _cubeSelection.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                }

                _cubeSelection.transform.localScale = new Vector3(Mathf.Abs(xScale), 0.56f, Mathf.Abs(zScale));
            }
        }

        if (Input.GetMouseButtonUp(0) && _cubeSelection) 
        {
            RaycastHit[] hits = Physics.BoxCastAll(_cubeSelection.transform.position,
                _cubeSelection.transform.localScale,
                Vector3.up, Quaternion.identity, 0, layerMask);

            foreach (var element in hits)
            {
                if (element.collider.CompareTag("Enemy")) continue;

                players.Add(element.transform.gameObject);

                element.transform.GetChild(2).gameObject.SetActive(true);
            }

            Destroy(_cubeSelection);
        }
    }
}
