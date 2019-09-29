using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public struct Pickups
{
    public int platformNum;
    public int energyNum;
    public int respawnNum;
    public int lifeNum;
};

[System.Serializable]
struct Velocity
{
    public Vector2 combVelocity;
    public Vector2 leftVelocity;
    public Vector2 rightVelocity;
    public Vector2 gravityAcceleration;
}

public class PlayerController : MonoBehaviour
{
    public Vector2 LeftForceDirection = new Vector2(1.0f, 2.0f), RightForceDirection = new Vector2(-1.0f, 2.0f);
    public float MinForce = 3.0f, ForceIncreaseRate = 1.0f, MaxForce = 6.0f;
    public float MaxVelocity = 50.0f;
    public float GravityMagnitude = 10.0f;
    // 小于该值，空气阻力与速度成正比；大于该值，空气阻力与速度平方成正比
    public float AirResistanceThreshold = 1.0f;
    // 空气阻力与速度正比系数
    public float AirResistanceRate = 0.2f;
    // 空气阻力与速度平方正比系数
    public float AirResistanceSquareRate = 0.5f;

    private bool bIsDead = false;

    private bool LeftInput;
    private bool RightInput;
    private float LeftForce;
    private float RightForce;

    [HideInInspector]
    public Vector2 Gravity;
    private Vector2 AirResistance;

    [SerializeField]
    private float Energy;
    private float maxEnergy;
    [SerializeField]
    private float ConsumeRate = 20.0f;

    // 是否使用点击才加力
    [SerializeField]
    private bool IsAddForceByClick;
    public bool bUseForce;

    [SerializeField]
    private EventSystem eventSystem = null;
    [SerializeField]
    private GraphicRaycaster graphicRaycaster= null;

    [SerializeField]
    private Velocity velocity;

    [SerializeField]
    private Pickups initPickups;
    private Pickups pickups;
    [SerializeField]
    private Pickups skillThreshold;
    [SerializeField]
    private float skillEnergyTime;
    private Vector3 lastPlatform ;
    private Vector2 respawnPlatform;
    private bool bRespawnPlatform;
    private float respawnTime = 0.5f;

    private int life = 1;

    private void Awake()
    {
        Gravity = new Vector2(0.0f, -GravityMagnitude);
        maxEnergy = Energy;
    }

    private void Start()
    {
        Init();
    }

    private void FixedUpdate()
    {
        CheckInput();
        if (bUseForce)
        {
            CalculateParamters();
            AddInputForce();
            AddOtherForce();
        }
        else
        {
            Move();
        }
    }

    private void LateUpdate()
    {
        Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
        if (rigid && rigid.velocity.sqrMagnitude > MaxVelocity*MaxVelocity)
        {
            rigid.velocity = rigid.velocity * rigid.velocity.magnitude / MaxVelocity;
        }
    }

    private void CheckInput()
    {
        if (IsOverUI() || IsEnergyOver() || bIsDead)
        {
            return;
        }

        if (Input.touchSupported)
        {
            if (Input.touchCount > 0)
            {
                Debug.Log("Add Force!");

                foreach (Touch touch in Input.touches)
                {
                    if (touch.position.x < Screen.width / 2 && (!IsAddForceByClick || touch.phase == TouchPhase.Began))
                    {
                        LeftInput = true;
                    }

                    if (touch.position.x > Screen.width / 2 && (!IsAddForceByClick || touch.phase == TouchPhase.Began))
                    {
                        RightInput = true;
                    }
                }
            }
            else
            {
                LeftForce = MinForce;
                RightForce = MinForce;
            }
        }
        else
        {
            if (IsAddForceByClick)
            {
                LeftForce = MinForce;
                RightForce = MinForce;

                if (Input.GetMouseButtonDown(0))
                {
                    if (Input.mousePosition.x < Screen.width / 2)
                    {
                        LeftInput = true;
                    }

                    if (Input.mousePosition.x > Screen.width / 2)
                    {
                        RightInput = true;
                    }
                }

                if (Input.GetMouseButtonUp(0))
                {

                }
                return;
            }

            if (Input.GetMouseButton(0))
            {
                Debug.Log("Add Force!" + Input.mousePosition);

                if (Input.mousePosition.x < Screen.width / 2)
                {
                    LeftInput = true;
                }

                if (Input.mousePosition.x > Screen.width / 2)
                {
                    RightInput = true;
                }
            }
            else
            {
                LeftForce = MinForce;
                RightForce = MinForce;
            }
        }
    }

