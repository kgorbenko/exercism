using System;
using System.Collections.Generic;
using System.Linq;

public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private readonly int mask;
    private readonly IEnumerable<Allergen> allAllergens;

    public Allergies(int mask)
    {
        this.mask = mask;
        allAllergens = Enum.GetValues(typeof(Allergen)).Cast<Allergen>();
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        return ((Allergen)mask).HasFlag(allergen);
    }

    public Allergen[] List()
    {
        return allAllergens.Where(IsAllergicTo).ToArray();
    }
}