using UnityEngine;

public enum Gender
{
    Male,
    Female
}

public enum SexOrient
{
    Bisexual,
    Heterosexual
}

public enum MyersBriggs
{
    ESTJ, ESTP, ESFJ, ESFP,
    INTJ, INTP, INFJ, INFP
}

public enum AttachmentStyle
{
    Secure,
    Anxious,
    Avoidant,
    Disorganised
}

public enum Neurodivergent
{
    Autism,
    ADHD,
    Dyslexia,
    Dyspraxia,
}

[System.Serializable]
public class ProfileData
{
    public string firstName;
    public string lastName;
    public Gender gender;
    public SexOrient sexOrient;
    public float energy;
    public float intelligence;
    public float agreeableness;
    public MyersBriggs myersBriggs;
    public AttachmentStyle attachmentStyle;
    public Neurodivergent neurodivergent;
    public enum personalityDisorder
    {
        Paranoid,
        Schizoid,
        Schizotypal
        //Antisocial,
        //Borderline,
        //Histrionic,
        //Narcissistic,
        //Avoidant,
        //Dependent,
        //ObsessiveCompulsive
    }
    public enum trauma
    {
        Chronic,
        Complex,
        Intergenerational
    }
    public string background;
}
