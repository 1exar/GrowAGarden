using UnityEngine;

namespace GrowAGarden.Scripts.Player.Interfaces
{
    public interface IPlayerInputProvider
    {
        Vector2 MovementInput { get; }
    }
}