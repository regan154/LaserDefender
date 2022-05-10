using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")] 
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float fltmoveSpeed = 5f;
    [SerializeField] float flttimeBetweenEnemySpawns = 1f;
    [SerializeField] float fltspawnTimeVariance = 0f;
    [SerializeField] float fltminimumSpawnTime = 0.2f;

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }
     public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return fltmoveSpeed;
    }
    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(flttimeBetweenEnemySpawns - fltspawnTimeVariance,
                                        flttimeBetweenEnemySpawns + fltspawnTimeVariance);
        return Mathf.Clamp(spawnTime, fltminimumSpawnTime, float.MaxValue);
    }
}
