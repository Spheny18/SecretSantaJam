using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameState gameState;

}

public enum GameState{
    PlayerAction,
    NPCAction,
    NaturalAction
};
