using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : ObectPool
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPostionY;
    [SerializeField] private float _minSpawnPostionY;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_prefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime > _secondsBetweenSpawn)
        {
            if(TryGetObject(out GameObject pipe))
            {
                _elapsedTime = 0;

                float spawnPosition = Random.Range(_minSpawnPostionY, _maxSpawnPostionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPosition, transform.position.z);
                pipe.SetActive(true);
                pipe.transform.position = spawnPoint;

                DisableObjectAbroadScreen();
            }
        }
    }
}
