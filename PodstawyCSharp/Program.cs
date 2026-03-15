// 1. Praca z terminalem
/*============================================*/
{
/* [Wypisywanie wartości] */
    Console.WriteLine("Hello, World!");
    Console.Write("Hello");

    
/* [Pobieranie wartości] */
    // string? lines = Console.ReadLine();
}

// 2. Typy i zmienne
/*============================================*/
{
/* [Value types] */
/*
 * Odpowiednik prymitywów w Javie. Implementowany z użyciem structów - obiektów,
 * które są value typami, mogą zwierać wiele wartości oraz metody.
 * Przykładowe structy: System.Int32, System.Double, System.Char.
 *
 * Wbudowane w .NET'a value type'y posiadają aliasy, z których zazwyczaj się korzysta, żeby zwiększyć czyetlność:
 * - System.Int32 => int
 * - System.Double => double
 * etc.
 *
 * Wybrane value typy:
 */
    int myInt = 10;
    float myFloat = 3.14f;
    double myDouble = 4.56;
    char myChar = 'a';
    bool myBool = true;
    
    
/* [Reference types] */
/*
 * Typy obiektów, które nie przechowują wartości bezpośrednio "w sobie", a referencję do obiektu w pamięci.
 * Typami referencyjnymmi z zasady są wszystkie typy oparte o klasy.
 *
 * Wybrane typy referencyjne:
 */
    string myStr = "Hello World"; // Notka: string jest aliasem do System.String.
                                  // W .NET z zasady preferujemy używanie tej formy zapisu.

    int[] myIntArr = new int[3];
    int[,] myIntArr2 = new int[2, 2]; // Notka: w .NET wielowymiarowość w arrayu definiuje się poprzez
                                      // dodawanie przecinków do []. Tak samo przy deklarowaniu wielkości
                                      // poszczeŋólnych wymiarów. Java: int[2][2]; CSharp: int[2,2];
                                      // https://www.w3schools.com/cs/cs_arrays_multi.php

    // Wybrane kolekcje, które też są typami referencyjnymi:
    List<int> list = new List<int>(); // Notka: w .NET List to równoważnik ArrayList z Javy. To nie interfejs!
    HashSet<int> set = new HashSet<int>();
    Dictionary<int, int> dict = new Dictionary<int, int>(); // Notka: odpowiednik HashMap z Javy.
    
    // Notka: interfejsy pod kolekcje w .NET to IEnumerable oraz ICollection
    // Notka: w przeciwieństwie do Javy, w C# z racji różnic w implementacji, w generykach można używać
    // bezpośrednio value typy.
    
    
/* [var keyword] */
/*
 * Autodedukcja typu zmiennej na bazie wartości do niej przypisanej. W Javie wprowadzone całkiem niedawno,
 * w C# dostępne od pierwszych wersji języka. Często wykorzystywane.
 *
 * Kiedy stosować?:
 * - Gdy typ zmiennej jest prosty do dedukcji bazując na prawej części wyrażenia;
 * - Gdy pracujemy z typami, których łączna nazwa jest bardzo długa (np. kombinacja wielu zagnieżdżonych typów generycznych);
 * - Podczas pracy z typami anonimowymi lub ciągami LINQ
 */
    var myVariable1 = 10; // typ int
    var myVariable2 = "Hello"; // typ string
    var myVariable3 = 20.3; // typ double
    var myVariable4 = new List<int>(); // lista obiektów typu int
   
    
/* [Wartość null] */
/*
 * W C# praca z null powinna być jawna oraz przemyślana. Istnieje tutaj operator nullowalności,
 * który definiuje, jaka zmienna może przechowywać nulla (value type) albo
 * która zmienna powinna go przechowywać (reference type).
 *
 * Operator nullowalności doklejamy na koniec do nazwy typu.
 */
    // int normalInt = null; // brak zezwolenia nulla - error uniemożliwiający kompilację
    int? nullableInt = null; // ok

    // string normalString = null; // typ referencyjny ale bez zezwolenia na nulla - warning podczas kompialcji
    string? nullableString = null;
}

