using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamSpawn : MonoBehaviour
{
    [SerializeField] private HamID _ham;
    [SerializeField] private int _spawnTimer;

    private Transform _spawn;
    private Transform[] _spawnPoints;
        
    private void Awake()
    {
        _spawn = GetComponent<Transform>();
        _spawnPoints = GetComponentsInChildren<Transform>();
       
    }

    private void Start()
    {
        var ham = StartCoroutine(CreateHam());       
    }

    private IEnumerator CreateHam()
    {
        var waitSecods = new WaitForSeconds(_spawnTimer);
        for (int i = 1; i < _spawnPoints.Length; i++)
        {
            HamID enemy = Instantiate(_ham, _spawnPoints[i]);
            yield return waitSecods;
        }

    }
}
