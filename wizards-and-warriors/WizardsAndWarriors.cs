using System;

abstract class Character
{
    public string CharacterType { get; private set; }
    public bool IsVulnerable { get; private set; }
    protected Character()
    {
        IsVulnerable = false;
    }
    protected Character(string characterType) : this()
    {
        CharacterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return IsVulnerable;
    }

    public override string ToString()
    {
        return $"Character is a {CharacterType}";
    }
    internal Character SetToVulnerable()
    {
        IsVulnerable = true;
        return this;
    }
    internal Character SetToUnVulnerable()
    {
        IsVulnerable = false;
        return this;
    }
}

class Warrior : Character
{
    public Warrior() : base(nameof(Warrior))
    {
        SetToUnVulnerable();
    }

    public override int DamagePoints(Character target)
    {
        return target.IsVulnerable ? 10 : 6;
    }
}

class Wizard : Character
{
    public bool HasSpell { get; private set; }

    public Wizard() : base(nameof(Wizard))
    {
        HasSpell = false;
        SetToVulnerable();
    }
    public override bool Vulnerable()
    {
        return HasSpell ? false : true;
    }
    public override int DamagePoints(Character target)
    {
        return HasSpell ? 12 : 3;
    }

    public void PrepareSpell()
    {
        HasSpell = true;
        SetToUnVulnerable();

    }
}
