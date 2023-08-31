using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField] private LevelSettings levelSettings;
    [SerializeField] private GameBalance gameBalance;
    [SerializeField] private GeneralFieldsUnitBalance generalFieldsUnitBalance;
    [SerializeField] private GeneralFieldsUnitBalance lightUnit;
    [SerializeField] private GeneralFieldsUnitBalance heavyUnit;
    [SerializeField] private GeneralFieldsUnitBalance carUnit;

    public static int EnemyResources;
    public static int EnemyLevelValue;//общее количество очков (включая потраченные) 
    [SerializeField] private int countEnemyFactory;
    private int _countEnemyFactory;
    
    //spawnFactory
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject enemyFactory;
    private int _numberSpawnPoint;
    
    //spawnUnit's
    [SerializeField] private Transform[] unitsSpawnPoints;
    [SerializeField] private GameObject lightUnitModel;
    [SerializeField] private GameObject heavyUnitModel;
    [SerializeField] private GameObject carUnitModel;
    
    //attackBase
    private List<GameObject> players;
    [SerializeField] private GameObject ownBase;
    private ChouseActionService _chouseActionService;
    private int _spawnPointNumbers;

    private void Start()
    {
        _numberSpawnPoint = 0;
        EnemyResources = gameBalance.StartResouces;
        EnemyLevelValue = gameBalance.StartResouces;
        StartCoroutine(ChangeEnemyAction());
        _chouseActionService = new ChouseActionService();
    }
    
    private IEnumerator ChangeEnemyAction()
    {
        while (true)
        {
            yield return new WaitForSeconds(levelSettings.TimeChangeEnemyAction);
            
            if (EnemyLevelValue > levelSettings.FirstStepValue && EnemyLevelValue < levelSettings.SecondStepValue)
            {
                MakeActionByEnum(_chouseActionService.ChooseAction(levelSettings.SpawnFactoryFSV, levelSettings.SpawnUnitFSV, 
                    levelSettings.AttackBaseFSV, levelSettings.IgnoreFSV));
            }
            else if (EnemyLevelValue > levelSettings.SecondStepValue && EnemyLevelValue < levelSettings.ThirdStepValue)
            {
                MakeActionByEnum(_chouseActionService.ChooseAction(levelSettings.SpawnFactorySSV, levelSettings.SpawnUnitSSV, 
                    levelSettings.AttackBaseSSV, levelSettings.IgnoreSSV));
            } 
            else if (EnemyLevelValue > levelSettings.ThirdStepValue)
            {
                MakeActionByEnum(_chouseActionService.ChooseAction(levelSettings.SpawnFactoryTSV, levelSettings.SpawnUnitTSV, 
                    levelSettings.AttackBaseTSV, levelSettings.IgnoreTSV));
            }
        }
    }

    private void MakeActionByEnum(ActionEnum actionEnum)
    {
        switch (actionEnum)
        {
            case ActionEnum.SpawnUnit:
                SpawnUnit();
                break;
            case ActionEnum.SpawnFactory:
                SpawnFactroy();
                break;
            case ActionEnum.AttackBase:
                AttackBase();
                break;
            case ActionEnum.Ignore:
                Ignore();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void SpawnFactroy()
    {
        if (_countEnemyFactory == countEnemyFactory) return;
        if (EnemyResources < generalFieldsUnitBalance.UnitCost) return;
        
        var spawn = Instantiate(enemyFactory);
        spawn.transform.position = spawnPoints[_numberSpawnPoint].position;
        _numberSpawnPoint++;
        if (_numberSpawnPoint == spawnPoints.Length)
        {
            _numberSpawnPoint = 0;
        }
        EnemyResources -= generalFieldsUnitBalance.UnitCost;
        _countEnemyFactory++;
    }

    private void SpawnUnit()
    {
        if (EnemyResources >= carUnit.UnitCost)
        {
            Spawn(carUnitModel, unitsSpawnPoints);
            EnemyResources -= carUnit.UnitCost;
        } 
        else if (EnemyResources >= heavyUnit.UnitCost)
        {
            Spawn(heavyUnitModel, unitsSpawnPoints);
            EnemyResources -= heavyUnit.UnitCost;
        }
        else if (EnemyResources >= lightUnit.UnitCost)
        {
            Spawn(lightUnitModel, unitsSpawnPoints);
            EnemyResources -= lightUnit.UnitCost;
        }
    }

    private void Spawn(GameObject unit, Transform[] unitSpawnPoints)
    {
        var targetTransform = unitSpawnPoints[Random.Range(0,unitSpawnPoints.Length)];
        Instantiate(unit, targetTransform.position, targetTransform.rotation);
    }

    private void AttackBase()
    {
        GameObject[] units = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var unit in units)
        {
            var unitMove = unit.GetComponent<NavMeshAgent>();
            if (unitMove)
            {
                unitMove.SetDestination(ownBase.transform.position);
            }
        }
    }
    
    private void Ignore()
    {
        
    }
}
