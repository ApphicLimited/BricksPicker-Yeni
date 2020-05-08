using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StackCollector : MonoBehaviour
{
    public float CollecterMaxScale;
    public float CollecterMinScale;
    public MeshRenderer Holder;
    public MeshRenderer Stick1;
    public MeshRenderer Stick2;
    public MeshRenderer Head;

    //[HideInInspector]
    public List<Stack> CollectedStacks = new List<Stack>();
    private Material materialClone;

    private float perStackHeightDistance = 0.38f;
    private bool IsPowerUpUsed;

    GameObject[] tuvaletkagitlari;

    private void Start()
    {
        IsPowerUpUsed = false;
        tuvaletkagitlari = GameObject.FindGameObjectsWithTag("TP");
        SuperPowerController.OnSuperPowerActivated += OnSuperPowerActivated;
        GameManager.instance.OnGameStarted += OnGameStarted;
    }

    public void SetUpMaterial()
    {
        materialClone = new Material(GameManager.instance.PlayerManager.MaterialSource);
        Holder.material = materialClone;
        Stick1.material = materialClone;
        Stick2.material = materialClone;
        Head.material = materialClone;
    }

    public void ChangeColour(BaseColour colour)
    {
        materialClone.color = GameManager.instance.ColourController.GetColour(colour);

        foreach (var item in CollectedStacks)
            item.ChangeColour(colour);
    }

    IEnumerator Basla()
    {
        yield return new WaitForSeconds(0.4f);
        if (GameManager.instance.isBonusLevel)
        {
            for (int i = 0; i < tuvaletkagitlari.Length; i++)
            {
                tuvaletkagitlari[i].GetComponent<BoxCollider>().enabled = true;
                tuvaletkagitlari[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }
    }

    public void ResetJointSettings()
    {
        Destroy(GameManager.instance.PlayerManager.Player.GetComponent<FixedJoint>());

        //foreach (var item in CollectedStacks)
        //{
        //    item.Rigidbody.isKinematic = false;
        //    item.EnableElastic(false);
        //    item.ThrowAway();
        //}
        StartCoroutine(Basla());

        for (int i = CollectedStacks.Count - 1; i >= 0; i--)
        {
            CollectedStacks[i].Rigidbody.isKinematic = false;
            CollectedStacks[i].EnableElastic(false);
            CollectedStacks[i].ThrowAway((CollectedStacks.Count - i) * Time.deltaTime);
        }
        
        GameManager.instance.GameState = GameStates.GameFinished;

        Destroy(gameObject);
    }

    private void UseMaxScale()
    {
        IsPowerUpUsed = true;
        Head.transform.localScale = new Vector3(CollecterMaxScale, transform.localScale.y, transform.localScale.z);
        GetComponent<BoxCollider>().size = new Vector3(GetComponent<BoxCollider>().size.x * 3, GetComponent<BoxCollider>().size.y, GetComponent<BoxCollider>().size.z);
    }

    private void UseMinScale()
    {
        IsPowerUpUsed = false;
        Head.transform.localScale = new Vector3(CollecterMinScale, transform.localScale.y, transform.localScale.z);
        GetComponent<BoxCollider>().size = new Vector3(GetComponent<BoxCollider>().size.x / 3, GetComponent<BoxCollider>().size.y, GetComponent<BoxCollider>().size.z);
    }

    //private void BalanceMassScale(float mass)
    //{
    //    GameManager.instance.PlayerManager.Player.Rigidbody.mass += mass;
    //    GetComponent<Rigidbody>().mass += mass;

    //    GameManager.instance.PlayerManager.Player.Rigidbody.mass += mass;
    //}

    private void PlaySound()
    {
        if (CollectedStacks.Last().IsBigStack)
        {
            GameManager.instance.AudioManager.PlayClip("CollectBigBrick");
        }
        else
        {
            GameManager.instance.AudioManager.PlayClip("CollectBrick");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == Constants.TAG_STACK)
        {
            if (collision.collider.GetComponent<Stack>().CurrentColour.ToString() == GameManager.instance.PlayerManager.CurrentColour.ToString())
            {
                CollectedStacks.Add(collision.collider.GetComponent<Stack>());

                if (CollectedStacks.Count == 1)
                {
                    CollectedStacks.Last().MoveOverCollecter(transform, 0.15f);
                    CollectedStacks.Last().EnableElastic(true, transform);
                    CollectedStacks.Last().Elastic.AnimationSpeed = GameManager.instance.StackManager.MaxStackWaveStrength;
                }
                else
                {
                    if (CollectedStacks.Last().IsBigStack)
                    {
                        CollectedStacks.Last().MoveOverCollecter(transform, 0.2f);
                    }
                    else
                    {
                        CollectedStacks.Last().MoveOverCollecter(transform, 0.15f);
                    }
                    
                    CollectedStacks.Last().EnableElastic(true, transform);
                    CollectedStacks.Last().Elastic.AnimationSpeed = GameManager.instance.StackManager.MaxStackWaveStrength;

                    for (int i = 0; i < CollectedStacks.Count; i++)
                    {
                        if (CollectedStacks.Last().IsBigStack)
                        {
                            CollectedStacks[i].MoveOneStackUp(.47f);
                        }
                        else
                        {
                            CollectedStacks[i].MoveOneStackUp(.19f);
                        }
                        CollectedStacks[i].EnableElastic(true, transform);
                        CollectedStacks[i].Elastic.AnimationSpeed -= GameManager.instance.StackManager.PerStackWaveReductionAmount;

                        if (CollectedStacks[i].Elastic.AnimationSpeed < GameManager.instance.StackManager.MinStackWaveStrength)
                            CollectedStacks[i].Elastic.AnimationSpeed = GameManager.instance.StackManager.MinStackWaveStrength;
                    }
                }

                PlaySound();
                
                if (collision.transform.name.Contains("Stack"))
                {
                    StartCoroutine(collision.transform.GetComponent<Stack>().CubeCreate());
                }

                GameManager.instance.SuperPowerController.AddPower(CollectedStacks.Last().Point);
                GameManager.instance.ScoreController.CurrentCollectedStackNumber++;
                GameManager.instance.StackManager.Stacks.Remove(collision.collider.GetComponent<Stack>());
            }
            else
            {
                GameManager.instance.SuperPowerController.SubPower(collision.collider.GetComponent<Stack>().Point);
                GameManager.instance.StackManager.Stacks.Remove(collision.collider.GetComponent<Stack>());
                Destroy(collision.collider.gameObject);
            }
        }
    }

    #region Events

    private void OnSuperPowerActivated(bool IsActivated)
    {
        if (IsActivated)
            UseMaxScale();
        else
            UseMinScale();
    }

    private void OnGameStarted()
    {

    }

    private void OnDestroy()
    {
        SuperPowerController.OnSuperPowerActivated -= OnSuperPowerActivated;
        GameManager.instance.OnGameStarted -= OnGameStarted;
    }

    #endregion
}