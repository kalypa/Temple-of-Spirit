using UnityEngine;
using UnityEngine.UI;

namespace ItemSystem
{
    public class PlayerRaycast : MonoBehaviour
    {
        [Header("Raycast Length/Layer")]
        [SerializeField] private int rayLength = 5;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string exludeLayerName = null;
        private ItemController raycasted_obj;
        private DrawerController drawer;
        [SerializeField] private Image crosshair = null;
        [SerializeField] private GameObject pickUpText = null;
        [SerializeField] private GameObject doorText = null;
        [SerializeField] private GameObject OpenText = null;
        [SerializeField] private GameObject CloseText = null;
        [HideInInspector] public bool doOnce;
        [HideInInspector] public bool rayhitE = false;
        [HideInInspector] public bool rayhitF = false;
        [HideInInspector] public bool rayhitM = false;

        private bool isCrosshairActive;
        private const string pickupTag = "InteractiveObject";
        private const string doorTag = "Door";
        private const string openTag = "Drawer";
        private const string PadlockTag = "Padlock";

        private void Update()
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(exludeLayerName) | layerMaskInteract.value;
            if(InputSystem.InputSystems.Instance.isInven != true && InputSystem.InputSystems.Instance.isPause != true)
            {
                crosshair.enabled = true;
                if (Physics.Raycast(transform.position, fwd, out RaycastHit hit, rayLength, mask))
                {
                    if (hit.collider.CompareTag(pickupTag))
                    {
                        if (!doOnce)
                        {
                            rayhitF = true;
                            rayhitE = false;
                            rayhitM = false;
                            raycasted_obj = hit.collider.gameObject.GetComponent<ItemController>();
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
                    else if (hit.collider.CompareTag(doorTag))
                    {
                        if (!doOnce)
                        {
                            rayhitF = true;
                            rayhitE = false;
                            rayhitM = false;
                            raycasted_obj = hit.collider.gameObject.GetComponent<ItemController>();
                            CrosshairChange(true);
                            doorText.SetActive(true);
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
                            rayhitF = false;
                            rayhitE = true;
                            rayhitM = false;
                            drawer = hit.collider.gameObject.GetComponent<DrawerController>();;
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
                            drawer.DrawerCheck();
                        }
                    }

                    else if (hit.collider.CompareTag(PadlockTag))
                    {
                        if (!doOnce)
                        {
                            rayhitF = true;
                            rayhitE = false;
                            rayhitM = true;
                            raycasted_obj = hit.collider.gameObject.GetComponent<ItemController>();
                            doorText.SetActive(true);
                            CrosshairChange(true);
                        }

                        isCrosshairActive = true;
                        doOnce = true;
                        if (InputSystem.InputSystems.Instance.pickup)
                        {
                            raycasted_obj.InteractionType();
                        }
                    }

                    else
                    {
                        if (isCrosshairActive)
                        {
                            rayhitF = false;
                            rayhitE = false;
                            doorText.SetActive(false);
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
                        rayhitF = false;
                        rayhitE = false;
                        doorText.SetActive(false);
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
                rayhitF = false;
                rayhitE = false;
                doorText.SetActive(false);
                pickUpText.SetActive(false);
                OpenText.SetActive(false);
                CloseText.SetActive(false);
                crosshair.enabled = false;
                doOnce = false;
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
