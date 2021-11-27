using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Stateable
{
    GameState GetState();

    void SetState(GameState state);
}
