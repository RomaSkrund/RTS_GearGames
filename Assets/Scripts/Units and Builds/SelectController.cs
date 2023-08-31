using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SelectController : MonoBehaviour
{
    [SerializeField] private GameObject cube; 
    public List<GameObject> players; 
    private Camera _cam;
    [SerializeField] private LayerMask layer, layerMask;
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
            MoveSelectedUnits(out var ray, out var agentTarget);
        }

        if (Input.GetMouseButtonDown(0))
        {
            SpawnSelectedCube(out var ray);
        }

        if (_cubeSelection)
        {
            SelectionCubeDirection(out var ray, out var hitDrag);
        }

        if (Input.GetMouseButtonUp(0) && _cubeSelection)
        {
            SelectUnits(out var hits);
        }
    }

    private void SelectUnits(out RaycastHit[] hits)
    {
        hits = Physics.BoxCastAll(_cubeSelection.transform.position,
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

    private void SelectionCubeDirection(out Ray ray, out RaycastHit hitDrag)
    {
        ray = _cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitDrag, 1000f, layer))
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

    private void SpawnSelectedCube(out Ray ray)
    {
        foreach (var el in players)
        {
            if (el != null)
            {
                el.transform.GetChild(2).gameObject.SetActive(false);
            }
        }

        players.Clear();

        ray = _cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out _hit, 1000f, layer))
        {
            _cubeSelection = Instantiate(cube, new Vector3(_hit.point.x, 0.56f, _hit.point.z),
                Quaternion.identity);
        }
    }

    private void MoveSelectedUnits(out Ray ray, out RaycastHit agentTarget)
    {
        ray = _cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out agentTarget, 1000f, layer))
        {
            foreach (var el in players)
            {
                if (el)
                {
                    el.GetComponent<NavMeshAgent>().SetDestination(agentTarget.point);
                }
            }
        }
    }
}
