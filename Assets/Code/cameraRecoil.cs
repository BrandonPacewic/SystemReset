using UnityEngine;

public class cameraRecoil : MonoBehaviour
{
    // Rotations
    private Vector3 currentRotation;
    private Vector3 targetRotation;

    // Settings
    [SerializeField] public float recoilX;
    [SerializeField] public float recoilY;

    // Properties
    [SerializeField] public float snappiness;
    [SerializeField] public float returnSpeed;

    private Vector3 previousRotation;
    private cameraMovement camMovement;

    private void Start() 
    {
        currentRotation = new Vector3(0, 0, 0);
        targetRotation = currentRotation;
        previousRotation = currentRotation;
        camMovement = GetComponentInParent<cameraMovement>();
    }

    private void FixedUpdate() 
    {
        targetRotation = Vector3.
            Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.
            Slerp(
                currentRotation, 
                targetRotation, 
                snappiness * Time.fixedDeltaTime
            );

        camMovement.currentrecoil = currentRotation;
    }

    public void RecoilFire() 
    {
        targetRotation = new Vector3(
            recoilX,
            Random.Range(-recoilY, recoilY),
            0.0f
        );
    }
}
