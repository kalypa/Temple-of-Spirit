using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool flash;
		public bool inven;
		private bool isFlash = false;
		private bool isInven = false;
		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Inventory")]
		public GameObject inventory;

        [Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;


#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnFlash(InputValue value)
		{
			isFlash = !isFlash;
			FlashInput(isFlash);
		}

		public void OnInventory(InputValue value)
		{
            isInven = !isInven;
            InventoryInput(isInven);
        }
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void FlashInput(bool newFlashState)
		{
			flash = newFlashState;
        }

		public void InventoryInput(bool newInvenState)
		{
			inven = newInvenState;
		}

        private void OnApplicationFocus(bool hasFocus)
		{
			Debug.Log(inventory.gameObject.activeInHierarchy);
			if(!inventory.gameObject.activeInHierarchy)
			{
                SetCursorState(cursorLocked);
            }
			else
			{
				Cursor.lockState = CursorLockMode.None;
            }
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}