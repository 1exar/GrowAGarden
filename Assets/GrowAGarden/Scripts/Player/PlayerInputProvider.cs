using GrowAGarden.Scripts.Player.Interfaces;
using UnityEngine;

namespace GrowAGarden.Scripts.Player
{
    public class PlayerInputProvider : MonoBehaviour, IPlayerInputProvider
    {
        public Vector2 MovementInput
        {
            get
            {
                float x = Input.GetAxisRaw("Horizontal");
                float y = Input.GetAxisRaw("Vertical");
                return new Vector2(x, y);
            }
        }
    }
}