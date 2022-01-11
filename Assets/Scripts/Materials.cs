using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Materials
{
    // Root classes
    public class Element
    {
        //Class representing materials.
        public virtual float baseValue {get{return 1f;}}
        public virtual float weight {get{return 1f;}}
        public virtual bool magnetic {get{return false;}}
        public virtual string nameShort { get; }
        public virtual string nameLetter { get;}
        public virtual string nameLong { get; }
        public virtual string description { get; }
        public virtual string category { get{return "Other";}}

        public virtual Color pucColor {get {return new Color(0,0,0);}}
        public string displayName()
        {
            return nameLong ?? nameShort ?? nameLetter;
        }
    };
    public abstract class Form
    {
        //Class representing shape.
        public float baseValue { get; set; }
        public float volume { get; set; }
        public float handleDiff { get; set; }
        public float cleanDiff { get; set; }
        public string namePlural { get; set; }
    };
    public class NonFerrousMetal : Element
    {
        public override float baseValue {get{return 15f;}}
        public override float weight {get{return 100f;}}
        public override string category { get{return "Non-Ferrous Metal";}}
        public override string description {get{return "Non-Ferrous metal";}}
    }
    public class Aluminium : NonFerrousMetal
    {
        public override Color pucColor {get{return new Color(0.82f, 0.87f, 0.86f);}}
        public override string nameShort {get{return "Aluminium";}}
    }
    public class Tin : NonFerrousMetal
    {        
        public override Color pucColor {get{return new Color(0.8f, 0.4f, 0.4f, 1f);}}
        public override string nameShort {get{return "Tin";}}
    }    
    public class FerrousMetal : Element
    {
        public override bool magnetic {get{return true;}}
        public override float baseValue {get{return 10f;}}
        public override float weight {get{return 100f;}}
        public override string category {get{return "Ferrous metal";}}
        public override string description {get{return "Ferrous metal";}}
    }
    public class Steel : FerrousMetal
    {
        public override Color pucColor {get{return new Color(0.57f, 0.66f, 0.74f);}}
        public override string nameShort {get{return "Steel";}}
    }
    public class Glass : Element
    {
        public override Color pucColor {get{return new Color(0.1f, 0.1f, 1f);}}
        public override string nameShort {get{return "Glass";}}
    }
    public class Paper : Element
    {
        public override Color pucColor {get{return new Color(0.82f, 0.87f, 0.86f);}}
        public override string nameShort {get{return "Paper";}}
    }
    public class Plastic : Element
    {
        public override float baseValue {get{return 2f;}}
        public override float weight {get{return 10f;}}
        public override string category {get{return "Plastic";}}
        public override string description {get{return "You know what plastic is.";}}
    }

    public class PET : Plastic
    {
        public override Color pucColor {get{return new Color(1f, 1f, 0.9f);}}
        public override string nameLetter {get{return "PET";}}
        public override string description {get{return "Grade 1 plastic";}}
    }
    public class HDPE : Plastic
    {
        public override Color pucColor {get{return new Color(1f, 1f, 0.8f);}}
        public override string nameLetter {get{return "HDPE";}}
        public override string description {get{return "Grade 2 plastic";}}
    }
    public class PVC : Plastic
    {
        public override Color pucColor {get{return new Color(1f, 1f, 0.7f);}}
        public override string nameLetter {get{return "PVC";}}
        public override string description {get{return "Grade 3 plastic";}}
    }

    //    Plastics 1 (PET), Plastics 2 (HDPE), Plastics 3 (PVC), Plastics 4 (LDPE), Plastics 5 (PD), Plastics 6 (PS), Plastics 7 (other), plastic grades 1-7
    
    public class Bottle : Form
    {
        public Bottle()
        {
            namePlural = "Bottles";
            handleDiff = 0.2f;
            cleanDiff = 0.8f;
            volume = 0.1f;
        }
    }
    public class Can : Form
    {
        public Can()
        {
            namePlural = "Cans";
            handleDiff = 0.3f;
            cleanDiff = 0.5f;
            volume = 0.1f;
        }
    }
    public class SoftBag : Form
    {
        public SoftBag()
        {
            namePlural = "Bags";
            handleDiff = 0.5f;
            cleanDiff = 0.6f;
            volume = 0.1f;
        }
    }
    public class Strip : Form
    {
        public Strip()
        {
            namePlural = "Strips";
            handleDiff = 0.9f;
            cleanDiff = 0.1f;
            volume = 0.1f;
        }
    }
    public static class Elements
    {
        public enum ElementEnum { Aluminium, Steel, Tin, Paper, Glass, PET, HDPE, PVC};
        public static Dictionary<ElementEnum, Element> elementDict;
        static Elements()
        {
            elementDict = new Dictionary<ElementEnum, Element>(){
                {ElementEnum.Aluminium, new Aluminium()},
                {ElementEnum.Steel, new Steel()},
                {ElementEnum.Tin, new Tin()},
                {ElementEnum.Paper, new Glass()},
                {ElementEnum.Glass, new Glass()},
                {ElementEnum.PET, new PET()},
                {ElementEnum.HDPE, new HDPE()},
                {ElementEnum.PVC, new PVC()}
            };
        }
    }
    public static class Forms
    {
        public enum FormEnum { Bottle, Can, SoftBag, Strip };
        public static Dictionary<FormEnum, Form> formDict;
        static Forms()
        {
            formDict = new Dictionary<FormEnum, Form>(){
                {FormEnum.Bottle, new Bottle()},
                {FormEnum.Can, new Can()},
                {FormEnum.SoftBag, new SoftBag()},
                {FormEnum.Strip, new Strip()}
            };
        }
    }
}
// When you wanna get what the current material is
// Material m = materialDict[mat];
