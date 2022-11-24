using ItemInven;
using ItemSystem;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
using UnityEngine.UI;
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
		public bool battery;
		public bool pause;
		private bool isFlash = false;
		public bool isInven = false;
		public bool isPause = false;
		public bool isPanel = false;
		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Inventory")]
		public GameObject inventory;
		public GameObject pausePanel;
        [Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

        [SerializeField] private ThemedKeyInventoryController controller;
		[SerializeField] private Slider batteryUI;
        [SerializeField] private string flashSound = "Flashlight";
        [SerializeField] private AudioManager audioManager;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(pause == false)
			{
                if (cursorInputForLook)
                {
                    LookInput(value.Get<Vector2>());
                }
            }
			else
			{
                LookInput(new Vector2(0, 0));
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
			if(controller.hasFlashLight && batteryUI.value > 0)
			{
                isFlash = !isFlash;
                FlashInput(isFlash);
                audioManager.Play(flashSound);
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

		public void OnBattery(InputValue value)
		{
            if (controller.hasFlashLight && batteryUI.value < 1)
			{
                BatteryInput(value.isPressed);
            }
		}

		public void OnPause(InputValue value)
		{
			isPause = !isPause;
			PauseInput(isPause);
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
            isPanel = newInvenState;
		}

		public void PickUpInput(bool newPickUpState)
		{
			pickup = newPickUpState;
		}

		public void DrawerInput(bool newDrawerState)
		{
			drawer = newDrawerState;
		}

		public void BatteryInput(bool newBatteryState)
		{
            battery = newBatteryState;
		}

		public void PauseInput(bool newPauseState)
		{
			pause = newPauseState;
            isPanel = newPauseState;
        }

		private void Update()
		{
			CursorHide();
        }

		private void CursorHide()
		{
			if(inventory.activeSelf || pausePanel.activeSelf)
			{
                Cursor.visible = isPanel;
            }
			else
			{
                Cursor.visible = isPanel;
            }
			CursorLockModeState();

        }

		private void CursorLockModeState()
		{
            Cursor.lockState = isPanel ? CursorLockMode.None : CursorLockMode.Confined;
        }
	}
	
}