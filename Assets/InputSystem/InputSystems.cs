using ThemedKeySystem;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

#endif

namespace InputSystem
{
	public class InputSystems : SingleMonobehaviour<InputSystems>
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool flash;
		public bool inven;
		public bool pickup;
		public bool drawer;
		private bool isFlash = false;
		public bool isInven = false;
		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Inventory")]
		public GameObject inventory;

        [Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

        [SerializeField] private ThemedKeyInventoryController controller;
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
			if(controller.hasFlashLight)
			{
                isFlash = !isFlash;
                FlashInput(isFlash);
            }
		}

		public void OnInventory(InputValue value)
		{
            isInven = !isInven;
            InventoryInput(isInven);
        }

		public void OnPickUp(InputValue value)
		{
			PickUpInput(value.isPressed);
		}

		public void OnDrawer(InputValue value)
		{
			DrawerInput(value.isPressed);
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

		public void PickUpInput(bool newPickUpState)
		{
			pickup = newPickUpState;
		}

		public void DrawerInput(bool newDrawerState)
		{
			drawer = newDrawerState;
		}

		private void Update()
		{
			CursorHide();
        }

		private void CursorHide()
		{
			if(inventory.gameObject.activeSelf)
			{
                Cursor.visible = inven;
            }
			else
			{
                Cursor.visible = inven;
            }
			CursorLockModeState();

        }

		private void CursorLockModeState()
		{
            Cursor.lockState = inven ? CursorLockMode.None : CursorLockMode.Confined;
        }
	}
	
}