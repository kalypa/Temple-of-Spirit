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

        [HideInInspector] public bool doOnce;

        private bool isCrosshairActive;
        private const string pickupTag = "InteractiveObject";

        private void Update()
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(exludeLayerName) | layerMaskInteract.value;

            if (Physics.Raycast(transform.position, fwd, out RaycastHit hit, rayLength, mask))
            {
                if (hit.collider.CompareTag(pickupTag))
                {
                    if (!doOnce)
                    {
                        raycasted_obj = hit.collider.gameObject.GetComponent<AKItemController>();
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                    if (InputSystem.InputSystems.Instance.pickup)
                    {
                        raycasted_obj.InteractionType();
                        InputSystem.InputSystems.Instance.pickup = false;
                    }
                }
            }

            else
            {
                if (isCrosshairActive)
                {
                    InputSystem.InputSystems.Instance.pickup = false;
                    doOnce = false;
                }
            }
        }
    }
}
