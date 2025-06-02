using UnityEngine;

public class CarUIController : MonoBehaviour
{
    private CarColorCycler colorCycler;
    private GameObject doorFL;
    private GameObject doorFR;
    private GameObject doorRL;
    private GameObject doorRR;
    private EngineSoundController engineSound;

    [Header("AR Placement Reference")]
    public ARPlacementController placementController;

    public void SetCar(GameObject car)
    {
        colorCycler = car.GetComponentInChildren<CarColorCycler>();
        doorFL = car.transform.Find("door_fl")?.gameObject;
        doorFR = car.transform.Find("door_fr")?.gameObject;
        doorRL = car.transform.Find("door_rl")?.gameObject;
        doorRR = car.transform.Find("door_rr")?.gameObject;
        engineSound = car.GetComponentInChildren<EngineSoundController>();
    }

    public void ChangeCarColor()
    {
        if (colorCycler != null)
            colorCycler.CycleColor();
    }

    public void RotateWheels()
    {
        WheelRotator[] rotators = FindObjectsOfType<WheelRotator>();
        foreach (WheelRotator rotator in rotators)
        {
            rotator.ToggleRotation();
        }
    }

    public void ToggleDoorFL() => ToggleDoor(doorFL);
    public void ToggleDoorFR() => ToggleDoor(doorFR);
    public void ToggleDoorRL() => ToggleDoor(doorRL);
    public void ToggleDoorRR() => ToggleDoor(doorRR);

    private void ToggleDoor(GameObject door)
    {
        if (door != null)
            door.GetComponent<DoorController>()?.ToggleDoor();
    }

    public void ToggleEngine()
    {
        engineSound?.ToggleEngine();
    }

    public void SelectCarA()
    {
        placementController?.SelectCar(0);
    }

    public void SelectCarB()
    {
        placementController?.SelectCar(1);
    }
    public void ResetCar()
    {
        placementController?.ResetPlacement();
    }
}