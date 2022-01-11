using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Materials;

[RequireComponent(typeof(TimeToAction))]
public class RubbishGenerator : MonoBehaviour
{
    public enum GeneratorType { Random };
    public GeneratorType generatorType;
    public GameObject pucPrefab;
    public Vector2Int generateRelativePosition;
    public static Dictionary<GeneratorType, Generator> genDict;

    Generator _generator;
    BaseGrid baseGrid;
    Vector2Int tilePosition;
    Transform generateStack;
    TimeToAction timeToAction;
    RubbishGenerator(){
        genDict = new Dictionary<GeneratorType, Generator>(){
                {GeneratorType.Random, new GeneratorRandom()}
        };
    }

    void Start() {
        timeToAction = transform.GetComponent<TimeToAction>();
        _generator = genDict[generatorType];

        baseGrid = transform.parent.GetComponentInParent<BaseGrid>();
        tilePosition = (Vector2Int)baseGrid.machineryTilemap.WorldToCell(transform.position);
        Vector2Int generatePosition = tilePosition + generateRelativePosition;

        try{
            generateStack = baseGrid.floorTilemap.GetInstantiatedObject((Vector3Int)generatePosition).transform;
        }catch{
            Debug.Log($"Conveyor at ({generatePosition.x},{generatePosition.y}) has invalid source tile.");
        }
    }
    void FixedUpdate() {
        if (timeToAction.currentTime == 0){
            // TODO: Check if movement allowed.
            _generator.Generate(Instantiate(pucPrefab, generateStack).GetComponent<RubbishBase>());
        }
    }
}

public class Generator
{
    // Update is called once per frame
    public GameObject rubbishPrefab;
    public virtual void Generate(RubbishBase newObj){}
}
public class GeneratorRandom : Generator
{
    // Update is called once per frame
    int nElements = System.Enum.GetValues(typeof(Elements.ElementEnum)).Length;
    int nForms = System.Enum.GetValues(typeof(Forms.FormEnum)).Length;

    public override void Generate(RubbishBase newObj)
    {
        //GameObject newObj = Instantiate(rubbishPrefasb);
        newObj.element = (Elements.ElementEnum)Random.Range(0, nElements);
        newObj.form = (Forms.FormEnum)Random.Range(0, nForms);
        newObj.dirtyness = Random.Range(0, 1);
    }
}