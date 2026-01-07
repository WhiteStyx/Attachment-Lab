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
    public string myersBriggs;
    public AttachmentStyle attachmentStyle;
    public Neurodivergent neurodivergent;
    public personalityDisorder personalityDisorder;
    public trauma trauma;

    public string background;


}
