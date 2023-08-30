using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField] private LevelSettings levelSettings;
    [SerializeField] private GameBalance gameBalance;
    [SerializeField] private GeneralFieldsUnitBalance generalFieldsUnitBalance;
    [SerializeField] private Text testEnemyLevelValue;
    [SerializeField] private GeneralFieldsUnitBalance lightUnit;
    [SerializeField] private GeneralFieldsUnitBalance heavyUnit;
    [SerializeField] private GeneralFieldsUnitBalance carUnit;
    private int _previosValue;
    private int _currentValue;
    public static int EnemyResources;
    public static int EnemyLevelValue;//общее количество очков (включая потраченные) 
    [SerializeField] private int countEnemyFactory;
    private int _countEnemyFactory;
    
    //spawnFactory
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject enemyFactory;
    private int _numberSpawnPoint;
    private int _numberUnitSpawnPoint;
    
    //spawnUnit's
    [SerializeField] private Transform[] unitsSpawnPoints;
    [SerializeField] private GameObject lightUnitModel;
    [SerializeField] private GameObject heavyUnitModel;
    [SerializeField] private GameObject carUnitModel;
    
    //attackBase
    private List<GameObject> players;
    [SerializeField] private GameObject ownBase;
    private void Start()
    {
        _numberSpawnPoint = 0;
        _numberUnitSpawnPoint = 0;
        EnemyResources = gameBalance.StartResouces;
        EnemyLevelValue = gameBalance.StartResouces;
        StartCoroutine(ChangeEnemyAction());
    }
    
    private IEnumerator ChangeEnemyAction()
    {
        while (true)
        {
            testEnemyLevelValue.text = EnemyLevelValue.ToString();
            yield return new WaitForSeconds(levelSettings.TimeChangeEnemyAction);
            
            if (EnemyLevelValue > levelSettings.FirstStepValue && EnemyLevelValue < levelSettings.SecondStepValue)
            {
                ChooseAction(levelSettings.SpawnFactoryFSV, levelSettings.SpawnUnitFSV, levelSettings.AttackBaseFSV, levelSettings.IgnoreFSV);
            }
            else if (EnemyLevelValue > levelSettings.SecondStepValue && EnemyLevelValue < levelSettings.ThirdStepValue)
            {
                ChooseAction(levelSettings.SpawnFactorySSV, levelSettings.SpawnUnitSSV, levelSettings.AttackBaseSSV, levelSettings.IgnoreSSV);
            } 
            else if (EnemyLevelValue > levelSettings.ThirdStepValue)
            {
                ChooseAction(levelSettings.SpawnFactoryTSV, levelSettings.SpawnUnitTSV, levelSettings.AttackBaseTSV, levelSettings.IgnoreTSV);
            }
        }
    }

    private void ChooseAction(int spawnFactory, int spawnUnit, int attackBase, int ignore)
    {
        var randomNumber = Random.Range(1, 101);
        
        if (spawnFactory != 0)
        {
            ValueChanger(spawnFactory);
            if (randomNumber > _previosValue && randomNumber <= _currentValue)
            {
                SpawnFactroy();
            }
        }

        if (spawnUnit != 0)
        {
            ValueChanger(spawnUnit);
            if (randomNumber > _previosValue && randomNumber <= _currentValue)
            {
                SpawnUnit();
            }
        }
        
        if (attackBase != 0)
        {
            ValueChanger(attackBase);
            if (randomNumber > _previosValue && randomNumber <= _currentValue)
            {
                AttackBase();
            }
        }
        
        if (ignore != 0)
        {
            ValueChanger(ignore);
            if (randomNumber > _previosValue && randomNumber <= _currentValue)
            {
                Ignore();
            }
        }
        ValueCleaner();
    }

    private void ValueCleaner()
    {
        _previosValue = 0;
        _currentValue = 0;
    }
    private void ValueChanger(int actionChance)
    {
        _previosValue = _currentValue;
        _currentValue += actionChance;
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
            //Spawn(carUnitModel, unitsSpawnPoints, _numberUnitSpawnPoint);
            var spawn = Instantiate(carUnitModel);
            spawn.transform.position = unitsSpawnPoints[_numberUnitSpawnPoint].position;
            _numberUnitSpawnPoint++;
            if (_numberUnitSpawnPoint == unitsSpawnPoints.Length)
            {
                _numberUnitSpawnPoint = 0;
            }
            EnemyResources -= carUnit.UnitCost;
        } 
        else if (EnemyResources >= heavyUnit.UnitCost)
        {
            //Spawn(heavyUnitModel, unitsSpawnPoints, _numberUnitSpawnPoint);
            var spawn = Instantiate(heavyUnitModel);
            spawn.transform.position = unitsSpawnPoints[_numberUnitSpawnPoint].position;
            _numberUnitSpawnPoint++;
            if (_numberUnitSpawnPoint == unitsSpawnPoints.Length)
            {
                _numberUnitSpawnPoint = 0;
            }
            EnemyResources -= heavyUnit.UnitCost;
        }
        else if (EnemyResources >= lightUnit.UnitCost)
        {
            //Spawn(lightUnitModel, unitsSpawnPoints, _numberUnitSpawnPoint);
            var spawn = Instantiate(lightUnitModel);
            spawn.transform.position = unitsSpawnPoints[_numberUnitSpawnPoint].position;
            _numberUnitSpawnPoint++;
            if (_numberUnitSpawnPoint == unitsSpawnPoints.Length)
            {
                _numberUnitSpawnPoint = 0;
            }
            EnemyResources -= lightUnit.UnitCost;
        }
    }

    private void Spawn(GameObject unit, Transform[] unitSpawnPoints, int spawnPointNumbers)
    {
        var spawn = Instantiate(unit);
        spawn.transform.position = unitSpawnPoints[spawnPointNumbers].position;
        spawnPointNumbers++;
        
        if (spawnPointNumbers == unitSpawnPoints.Length - 1)
        {
            spawnPointNumbers = 0;
        }
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
