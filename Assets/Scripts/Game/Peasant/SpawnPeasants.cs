using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPeasants : MonoBehaviour
{
    [SerializeField] private Transform _spawn;
    [SerializeField] private PeasantID _peasant;
    [SerializeField] private float _spawnTimer;
    [SerializeField] private int _maxPeasantCount;


    private void Start()
    {       
        var createPeasant = StartCoroutine(CreatePeasant());
    }

    private IEnumerator CreatePeasant()
    {
        var waitSecods = new WaitForSeconds(_spawnTimer);
        for (uint i = 0; i < _maxPeasantCount; i++)
        {
            PeasantID enemy = Instantiate(_peasant, _spawn);
            yield return waitSecods;
        }
        
    }
}
