using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnByReleaseJoystic : MonoBehaviour
{
    public GameObject joystickObj;
    private JoystickControl joystick;

    public Transform objToSpawn;
    public float spawnDist;
    public float spawnSpeedRate;
    public float mass = 1.0f;

    private PlayerController pc = null;

    private void Awake()
    {
        if (joystickObj)
        {
            joystick = joystickObj.GetComponentInChildren<JoystickControl>();
        }
        if (joystick)
        {
            joystick.onRelease = SpawnPlatform;
            joystick.onDrag = DragEvent;
        }

        pc = GetComponent<PlayerController>();
    }

    private void DragEvent()
    {
        GameAudios.PlaySfx(gameObject, GameAudios.dragPlatformSfx);
    }

    private void SpawnPlatform(Vector3 direction)
    {
        if(!pc.CanSpawnPlatform())
        {
            return;
        }
        
        if(objToSpawn != null)
        {
            GameAudios.PlaySfx(gameObject, GameAudios.releasePlatformSfx);

            Transform platform = Instantiate(objToSpawn);
            platform.position = transform.position - direction.normalized * spawnDist;

            /*SlowdownByResistance slowdown = platform.GetComponent<SlowdownByResistance>();
            if (slowdown)
            {
                slowdown.SetInitVelocity(-spawnSpeedRate * direction);
            }*/
            Rigidbody2D platformRigidbody = platform.GetComponent<Rigidbody2D>();
            if(platformRigidbody == null)
            {
                platformRigidbody = platform.gameObject.AddComponent<Rigidbody2D>();
                platformRigidbody.mass = mass;
                platformRigidbody.gravityScale = 0.0f;
                platformRigidbody.drag = 0.0f;
                platformRigidbody.angularDrag = 0.0f;
                platformRigidbody.freezeRotation = true;
            }
           
            platformRigidbody.velocity = -spawnSpeedRate * direction;

            pc.AddPlatformNum(-1);
        }
    }

    public void SetJoystickState(bool bIsActive)
    {
        joystickObj.SetActive(bIsActive);
    }
}