// 3. Decyzje i pętle 
/*============================================*/
{
/* [Decyzje] */
    var warunek = true;
    var wartosc = 10;

    // Instrukcja if oraz switch - działanie takie samo jak w javie
    if (warunek)
    {
        
    } else if (warunek)
    {
        
    }
    else
    {
        
    }

    switch (wartosc)
    {
        case 1: Console.WriteLine(1); break;
        case 2: Console.WriteLine(2); break;
        case 3: Console.WriteLine(3); break;
        default: Console.WriteLine("Cholera wie"); break;
    }
    
    // Switch expression
    var result = wartosc switch
    {
        10 => "10",
        <10 => "<10",
        _ => ">10"
    };
    
/* [Pętle] */
    // Pętla for, while oraz do..while działają tak samo jak w Javie
    for (int i = 0; i < wartosc; i++)
    {
        
    }

    while (false)
    {
        
    }

    do
    {
        
    } while (false);
    
    // Pętla foreach - przechodzenie wartościach obiektu implementującego IEnumerable
    var list = new List<int>();
    foreach (var elem in list)
    {
        
    }
}

// 4. Klasy, interfejsy, propsy, wyjątki
/*============================================*/
{
    // Notka: obiekty zadeklarowane poniżej
    var square = new Square(10);
    var rect = new Rectangle(10, 20);
    rect.Height = 20; // Nadpisanie wartości property
    Console.WriteLine(square.Width); // Przeczytanie wartości property
    Console.WriteLine(square);
    Console.WriteLine(rect);
}

// 5. Praca z plikami
/*============================================*/
{
    // Zapis do pliku - wszelkie metody z klasy File zaczynające się od Write:
    File.WriteAllLines("./sciezka.txt", ["Hello", "World"]);
    
    // Czytanie pliku - wszelkie metody z klasy File zaczynające się od Read:
    var lines = File.ReadLines("./sciezka.txt");
}


// Obiekty do pp. 4 Klasy, interfejsy, propsy, wyjątki

// [Interfejs]
public interface IFigure
{
    double GetArea();
    double GetPerimeter();
}

// [Klasy]
public class Square(double width) : IFigure
{
    public double Width { get; set; } = width;
    
    // Notka: Metody, które chcemy żeby były nadpisywalne
    // należy oznaczyć keywordem virtual
    public virtual double GetArea()
    {
        return Width * Width;
    }

    public virtual double GetPerimeter()
    {
        return 4 * Width;
    }
    
    public virtual double GetDiagonal()
    {
        return Width * Math.Sqrt(2);
    }

    public override string ToString()
    {
        // Interpolacja stringa. Umożliwia ona bezpośrednie wstrzykiwanie wartości w ciąg znakowy. Ewolucja String.format.
        // Interpolowany string poprzedzamy operatorem '$'. Wartości wstrzykujemy wewnątrz nawiasów klamrowych.
        return $"Width: {Width}, Area: {GetArea()}, Perimeter: {GetPerimeter()}, Diagonal: {GetDiagonal()}"; 
    }
}

public class Rectangle(double height, double width) : Square(width)
{
    public double Height { get; set; } = height;
    
    // Notka: Metody, które chcemy nadpisać
    // należy oznaczyć keywordem override
    public override double GetArea()
    {
        return Height * Width;
    }

    public override double GetPerimeter()
    {
        return 2 * (Width + Height);
    }

    public override double GetDiagonal() 
    {
        return Math.Sqrt(Math.Pow(Height, 2) + Math.Pow(Width, 2));
    }

    public override string ToString()
    {
        return $"Height: {Height}, {base.ToString()}"; // wywołanie base - wywołanie implementacji z klasy bazowej
    }
}