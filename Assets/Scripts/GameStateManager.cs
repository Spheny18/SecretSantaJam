using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour,Stateable
{
    public GameState gameState;

    public GameState GetState(){
        return GameState.PlayerAction;
    }

    public void SetState(GameState state){
        this.gameState = state;
    }

   
}

public enum GameState{
    PlayerAction,
    NPCAction,
    NaturalAction
};
