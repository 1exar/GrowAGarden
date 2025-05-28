using GrowAGarden.Scripts.Player.Interfaces;
using UnityEngine;
using Zenject;

namespace GrowAGarden.Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;

        [SerializeField] private Transform camera;
        [SerializeField] private Vector3 cameraOffset;
        
        private CharacterController characterController;
        private IPlayerInputProvider inputProvider;

        [Inject]
        public void Construct(IPlayerInputProvider input)
        {
            inputProvider = input;
        }

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Vector2 input = inputProvider.MovementInput;
            Vector3 move = new Vector3(input.x, 0f, input.y);

            if (move.magnitude > 1f)
                move.Normalize();

            characterController.SimpleMove(move * moveSpeed);
            camera.transform.localPosition = transform.localPosition + cameraOffset;

            if (move != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(move);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            }
        }
    }
}