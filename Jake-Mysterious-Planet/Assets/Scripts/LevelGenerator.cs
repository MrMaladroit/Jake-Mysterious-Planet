using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;
    // list of all possible chunks of level that can be copied and added to the level
    public List<LevelPiece> levelPrefabs = new List<LevelPiece>();


    public Transform levelStartPoint;
    // list of all levelPrefabs that currently exist in the level
    public List<LevelPiece> pieces = new List<LevelPiece>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GenerateInitialPieces();
    }

    public void GenerateInitialPieces()
    {
        for(int i = 0; i < 2; i++)
        {
            AddPiece();
        }
    }

    public void AddPiece()
    {
        int randomIndex = UnityEngine.Random.Range(0, levelPrefabs.Count);

        LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[randomIndex]);
        piece.transform.SetParent(this.transform, false);

        Vector3 spawnPosition = Vector3.zero;

        if (pieces.Count == 0)
        {
            spawnPosition = levelStartPoint.position;
        }
        else
        {
            spawnPosition = pieces[pieces.Count - 1].exitPoint.position;
        }
        piece.transform.position = spawnPosition;
        pieces.Add(piece);
    }

    public void RemoveOldestPiece()
    {
        LevelPiece oldestpiece = pieces[0];

        pieces.Remove(oldestpiece);
        Destroy(oldestpiece.gameObject);
    }

    public void RemoveAllObjectsInPiecesList()
    {
        pieces.Clear();
    }
}
