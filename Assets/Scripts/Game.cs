using UnityEngine;
using UnityEditor;
using System;
using Random = UnityEngine.Random;
using UnityEngine.SocialPlatforms.Impl;

public class Game : MonoBehaviour
{
    public static event Action<bool> IsPausedChanged;

    public static bool IsPaused;

    public Scores Scores;
    public Ball[] BallPrefabs;
    public Bounds BallSpawnArea;
    public Bounds GameArea;
    Ball ballInstance;

    void Start()
    {
        SpawnBall();
    }

    void SpawnBall()
    {
        if (ballInstance != null)
            Destroy(ballInstance.gameObject);
        var randomBallPos = new Vector3(Mathf.Lerp(BallSpawnArea.min.x, BallSpawnArea.max.x, Random.value),
                                        Mathf.Lerp(BallSpawnArea.min.y, BallSpawnArea.max.y, Random.value),
                                        0);
        var ballPrefab = BallPrefabs[Random.Range(0, BallPrefabs.Length)];
        ballInstance = Instantiate(ballPrefab, randomBallPos, Quaternion.identity);
        var direction = Random.insideUnitCircle;
        direction.y = Mathf.Abs(direction.y);
        direction.Normalize();
        if (ballInstance.transform.position.y - GameArea.center.y > 0)
            direction.y = -direction.y;
        ballInstance.Direction = direction;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(GameArea.center, GameArea.size);
        Gizmos.color = new Color(0, 1, 1, 0.5f);
        Gizmos.DrawCube(BallSpawnArea.center, BallSpawnArea.size);
    }
    private void Update()
    {
        if (!GameArea.Contains(ballInstance.transform.position))
        {
            UpdateScores();
            SpawnBall();
        }
    }

    private void UpdateScores()
    {
        if (ballInstance.transform.position.y - GameArea.center.y > 0)
            Scores.UpdateScores(Scores.CurrentScore.Item1 + 1, Scores.CurrentScore.Item2);
        else
            Scores.UpdateScores(Scores.CurrentScore.Item1, Scores.CurrentScore.Item2 + 1);
    }
}