    private bool IsOverUI()
    {
        if (Input.touchSupported && Input.touchCount > 0)
        {
            PointerEventData eventData = new PointerEventData(eventSystem);
            foreach(Touch touch in Input.touches)
            {
                eventData.pressPosition = touch.position;
                eventData.position = touch.position;

                List<RaycastResult> list = new List<RaycastResult>();
                graphicRaycaster.Raycast(eventData, list);
                if(list.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        return EventSystem.current.IsPointerOverGameObject();
    }

    private void Move()
    {
        Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
        if(rigid == null)
        {
            return;
        }

        if (LeftInput && RightInput)
        {
            rigid.velocity = velocity.combVelocity;
        }
        else if (LeftInput)
        {
            rigid.velocity = velocity.leftVelocity;
        }
        else if (RightInput)
        {
            rigid.velocity = velocity.rightVelocity;
        }
        else
        {
            rigid.velocity += velocity.gravityAcceleration;
        }

        LeftInput = false;
        RightInput = false;
    }

    private void CalculateParamters()
    {
        LeftForce = Mathf.Clamp(LeftForce + ForceIncreaseRate, MinForce, MaxForce);
        RightForce = Mathf.Clamp(RightForce + ForceIncreaseRate, MinForce, MaxForce);

        Vector2 ObjVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        AirResistance = -new Vector2(ResistanceFormula(ObjVelocity.x), ResistanceFormula(ObjVelocity.y));
    }

    private void AddInputForce()
    {
        if (LeftInput || RightInput)
        {
            GameAudios.PlaySfx(gameObject, GameAudios.jumpSfx);
        }

        if (LeftInput)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(LeftForce * LeftForceDirection.normalized);
            LeftInput = false;
            AddEnergy(-ConsumeRate);
        }

        if (RightInput)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(RightForce * RightForceDirection.normalized);
            RightInput = false;
            AddEnergy(-ConsumeRate);
        }
    }

    private void AddOtherForce()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Gravity);

        gameObject.GetComponent<Rigidbody2D>().AddForce(AirResistance);
    }

    private float ResistanceFormula(float speed)
    {
        if (speed > AirResistanceThreshold)
        {
            return Mathf.Sign(speed) * speed * speed * AirResistanceRate;
        }
        else
        {
            return speed * AirResistanceSquareRate;
        }
    }

    public void AddEnergy(float energy)
    {
        Energy = Mathf.Clamp(Energy + energy, -maxEnergy, maxEnergy);
        
    }

    public bool IsEnergyOver()
    {
        return Energy <= 0.0f;
    }

    public void OnDead()
    {
        bIsDead = true;

        GameAudios.PlaySfx(gameObject, GameAudios.landDeadSfx);

        if (bRespawnPlatform)
        {
            StartCoroutine(Respawn());
        }
        else
        {
            GameController.Get().GameOver();
            Destroy(gameObject, respawnTime);
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        transform.position = respawnPlatform;
        
        Init();
    }

    private void Init()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        bIsDead = false;

        Energy = maxEnergy;
        pickups.energyNum = initPickups.energyNum;
        pickups.lifeNum = initPickups.lifeNum;
        pickups.platformNum = initPickups.platformNum;
        pickups.respawnNum = initPickups.respawnNum;
    }

    public void AddEnergyNum(int num)
    {
        pickups.energyNum += num;
        if(pickups.energyNum == skillThreshold.energyNum)
        {
            pickups.energyNum = 0;
            Energy = maxEnergy;
            StartCoroutine(SkillEnergy());
        }
    }

    public void AddPlatformNum(int num)
    {
        pickups.platformNum += num;
        if (pickups.platformNum > skillThreshold.platformNum)
        {
            pickups.platformNum = skillThreshold.platformNum;
        }
    }

    public void AddRespawnNum(int num)
    {
        pickups.respawnNum += num;
        if (pickups.respawnNum == skillThreshold.respawnNum)
        {
            pickups.respawnNum = 0;
            SkillRespawn();
        }
    }

    public void AddLifeNum(int num)
    {
        pickups.lifeNum += num;

        if (pickups.lifeNum == skillThreshold.lifeNum)
        {
            pickups.lifeNum = 0;
            SkillLife();
        }
    }

    public void AddLife(int num)
    {
        life += num;
        if(life <= 0)
        {
            OnDead();
        }
    }

    IEnumerator SkillEnergy()
    {
        GameAudios.PlaySfx(gameObject, GameAudios.buffSfx);

        float consumerate = ConsumeRate;
        ConsumeRate = 0.0f;

        yield return new WaitForSeconds(skillEnergyTime);

        ConsumeRate = consumerate;
    }

    private void SkillRespawn()
    {
        GameAudios.PlaySfx(gameObject, GameAudios.buffSfx);

        respawnPlatform = lastPlatform;
        bRespawnPlatform = true;
    }

    private void SkillLife()
    {
        GameAudios.PlaySfx(gameObject, GameAudios.buffSfx);

        AddLife(1);
    }

    public void SetLastPlatform(Vector3 platform)
    {
        lastPlatform = platform;
    }

    public bool CanSpawnPlatform()
    {
        return pickups.platformNum > 0;
    }

    public void FlipIsAddForceByClick()
    {
        IsAddForceByClick = !IsAddForceByClick;
    }

    public void SetMinForce(InputField inputField)
    {
        if(inputField == null)
        {
            return;
        }

        float force = float.Parse(inputField.text);
        if (force > 0)
        {
            MinForce = force;
        }
    }

    public void SetMaxForce(InputField inputField)
    {
        if (inputField == null)
        {
            return;
        }

        float force = float.Parse(inputField.text);
        if (force > 0)
        {
            MaxForce = force;
        }
    }

    //血条值外部调用
    public float GetEnerge()
    {
        return Energy;
    }

    public Pickups GetPickups()
    {
        return pickups;
    }
}
