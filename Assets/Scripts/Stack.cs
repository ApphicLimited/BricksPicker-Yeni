using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public BaseColour MainColour;
    public int Point;
    public bool IsBigStack;
    public Elastic Elastic;
    public MeshRenderer MeshRenderer;
    public Rigidbody Rigidbody;
    public Animation animation;
    public GameObject cube;
    public BaseColour CurrentColour;
    public bool IsOnCollecter;

    private Material materialClone;
    private float constantHeight;

    private void Start()
    {
        SetUpMaterial();
        ChangeColour(MainColour);
    }

    private void Update()
    {
        if (transform.position.y != constantHeight)
        {
            transform.position = new Vector3(transform.position.x, constantHeight, transform.position.z);
        }
    }

    private void SetUpMaterial()
    {
        materialClone = new Material(GameManager.instance.StackManager.MaterialSource);
        MeshRenderer.material = materialClone;
    }

    public void ChangeColour(BaseColour colour)
    {
        CurrentColour = colour;
        if (materialClone == null)
            SetUpMaterial();

        materialClone.color = GameManager.instance.ColourController.GetColour(colour);
    }

    public void ResetColour()
    {
        CurrentColour = MainColour;
        if (materialClone == null)
            SetUpMaterial();

        materialClone.color = GameManager.instance.ColourController.GetColour(MainColour);
    }

    public void EnableElastic(bool isEnable, Transform _transform = null)
    {
        if (isEnable)
        {
            Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionX;
            Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ;
            GetComponent<BoxCollider>().enabled = true;

            if (animation.isPlaying)
                animation.Stop();
            if (transform.name == "Stack")
                animation.Play("BrickScale");

            //else
            //{
            //    animation.Play("BrickScale2");
            //}
        }
        else
        {
            Rigidbody.constraints &= ~RigidbodyConstraints.FreezeAll;
            GetComponent<BoxCollider>().enabled = true;
        }

        if (_transform != null)
            Elastic.Target = _transform;

        Elastic.enabled = isEnable;
    }

    public IEnumerator CubeCreate()
    {
        cube.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        cube.SetActive(false);
    }

    public void ThrowAway(float id)
    {
        Rigidbody.AddForce(Vector3.forward * GameManager.instance.StackManager.StackThrowingForce * id, ForceMode.Impulse);
        Destroy(this);
    }

    public void MoveOverCollecter(Transform transfrom, float yPos)
    {
        IsOnCollecter = true;
        constantHeight = yPos;
        transform.position = new Vector3(transform.position.x, constantHeight, transform.position.z);
    }

    public void MoveOneStackUp(float height)
    {
        IsOnCollecter = true;

        constantHeight = transform.position.y + height;
        transform.position = new Vector3(transform.position.x, constantHeight, transform.position.z);
    }
}