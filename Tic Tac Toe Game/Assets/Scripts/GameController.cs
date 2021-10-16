using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController _instance = null;

    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameController>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("Game Controller");
                    _instance = go.AddComponent<GameController>();
                    _instance.InitializeController();
                    DontDestroyOnLoad(go);
                }
            }
            
            return _instance;
        }
    }

    private Sprite _crossSprite;
    private Sprite _circleSprite;
    
    private int[,] _moves;
    private bool _isFirstTurn;
    private int _cellsOpenedNumber;
    
    public string FirstPlayerName { get; private set; }
    public string SecondPlayerName { get; private set; }
    
    
    public int FirstPlayerScore { get; private set; }
    
    public int SecondPlayerScore { get; private set; }

    public Sprite CurrentFigure
    {
        get => (_isFirstTurn) ? _circleSprite : _crossSprite;
    }
    
    private void InitializeController()
    {
        _moves = new int[3, 3];
        FirstPlayerScore = 0;
        SecondPlayerScore = 0;
        ResetMoves();
        InitializeSprites();
    }

    private void InitializeSprites()
    {
        _circleSprite = Resources.Load<Sprite>("Sprites/circle_transparent");
        _crossSprite = Resources.Load<Sprite>("Sprites/cross_transparent");
    }
        
    private void ResetMoves()
    {
        _isFirstTurn = true;
        _cellsOpenedNumber = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                _moves[i, j] = 0;
            }
        }
    }
    
    public void OpenCell(int cellNumber)
    {
        _moves[cellNumber / 3, cellNumber % 3] = (_isFirstTurn) ? 1 : 2;
        _cellsOpenedNumber++;
        if (CurrentPlayerWinsAfterMove(cellNumber))
        {
            OpenEndGameMenu((_isFirstTurn) ? $"{FirstPlayerName} Won" : $"{SecondPlayerName} Won");
            if (_isFirstTurn)
            {
                FirstPlayerScore++;
            }
            else
            {
                SecondPlayerScore++;
            }
            Scores.ShowScores();
        }
        else if (_cellsOpenedNumber == 9)
        {
            OpenEndGameMenu("Draw");
        }
        _isFirstTurn = !_isFirstTurn;
    }

    private bool CurrentPlayerWinsAfterMove(int cellNumber)
    {
        int row = cellNumber / 3;
        int col = cellNumber % 3;

        int[,] directions = DirectionsForCell(cellNumber);
        

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            if (SameAndNotNull(
                _moves[row, col],
                _moves[(row + directions[i, 0] + 3) % 3, (col + directions[i, 1] + 3) % 3],
                _moves[(row + 2 * directions[i, 0] + 3) % 3, (col + 2 * directions[i, 1] + 3) % 3]
            ))
            {
                return true;
            }
        }
        
        return false;
    }

    private int[,] DirectionsForCell(int cellNumber)
    {
        if (cellNumber % 2 == 1)
        {
            return new int[2,2]
            {
                { 1, 0 },
                { 0, 1 }
            };
        }
        else if (cellNumber == 4)
        {
            return new int[4,2]
            {
                { 1, 0 },
                { 0, 1 },
                { 1, -1 },
                { 1, 1 }
            };
        }
        else if (cellNumber == 0 || cellNumber == 8)
        {
            return new int[3,2]
            {
                { 1, 0 },
                { 0, 1 },
                { 1, 1 }
            };
        }
        else
        {
            return new int[3,2]
            {
                { 1, 0 },
                { 0, 1 },
                { 1, -1 }
            };
        }
    }
    
    private bool SameAndNotNull(int x, int y, int z)
    {
        return (x == y) && (y == z) && (x != 0);
    }

    private void OpenEndGameMenu(string message)
    {
        ((Menu)GameObject.FindObjectOfType<Canvas>().GetComponent<Menu>()).OpenMenu(message, true);
    }

    public void SetNames(string firstPlayerName, string secondPlayerName)
    {
        FirstPlayerName = firstPlayerName;
        SecondPlayerName = secondPlayerName;
    }
    public void RestartRound()
    {
        ResetMoves();
    }

    public void RestartGame()
    {
        ResetMoves();
        FirstPlayerScore = 0;
        SecondPlayerScore = 0;
        SceneManager.LoadScene(0);
    }
}
