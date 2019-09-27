using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowJoystick : MonoBehaviour
{
    public bool bIsSpawn = true;

    private bool bShowJoystick = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Player")
        {
            return;
        }
        Debug.Log("Enter ShowJoystick!");
        GameAudios.PlaySfx(collision.collider.gameObject, GameAudios.landSfx);

        SpawnByReleaseJoystic joystick = collision.gameObject.GetComponent<SpawnByReleaseJoystic>();
        if (joystick && collision.contacts[0].normal.y < 0.0f)
        {
            joystick.SetJoystickState(true);
            bShowJoystick = true;

            PlayerController pc = collision.collider.GetComponent<PlayerController>();
            if (pc)
            {
                pc.SetLastPlatform(collision.collider.transform.position);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag != "Player")
        {
            return;
        }

        if (bIsSpawn)
        {
            bIsSpawn = false;
            return;
        }
        Debug.Log("Exit ShowJoystick!");

        SpawnByReleaseJoystic joystick = collision.gameObject.GetComponent<SpawnByReleaseJoystic>();
        if (joystick && bShowJoystick)
        {
            joystick.SetJoystickState(false);
            bShowJoystick = false;
        }
    }
}
