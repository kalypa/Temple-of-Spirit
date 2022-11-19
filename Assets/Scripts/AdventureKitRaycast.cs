using UnityEngine;
using UnityEngine.UI;

namespace AdventurePuzzleKit
{
    public class AdventureKitRaycast : MonoBehaviour
    {
        [Header("Raycast Length/Layer")]
        [SerializeField] private int rayLength = 5;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string exludeLayerName = null;
        private AKItemController raycasted_obj;
        private DrawerController drawer;
        [SerializeField] private Image crosshair = null;
        [SerializeField] private GameObject pickUpText = null;
        [SerializeField] private GameObject OpenText = null;
        [SerializeField] private GameObject CloseText = null;
        [HideInInspector] public bool doOnce;

        private bool isCrosshairActive;
        private const string pickupTag = "InteractiveObject";
        private const string openTag = "Drawer";

        private void Update()
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(exludeLayerName) | layerMaskInteract.value;
            if(InputSystem.InputSystems.Instance.isInven != true)
            {
                crosshair.enabled = true;
                if (Physics.Raycast(transform.position, fwd, out RaycastHit hit, rayLength, mask))
                {
                    if (hit.collider.CompareTag(pickupTag))
                    {
                        if (!doOnce)
                        {
                            raycasted_obj = hit.collider.gameObject.GetComponent<AKItemController>();
                            CrosshairChange(true);
                            pickUpText.SetActive(true);
                        }

                        isCrosshairActive = true;
                        doOnce = true;

                        if (InputSystem.InputSystems.Instance.pickup)
                        {
                            raycasted_obj.InteractionType();
                            InputSystem.InputSystems.Instance.pickup = false;
                        }
                    }
                    else if(hit.collider.CompareTag(openTag))
                    {
                        if (!doOnce)
                        {
                            drawer = hit.collider.gameObject.GetComponent<DrawerController>();
                            CrosshairChange(true);
                            if(drawer.drawerState == DrawerController.DrawerState.Close)
                            {
                                OpenText.SetActive(true);
                            }
                            else if(drawer.drawerState == DrawerController.DrawerState.Open)
                            {
                                CloseText.SetActive(true);
                            }
                        }

                        isCrosshairActive = true;
                        doOnce = true;
                        if (InputSystem.InputSystems.Instance.drawer)
                        {
                            DrawerController.Instance.DrawerCheck();
                        }
                    }
                    else
                    {
                        if (isCrosshairActive)
                        {
                            pickUpText.SetActive(false);
                            OpenText.SetActive(false);
                            CloseText.SetActive(false);
                            InputSystem.InputSystems.Instance.pickup = false;
                            CrosshairChange(false);
                            doOnce = false;
                        }
                    }
                }

                else
                {
                    if (isCrosshairActive)
                    {
                        pickUpText.SetActive(false);
                        OpenText.SetActive(false);
                        CloseText.SetActive(false);
                        InputSystem.InputSystems.Instance.pickup = false;
                        CrosshairChange(false);
                        doOnce = false;
                    }
                }
            }
            else
            {
                pickUpText.SetActive(false);
                OpenText.SetActive(false);
                CloseText.SetActive(false);
                crosshair.enabled = false;
            }
        }

        void CrosshairChange(bool on)
        {
            if (on && !doOnce)
            {
                crosshair.color = Color.red;
            }
            else
            {
                crosshair.color = Color.white;
                isCrosshairActive = false;
            }
        }
    }
}
