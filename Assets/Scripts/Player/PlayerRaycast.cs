using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ItemInven;
using Unity.VisualScripting;

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
        [SerializeField] private TextMeshProUGUI pickUpText = null;
        [SerializeField] private GameObject doorText = null;
        [SerializeField] private GameObject OpenText = null;
        [SerializeField] private GameObject CloseText = null;
        [SerializeField] private GameObject hideText = null;
        [SerializeField] private GameObject putText = null;
        [SerializeField] private Image pickUpTextImage = null;
        [HideInInspector] public bool doOnce;
        [HideInInspector] public ClosetController closet = null;
        [HideInInspector] public bool rayhitE = false;
        [HideInInspector] public bool rayhitF = false;

        private bool isCrosshairActive;
        private const string pickupTag = "InteractiveObject";
        private const string doorTag = "Door";
        private const string openTag = "Drawer";
        private const string PadlockTag = "Padlock";
        private const string hideTag = "Closet";
        private const string putTag = "Put";

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
                            raycasted_obj = hit.collider.gameObject.GetComponent<ItemController>();
                            CrosshairChange(true);
                            pickUpText.text = hit.collider.name;
                            pickUpTextImage.rectTransform.anchoredPosition = new Vector2(200, pickUpTextImage.rectTransform.anchoredPosition.y);
                            pickUpText.gameObject.SetActive(true);

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

                    else if (hit.collider.CompareTag(hideTag))
                    {
                        if (!doOnce)
                        {
                            rayhitF = true;
                            rayhitE = false;
                            closet = hit.collider.gameObject.GetComponent<ClosetController>();
                            raycasted_obj = hit.collider.gameObject.GetComponent<ItemController>();
                            CrosshairChange(true);
                            if(!closet.isHiding)
                            {
                                hideText.gameObject.SetActive(true);
                            }

                        }

                        isCrosshairActive = true;
                        doOnce = true;

                        if (InputSystem.InputSystems.Instance.pickup)
                        {
                            raycasted_obj.InteractionType();
                            InputSystem.InputSystems.Instance.pickup = false;
                        }
                    }

                    else if (hit.collider.CompareTag(putTag))
                    {
                        if (!doOnce)
                        {
                            rayhitF = true;
                            rayhitE = false;
                            raycasted_obj = hit.collider.gameObject.GetComponent<ItemController>();
                            CrosshairChange(true);
                            putText.gameObject.SetActive(true);
                        }

                        isCrosshairActive = true;
                        doOnce = true;

                        if (InputSystem.InputSystems.Instance.pickup)
                        {
                            raycasted_obj.InteractionType();
                            InputSystem.InputSystems.Instance.pickup = false;
                        }
                    }

                    else if (hit.collider.CompareTag(PadlockTag))
                    {
                        if (!doOnce)
                        {
                            rayhitF = true;
                            rayhitE = false;
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
                            pickUpText.gameObject.SetActive(false);
                            OpenText.SetActive(false);
                            CloseText.SetActive(false);
                            hideText.gameObject.SetActive(false);
                            putText.gameObject.SetActive(false);
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
                        pickUpText.gameObject.SetActive(false);
                        OpenText.SetActive(false);
                        CloseText.SetActive(false);
                        hideText.gameObject.SetActive(false);
                        putText.gameObject.SetActive(false);
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
                pickUpText.gameObject.SetActive(false);
                OpenText.SetActive(false);
                CloseText.SetActive(false);
                hideText.gameObject.SetActive(false);
                putText.gameObject.SetActive(false);
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
