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
		public bool padlockClose;
		public bool isFlash = false;
		public bool isInven = false;
		public bool isPause = false;
		public bool isPanel = false;
		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Inventory")]
		public GameObject inventory;
		public GameObject pausePanel;
		public GameObject startPanel;
        [Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

        [SerializeField] private ThemedKeyInventoryController controller;
		[SerializeField] private Slider batteryUI;
        [SerializeField] private string flashSound = "Flashlight";
		[SerializeField] private PlayerRaycast playerRaycast;
		[SerializeField] private GameObject doorlockedText;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        public void OnMove(InputValue value)
		{
			if(!startPanel.activeSelf && GameManager.Instance.controller.enabled == true)
			  MoveInput(value.Get<Vector2>());
			else
			{
				MoveInput(Vector2.zero);
            }
		}

		public void OnLook(InputValue value)
		{
			if(!startPanel.activeSelf)
			{
				if(pause == false)
				{
                    if (isPanel != true)
                    {
                        if (cursorInputForLook)
                        {
                            LookInput(value.Get<Vector2>());
                        }
                    }
                    else if (isInven == true)
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
                else
                {
                    LookInput(new Vector2(0, 0));
                }
            }
		}

		public void OnFlash(InputValue value)
		{
            if (!startPanel.activeSelf)
			{
                if (GameManager.Instance.hasFlashLight && batteryUI.value > 0)
                {
                    isFlash = !isFlash;
                    FlashInput(isFlash);
                    AudioManager.instance.Play(flashSound);
                }
            }
		}

		public void OnInventory(InputValue value)
		{
            if (!startPanel.activeSelf)
			{
                isInven = !isInven;
                InventoryInput(isInven);
            }
        }

		public void OnPickUp(InputValue value)
		{
            if (!startPanel.activeSelf && playerRaycast.rayhitF && !doorlockedText.activeSelf)
                PickUpInput(value.isPressed);
		}

		public void OnDrawer(InputValue value)
		{
            if (!startPanel.activeSelf && playerRaycast.rayhitE)
                DrawerInput(value.isPressed);
		}

		public void OnBattery(InputValue value)
		{
            if (!startPanel.activeSelf && GameManager.Instance.hasBattery)
			{
                if (GameManager.Instance.hasFlashLight && batteryUI.value < 1)
                {
                    BatteryInput(value.isPressed);
                }
            }
		}

		public void OnPause(InputValue value)
		{
            if (!startPanel.activeSelf)
			{
                isPause = !isPause;
                PauseInput(isPause);
            }
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

		public void PadlockCloseInput(bool newPadlockState)
		{
			padlockClose = newPadlockState;
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