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
    private static readonly IEnumerable<Allergen> allAllergens =
        Enum.GetValues(typeof(Allergen)).Cast<Allergen>();

    private readonly Allergen mask;

    public Allergies(int mask)
    {
        this.mask = (Allergen) mask;
    }

    public bool IsAllergicTo(Allergen allergen) => mask.HasFlag(allergen);

    public Allergen[] List() => allAllergens.Where(IsAllergicTo).ToArray();
}